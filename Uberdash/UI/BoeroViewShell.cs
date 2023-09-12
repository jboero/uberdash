/**************************************************************************** /
                               BoeroView.cs
                 © 2008 John Boero - Mawenzy Solutions

The BoeroLV control is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
 
This control is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU Lesser Public License for more details.
 
You should have received a copy of the GNU Lesser Public License
along with this file.  If not, see <http://www.gnu.org/licenses/>.

Any feedback, comments, improvements, winning lottery tickets, job offers, etc.
may be directed to john.boero@mawenzy.com.  Thank you.
****************************************************************************/
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tao.OpenGl;
using Tao.Platform.Windows;
using ShellDll;
using Mawenzy.Properties;
using Mawenzy.Util;

namespace Mawenzy
{
    /// John Boero © Mawenzy 2008 <summary>
    /// OpenGL implementation of ListView.
    /// </summary>
    /// <author>john.boero@mawenzy.com</author>
    /// <version>25-SEP-2008</version>
    public class BoeroViewShell : ListView
    {
        #region PInvoke
        /// <summary>
        /// Gets scroll position of this control. 
        /// Everyone's favorite forgottenness..
        /// </summary>
        /// <param name="hWnd">HWND of this.</param>
        /// <param name="nBar">0 for Horiz, 1 for Vert</param>
        /// <returns> Scroll position of bar specified in nBar.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetScrollPos(IntPtr hWnd, int nBar);
        
        [DllImport("comctl32")]
        protected extern static IntPtr ImageList_GetIcon(IntPtr himl, int i, int flags);
        #endregion

        #region Delegates and Events
        /// John Boero <summary>
        /// Allows the RenderBackground event to be used to issue any OpenGL 
        /// rendering on the background of this ListView.
        /// </summary>
        /// <param name="frame">The current frame number to your background routine.</param>
        public delegate void DrawBackground(long frame);
        
        /// John Boero <summary>
        /// Allows external routines to initialize once we create the rendering context.
        /// </summary>
        public delegate void PostInit();

        /// John Boero <summary>
        /// Manually bind wglSwapIntervalEXT, because it never seemed to work right otherwise.
        /// </summary>
        /// <param name="vsync"> 0 for no vsync </param>
        private delegate void SwapControl(int vsync);

        /// John Boero <summary>
        /// To avoid constant branching in paint events, use this delegate to hold a draw routine.
        /// </summary>
        private delegate void PaintDelegate();

        /// John Boero <summary>
        /// Set up your own modelview matrix and draw anything on the background.
        /// Here is where the typical customization will take place.
        /// </summary>
        [CategoryAttribute("Boero ListView")]
        [Description("Called each frame before icons are drawn.")]
        public event DrawBackground RenderBackground;

        /// John Boero <summary>
        /// Called after the rendering context is created.  Initialize any external
        /// display lists or textures here.
        /// </summary>
        [CategoryAttribute("Boero ListView")]
        [Description("Called after the rendering context is created.  Use to do any pre-show initialization, texture loads, etc.")]
        public event PostInit AfterInitRC;
        #endregion

        #region Members
        /// <summary>
        /// Add this base number to all created textures.
        /// </summary>
        protected int TextureBase = 0x10000000;
        /// <summary>
        /// Add this base number to all created display lists.
        /// </summary>
        protected int ListBase = 0x10000000;
        /// <summary>
        /// Use this range to partition parallel textures.
        /// For example, label = 0x004, large icon = 0x204, sm icon = 0x404
        /// </summary>
        protected const int maxItems = 0x200;
        /// <summary>
        /// Maximum height of a label in full size (not ellipsed) render.
        /// </summary>
        protected const int maxLabelHeight = 192;
        /// <summary>
        /// Seems to be the maximum size for a ListViewItem label.
        /// It may be dependent on system font/dpi.
        /// </summary>
        protected static Size labelMax = new Size(80, 32);
        /// <summary>
        /// Shader program name (number) of our label fragment shader.
        /// </summary>
        private int prLabel;
        /// <summary>
        /// Shader program name (number) of the highlighted label fragment shader.
        /// </summary>
        private int prLabelSelected;
        /// <summary>
        /// Icon unselected.
        /// </summary>
        private int prIcon;
        /// <summary>
        /// Shader program name (number) of our icon fragment shader.
        /// </summary>
        private int prIconSelected;
        /// <summary>
        /// Our Control's Display Context.
        /// </summary>
        private IntPtr hDC;
        /// <summary>
        /// An OpenGL Rendering Context layed over the control's DC.
        /// </summary>
        private IntPtr hRC;
        /// <summary>
        /// Pixel format for our rendering context.
        /// </summary>
        private int pixelFormat;
        /// <summary>
        /// Animate using a Forms.Timer to tick between events.
        /// Do not use a System.Threading.Timer
        /// </summary>
        protected System.Windows.Forms.Timer animator;
        /// <summary>
        /// Flag to tell if we are animating using this.animator.
        /// </summary>
        protected bool animating = true;
        /// <summary>
        /// Prevents premature rendering context instantiation.
        /// </summary>
        private bool inited = false;
        /// <summary>
        /// Track the numbe of frames drawn.
        /// </summary>
        protected long frame = 0;
        /// <summary>
        /// A hidden label to rasterize unicode text for textures.
        /// </summary>
        protected Label textLabel;
        /// <summary>
        /// Instead of checking a ready flag at every paint event, this delegate is called 
        /// directly to draw.  It may be set to NullDraw or ReadyDraw.
        /// </summary>
        private PaintDelegate drawDelegate;
        /// <summary>
        /// Know if an item is being label-edited.
        /// </summary>
        private ListViewItem labelEditingItem = null;
        /// <summary>
        /// Track the main selection to draw unelipsed.
        /// </summary>
        private ListViewItem mainItem = null;
        /// <summary>
        /// Stores value of property HighlightAlpha.
        /// </summary>
        private byte highlightAlpha = 0xFF;
        /// <summary>
        /// Stores the property Highlight.
        /// </summary>
        private Color highlight = SystemColors.Highlight;
        /// <summary>
        /// Stores the scroll position of this control.
        /// </summary>
        protected Point scrollPos = new Point();
        protected Point scrollPosTail = new Point();
        /// <summary>
        /// Stores the aspect ratio of this control.
        /// </summary>
        private float aspect = 1;

        /// John Boero <summary>
        /// Determine what needs to be forced during a redraw
        /// and what can be passively reused.  By narrowing down 
        /// redraw attributes, we save CPU cycles.
        /// </summary>
        [Flags]
        internal enum DrawAttrs : byte
        {
            /// <summary> None </summary>
            None        = 0x00,
            /// <summary> Makes sure to refresh the icon texture from our ImageList. </summary>
            /// <remarks> TextureBase[0] + icon index </remarks>
            IconTexture = 0x01,
            /// <summary> Change icon color/highlight. </summary>
            /// <remarks> ListBase[1] + icon index </remarks>
            IconColor   = 0x02,
            /// <summary> Completely redraw icon. </summary>
            /// <remarks> TextureBase[0] & ListBase[1] + icon index </remarks>
            IconAll     = IconTexture | IconColor,
            /// <summary> Regenerate text texture. </summary>
            /// <remarks> TextureBase[1] + item index </remarks>
            LabelText   = 0x04,
            /// <summary> Update label textures for highlight. </summary>
            /// <remarks> ListBase[2] + item index </remarks>
            LabelColor  = 0x08,
            /// <summary> Completely redraw label. </summary>
            /// <remarks> TextureBase[1] & ListBase[2] + item index </remarks>
            LabelAll    = LabelText | LabelColor,
            /// <summary> Keep textures to only relocate. </summary>
            /// <remarks> ListBase[3] + item index </remarks>
            Position    = 0x10,
            /// <summary> Rebuild list that calls each item list. </summary>
            /// <remarks> ListBase </remarks>
            MasterList  = 0x20,

            /// <summary> Completely force everything to redraw.  This can be CPU intensive. </summary>
            /// <remarks> TextureBase[0,1] + image index & ListBase[1,2,3] + item index </remarks>
            All = IconAll | LabelAll | Position | MasterList
        }

        /// John Boero <summary>
        /// Divide 
        /// </summary>
        protected enum DisplayListType
        {
            MasterList  = 0,
            WholeItem   = 1,
            Icon        = 2,
            Label       = 3
        }
        #endregion

        #region Props
        /// John Boero 15-APR-2007 <summary>
        /// Gets or sets the frame rate cap for refresh.
        /// Note: Animate must be set to true for this to take effect.
        /// </summary>
        [Description("Limits the frame rate of internal animation to this level.")]
        [CategoryAttribute("Boero ListView")]
        [DefaultValue(50)]
        public int MaxFrameRate
        {
            get
            {
                return (int)(1000 / animator.Interval);
            }
            set
            {
                if (value == 0) value = 1;
                animator.Interval = 1000 / (int)value;
            }
        }

        /// John Boero 15-APR-2007<summary>
        /// Gets or sets whether the control animates itself at the
        /// specified frame rate.
        /// </summary>
        [CategoryAttribute("Boero ListView")]
        [Description("When true, the control will animate itself using a Form.Timer at the rate specified in MaxFrameRate.")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool Animate
        {
            get
            {
                return animating;
            }
            set
            {
                animating = value;

                if (animator != null && Visible && !DesignMode)
                     animator.Enabled = value;
            }
        }

        /// John Boero <summary>
        /// Gets or sets the BackColor for this listview.
        /// Note: this is done by changing the state of glClearColor.
        /// </summary>
        public override Color BackColor
        {
            set
            {
                Gl.glClearColor((float)value.R / 255f, 
                    (float)value.G / 255f, 
                    (float)value.B / 255f, 
                    (float)value.A / 255f);

                base.BackColor = value;
            }
        }

        /// John Boero 10-AUG-2008 <summary>
        /// Gets or sets the highlight color of items and labels.
        /// </summary>
        /// <remarks>The alpha of this color may alter the effects of HighlightAlpha. </remarks>
        [CategoryAttribute("Boero ListView")]
        [Description("Gets or sets the item highlight color of this listview.")]
        [Browsable(true)]
        public Color HighlightColor
        {
            get { return highlight; }
            set
            { 
                highlight = value;

                foreach (ListViewItem selit in SelectedItems)
                    DrawTaoItemDL(selit, DrawAttrs.IconColor | DrawAttrs.LabelColor);
            }
        }

        /// John Boero 10-AUG-2008 <summary>
        /// Gets or sets the highlight alpha of label textures.
        /// </summary>
        /// <remarks>Current blending may give unexpected results.
        /// to customize blending, alter the label shader. </remarks>
        [CategoryAttribute("Boero ListView")]
        [Description("Optional translucency highlight tinting on labels. 0x00-0xFF")]
        [DefaultValue(255)]
        public byte HighlightAlpha
        {
            get { return highlightAlpha; }
            set
            {
                highlightAlpha = value;
            
                foreach (ListViewItem selit in SelectedItems)
                    DrawTaoItemDL(selit, DrawAttrs.IconColor | DrawAttrs.LabelColor);
            }
        }

        /// John Boero <summary>
        /// Gets the current total frames of animation.
        /// </summary>
        [CategoryAttribute("Boero ListView")]
        [Description("Gets the current frame count from the beginning of this context's life.")]
        [Browsable(true)]
        public long Frame
        {
            get
            {
                return frame;
            }
        }

        /// John Boero <summary>
        /// Gets the aspect ratio of this control.
        /// </summary>
        [CategoryAttribute("Boero ListView")]
        [Description("Gets the aspect ratio of the window without calculating it.")]
        [Browsable(false)]
        public float Aspect
        {
            get
            {
                return aspect;
            }
        }
        #endregion

        #region Core
        /// John Boero 15-APR-2007 <summary>
        /// Create a default BoeroLV with some special flags to completely take over drawing.
        /// </summary>
        public BoeroViewShell() : base()
        {
            Mawenzy.Plugins.PluginBase.SetParent(this);

            animator       = new System.Windows.Forms.Timer();
            animator.Interval = 1000 / 50;
            animator.Tick += new EventHandler(RenderFrame);
            textLabel      = new Label();

            textLabel.AutoEllipsis = true;
            textLabel.TextAlign = ContentAlignment.MiddleCenter;
            textLabel.BackColor = Color.Black;
            textLabel.ForeColor = Color.White;
            textLabel.MaximumSize = labelMax;
            textLabel.Hide();
            Controls.Add(textLabel);

            CreateParams.ClassStyle |= User.CS_VREDRAW | User.CS_HREDRAW | User.CS_OWNDC;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);            // No Need To Erase Form Background
            this.SetStyle(ControlStyles.Opaque, true);                          // No Need To Draw Form Background
            this.SetStyle(ControlStyles.ResizeRedraw, false);                   // Redraw On Resize
            this.SetStyle(ControlStyles.UserPaint, true);                       // We'll Handle Painting Ourselves
            RenderBackground = null;

            drawDelegate = NullDraw;
        }

        /// John Boero 15-APR-2007 <summary>
        /// Set up OpenGL rendering context.
        /// </summary>
        private void Init()
        {
            Gdi.PIXELFORMATDESCRIPTOR pfd = new Gdi.PIXELFORMATDESCRIPTOR();

            if (pixelFormat == 0)
            {
                pfd.nSize = (short)Marshal.SizeOf(pfd);
                pfd.nVersion = 1;
                pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL | Gdi.PFD_DOUBLEBUFFER;
                pfd.iPixelType = (byte)Gdi.PFD_TYPE_RGBA;
                pfd.cColorBits = (byte)32;
                pfd.cRedBits = 0;
                pfd.cRedShift = 0;
                pfd.cGreenBits = 0;
                pfd.cGreenShift = 0;
                pfd.cBlueBits = 0;
                pfd.cBlueShift = 0;
                pfd.cAlphaBits = 0;
                pfd.cAlphaShift = 0;
                pfd.cAccumBits = 0;
                pfd.cAccumRedBits = 0;
                pfd.cAccumGreenBits = 0;
                pfd.cAccumBlueBits = 0;
                pfd.cAccumAlphaBits = 0;
                pfd.cDepthBits = 16;
                pfd.cStencilBits = 0;
                pfd.cAuxBuffers = 0;
                pfd.iLayerType = (byte)Gdi.PFD_MAIN_PLANE;
                pfd.bReserved = 0;
                pfd.dwLayerMask = 0;
                pfd.dwVisibleMask = 0;
                pfd.dwDamageMask = 0;

                hDC = User.GetDC(Handle);
                if (hDC == IntPtr.Zero)
                    throw new ApplicationException("Can't Create A GL Device Context.");

                pixelFormat = Gdi.ChoosePixelFormat(hDC, ref pfd);
                if (pixelFormat == 0)
                    throw new ApplicationException("Can't Find A Suitable PixelFormat.");
            }
            else
                hDC = User.GetDC(this.Handle);

            if (!Gdi.SetPixelFormat(hDC, pixelFormat, ref pfd))
            {
                KillHRC(hRC);
                throw new ApplicationException("Can't Set The PixelFormat.");
            }

            hRC = Wgl.wglCreateContext(hDC);
            if (hRC == IntPtr.Zero)
            {
                KillHRC(hRC);
                throw new ApplicationException("Can't Create A GL Rendering Context.");
            }

            if (!Wgl.wglMakeCurrent(hDC, hRC))
            {
                KillHRC(hRC);
                throw new ApplicationException("Can't Activate The GL Rendering Context.");
            }

            // This is a major drag on startup, but it must be done in the 
            // current version of TAO or shader functions will throw null.
            Gl.ReloadFunctions();

            // Initialize item list.
            BackColor = BackColor;

            // Set vsync off or incur a nasty CPU penalty!
            // Also make sure GPU is not running on power save mode (laptop on battery?)
            SwapControl swap = (SwapControl)Gl.GetDelegate("wglSwapIntervalEXT", typeof(SwapControl));
            if (swap != null)
                swap(0);

            InitShaders();

            if (AfterInitRC != null)
                AfterInitRC();

            this.Font = SystemFonts.IconTitleFont;
        }

        /// John Boero 15-APR-2007 <summary>
        /// Builds a display list that draws all of this.Items.  
        /// </summary>
        /// <remarks>
        /// Quick and dirty.  Call me old fashioned.  
        /// I know display lists will disappear from OpenGL.
        /// That day I will weap as I try to get used to VBOs.
        /// DLs are just so straightforward.
        /// </remarks>
        /// <param name="force">
        /// Force a rebuild of every display list if this is true.
        /// </param>
        private void BuildItemList(DrawAttrs forcedAttrs)
        {
            foreach (ListViewItem item in Items)
                DrawTaoItemDL(item, forcedAttrs);

            // Rebuild master list.
            if ((forcedAttrs & (DrawAttrs.MasterList | DrawAttrs.Position)) != 0)
            {
                int itemBase = GetDisplayList(DisplayListType.WholeItem);

                Gl.glNewList(GetDisplayList(DisplayListType.MasterList), Gl.GL_COMPILE);

                RenderState.SetOrtho(ClientRectangle);

                Gl.glTranslatef(-scrollPos.X, -scrollPos.Y, 0);

                Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
                Gl.glEnable(Gl.GL_BLEND);
                Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);

                // Draw icons and labels in separate loops to keep icons from covering labels.
                for (int i = 0; i < Items.Count; ++i)
                    Gl.glCallList(i + GetDisplayList(DisplayListType.Icon));
                
                for (int i = 0; i < Items.Count; ++i)
                    Gl.glCallList(i + GetDisplayList(DisplayListType.Label));

                Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);
                Gl.glDisable(Gl.GL_BLEND);
                Gl.glEndList();
            }
            else             // Build individual item lists.
            
            drawDelegate = ReadyDraw;
        }

        /// John Boero 06-JUL-2008 <summary>
        /// Standardizes parallel display list structure.
        /// </summary>
        /// <param name="listType"> The type of list to get. </param>
        /// <remarks>Replaces older soppy enum arithmetic parallel lists. </remarks>
        /// <returns>Base list of the type specified.  Add an item's index to get actual list. </returns>
        private int GetDisplayList(DisplayListType listType)
        {
            return ListBase + ((int)listType * maxItems);
        }

        /// John Boero 13-OCT-2007 <summary>
        /// Compile 2 shader programs to emulate ListView appearance.
        /// </summary>
        /// <remarks>
        /// Icon shader is an approximate blend of texture, dest color, and highlight.
        /// Label shader is a best-fit approximate blend of monochrome texture, dest color, and highlight.
        /// Labels with transparent backcolor sadly don't play well with DrawToBitmap.
        /// </remarks>
        private void InitShaders()
        {
            prIcon = RenderState.BuildShader(
@"uniform sampler2DRect sampler0;
void main(void)
{
    vec4 tex = texture2DRect(sampler0, gl_TexCoord[0].st);
    gl_FragColor = mix(gl_TextureEnvColor[0], tex, tex.a);
}");
            // JLB V1 13-OCT-2007
            // Tinted icons with background blending.
            prIconSelected = RenderState.BuildShader(
@"uniform sampler2DRect sampler0;
uniform vec4 fc;
void main(void)
{
    vec4 tex = texture2DRect(sampler0, gl_TexCoord[0].st);
    vec4 src = mix(fc, tex, 0.5);
    gl_FragColor = mix(gl_TextureEnvColor[0], src, tex.a);
}");
            // JLB V2 30-NOV-2008
            // This blending is much better with ClearType smoothing.
            // Note texture is white text on black background.
            prLabel = RenderState.BuildShader(
@"uniform sampler2DRect sampler0;
void main(void)
{
    // Blur shadow
    vec4 shadow = 
        texture2DRect(sampler0, vec2(gl_TexCoord[0].s - 2, gl_TexCoord[0].t + 0.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s - 1, gl_TexCoord[0].t + 0.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s    , gl_TexCoord[0].t + 0.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s + 1, gl_TexCoord[0].t + 0.5))

      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s - 2, gl_TexCoord[0].t - 0.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s - 1, gl_TexCoord[0].t - 0.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s    , gl_TexCoord[0].t - 0.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s + 1, gl_TexCoord[0].t - 0.5))

      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s - 2, gl_TexCoord[0].t - 1.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s - 1, gl_TexCoord[0].t - 1.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s    , gl_TexCoord[0].t - 1.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s + 1, gl_TexCoord[0].t - 1.5))

      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s - 2, gl_TexCoord[0].t - 2.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s - 1, gl_TexCoord[0].t - 2.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s    , gl_TexCoord[0].t - 2.5))
      + texture2DRect(sampler0, vec2(gl_TexCoord[0].s + 1, gl_TexCoord[0].t - 2.5));

    vec4 white = texture2DRect(sampler0, gl_TexCoord[0].st);
    white.a = 0;
    white += gl_TextureEnvColor[0];

    //gl_FragColor = mix(vec4(0,0,0, length(shadow.rgb) / 5), white, 0.75);
    gl_FragColor = vec4(0,0,0, length(shadow.rgb) / 12) + white;
}");
            prLabelSelected = RenderState.BuildShader(
@"uniform sampler2DRect sampler0;
uniform vec4 bc, fc;
void main(void)
{
    vec4 tex = texture2DRect(sampler0, gl_TexCoord[0].st);
    vec4 src = mix(bc, fc, tex);
    gl_FragColor = mix(gl_TextureEnvColor[0], src, clamp(bc.a + length(tex.rgb), 0.0, 1.0));
}");
        }

        /// John Boero 15-APR-2007 <summary>
        /// Draw a single ListViewItem into its corresponding display list.
        /// </summary>
        /// <param name="item">A standard ListViewItem to draw using OpenGL.</param>
        /// <param name="force">Destroy and explicitly rebuild our lists from the image up.</param>
        /// <todo> Implement Details,List,SmallIcon,Tile view. </todo>
        /// <todo> Figure out "Display Groups" group dividers. </todo>
        internal void DrawTaoItemDL(ListViewItem item, DrawAttrs forcedAttrs)
        {
            if (item == null)
                return;

            int texture = item.ImageIndex + TextureBase;
            int itemIndex = item.Index;
            int itemList = itemIndex + GetDisplayList(DisplayListType.WholeItem);

            switch (View)
            {
                case View.LargeIcon:
                        DrawLargeIcon(item, forcedAttrs);
                        DrawLabel(item, forcedAttrs);

                    Gl.glCallList(itemList);
                    break;

                default:
                    throw new NotImplementedException("View " + View + " not supported in this version.");
            }

            Gl.glNewList(itemList, Gl.GL_COMPILE);
            Gl.glCallList(itemIndex + GetDisplayList(DisplayListType.Icon));
            Gl.glCallList(itemIndex + GetDisplayList(DisplayListType.Label));
            Gl.glEndList();
        }

        /// John Boero 15-APR-2007 <summary>
        /// Draws the text under ListViewItem icons.
        /// </summary>
        /// <param name="item">Item to draw text of.</param>
        /// <param name="force"></param>
        /// <param name="itemIndex"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="b"></param>
        private void DrawLabel(ListViewItem item, DrawAttrs force)
        {
            int textTexture = item.Index + maxItems + TextureBase;
            string itemText = item.Text;

            // Clear the texture if label-editing or blank.
            if (item == labelEditingItem || itemText == null || itemText == "")
            {
                Gl.glDeleteTextures(1, new int[] { textTexture });
                Gl.glDeleteLists(item.Index + GetDisplayList(DisplayListType.Label), 1);
            }
            else if ((force & (DrawAttrs.LabelAll | DrawAttrs.Position)) != 0)
            {
                // Unelipse main item.
                if (item == mainItem)
                    textLabel.MaximumSize = new Size(labelMax.Width, maxLabelHeight);

                textLabel.Text = itemText;
                textLabel.Size = new Size(textLabel.PreferredWidth, textLabel.PreferredHeight + 4);

                Size icSize = GetIconImage(LargeImageList, item.ImageIndex).Size;
                int itemIndex = item.Index;
                int left = (item.Bounds.Left + item.Bounds.Right - icSize.Width) / 2 - 2;
                int top = item.Bounds.Top + 4;
                Rectangle reg = Rectangle.FromLTRB(left, top, left + icSize.Width, top + icSize.Height);

                Gl.glNewList(itemIndex + GetDisplayList(DisplayListType.Label), Gl.GL_COMPILE);

                if (item.Selected && (Focused || !HideSelection))
                {
                    Gl.glUseProgramObjectARB(prLabelSelected);
                    ShaderColors(SystemColors.ActiveCaptionText, Color.FromArgb(highlightAlpha, highlight));
                }
                else
                    Gl.glUseProgramObjectARB(prLabel);

                if ((force & DrawAttrs.LabelText) != 0)
                {
                    // Handle blank names.
                    Bitmap bmp = new Bitmap(textLabel.Width, textLabel.Height);
                    try
                    {
                        textLabel.DrawToBitmap(bmp, textLabel.Bounds);
                    }
                    catch (Exception)
                    {
                        // Ignoreage
                    }
                    BitmapData bitmapData = bmp.LockBits(Rectangle.FromLTRB(0, 0, bmp.Width, bmp.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                    Gl.glBindTexture(Gl.GL_TEXTURE_RECTANGLE_ARB, textTexture);
                    Gl.glTexImage2D(Gl.GL_TEXTURE_RECTANGLE_ARB, 0, Gl.GL_RGBA8, bmp.Width, bmp.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);
                    bmp.UnlockBits(bitmapData);
                    bmp.Dispose();
                }

                int center = (reg.Left + reg.Right) / 2;
                Rectangle labRect = textLabel.Bounds;
                labRect.Offset(center + 2 - (textLabel.Width) / 2, reg.Bottom);
                RenderState.TexturedRect(textTexture, labRect);
                Gl.glUseProgramObjectARB(0);
                Gl.glEndList();

                textLabel.MaximumSize = labelMax;
            }
        }

        /// JLB <summary>
        /// A dictionary of file paths and when their thumbnails were generated.
        /// This cuts down on image loading and thumbnailing.
        /// </summary>
        private static Dictionary<ListViewItem, int> thumbLoads = new Dictionary<ListViewItem, int>();

        /// John Boero 15-APR-2007 <summary>
        /// Draws a ListViewItem's icon.
        /// </summary>
        /// <param name="item"> ListViewItem whose icon to draw. </param>
        /// <param name="force"> Attributes to actively redraw. </param>
        /// <param name="reg"> Region to draw this icon. </param>
        private void DrawLargeIcon(ListViewItem lit, DrawAttrs force)
        {
            int txture = TextureBase + lit.ImageIndex;
            Image im = GetIconImage(LargeImageList, lit.ImageIndex);
            Rectangle reg = Rectangle.FromLTRB(
                lit.Position.X, lit.Position.Y,
                lit.Position.X + im.Size.Width, lit.Position.Y + im.Size.Height);

            if (thumbLoads.ContainsKey(lit))
                txture = thumbLoads[lit];
            else
            {
                ShellItem shIt = lit.Tag as ShellItem;
                string ext = Path.GetExtension(shIt.Path).ToLower();

                // Manual thumbnail icons pose hazard if images are large...
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png"
                    || ext == ".gif" || ext == ".bmp")
                {
                    Size icSize = im.Size;
                    im = Image.FromFile(shIt.Path);
                    float aspect = (float)im.Height / im.Width;
                    if (aspect <= 1)
                        im = im.GetThumbnailImage(icSize.Width, (int)(icSize.Height * aspect), null, IntPtr.Zero);
                    else
                        im = im.GetThumbnailImage((int)(icSize.Width / aspect), icSize.Height, null, IntPtr.Zero);
                    
                    Gl.glGenTextures(1, out txture);
                    thumbLoads.Add(lit, txture);
                }
            }

            if (Gl.glIsTexture(txture) == 0)
                RenderState.ImageToTexture(txture, im, false);

            im.Dispose();

            if ((force & (DrawAttrs.IconColor | DrawAttrs.Position)) != 0)
            {
                int iconDL = lit.Index + GetDisplayList(DisplayListType.Icon);

                Gl.glNewList(iconDL, Gl.GL_COMPILE);
                if (lit.Selected)
                {
                    Gl.glUseProgramObjectARB(prIconSelected);
                    if (Focused)
                        SetUniformColor(prIconSelected, "fc", highlight);
                    else if (!HideSelection)
                        SetUniformColor(prIconSelected, "fc", SystemColors.HotTrack);
                    else
                        Gl.glUseProgramObjectARB(prIcon);
                }
                else
                    Gl.glUseProgramObjectARB(prIcon);

                RenderState.TexturedRect(txture, reg);

                Gl.glEndList();
            }
        }

        /// John Boero 15-APR-2007 <summary>
        /// Allow us to customize icon handling.
        /// </summary>
        /// <param name="list">Optional ImageList.</param>
        /// <param name="icon">Index into whatever image scheme we use.</param>
        /// <returns>The image to convert into a texture.</returns>
        protected virtual Image GetIconImage(ImageList list, int icon)
        {
            Icon ic = Icon.FromHandle(
                ImageList_GetIcon(ShellImageList.LargeImageList, icon, 1));
            return ic.ToBitmap();
        }

        /// John Boero 13-OCT-2007 <summary>
        /// Set the forecolor and backcolor of our text shaders.
        /// Note: multicolored text is not supported - this includes ClearType anti-aliasing.
        /// </summary>
        /// <param name="forecolor">Color to shade text with.</param>
        /// <param name="backcolor">Color to shade background.  Typically clear or highlight.</param>
        protected void ShaderColors(Color forecolor, Color backcolor)
        {
            SetUniformColor(prLabelSelected, "fc", forecolor);
            SetUniformColor(prLabelSelected, "bc", backcolor);
        }

        /// John Boero 13-OCT-2007 <summary>
        /// Set a uniform shader variable on from a System.Drawing.Color.
        /// Precondition: shader is compiled and linked successfully.
        /// </summary>
        /// <param name="program">Program name (number) of the desired shader.</param>
        /// <param name="uniform">Name of the uniform variable to set.</param>
        /// <param name="val">vec4 uniform value as color.</param>
        private void SetUniformColor(int program, string uniform, Color val)
        {
            int uniformLoc = Gl.glGetUniformLocationARB(program, uniform);
            if (uniformLoc != -1)
                Gl.glUniform4f(uniformLoc,
                    (float)(val.R / 255f),
                    (float)(val.G / 255f),
                    (float)(val.B / 255f),
                    (float)(val.A / 255f));
            else
                throw new ApplicationException("Unfound uniform: " + uniform);
        }

        /// John Boero 15-APR-2007 <summary>
        /// Set the animation timer's tick handler to RenderFrame.
        /// It sets the draw delegate (drawDelegate) and triggers a refresh.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void RenderFrame(object sender, EventArgs e)
        {
            drawDelegate = ReadyDraw;
            Refresh();
            Wgl.wglSwapBuffers(hDC);
        }

        /// John Boero 13-OCT-2007 <summary>
        /// This is used as the OnPaint when an actual draw is not scheduled.
        /// </summary>
        private void NullDraw()
        {
        }

        /// <summary>
        /// Track working area of screen in case size/taskbar changes.
        /// </summary>
        private static Rectangle workArea = Screen.PrimaryScreen.WorkingArea;

        /// JLB <summary> 
        /// Set drawDelegate to this for a refresh at the next OnPaint.
        /// </summary>
        /// <remarks> This delegate replaces busy branch in OnPaint. </remarks>
        private void ReadyDraw()
        {
            // Did workarea change?  Most likely by moving/resising taskbar?
            if (workArea != Screen.PrimaryScreen.WorkingArea)
            {
                int dX = Screen.PrimaryScreen.WorkingArea.X - workArea.X;
                int dY = Screen.PrimaryScreen.WorkingArea.Y - workArea.Y;
                foreach (ListViewItem lit in Items)
                {
                    lit.Position = new Point(lit.Position.X + dX, lit.Position.Y + dY);
                    DrawTaoItemDL(lit, DrawAttrs.Position);
                }
                workArea = Screen.PrimaryScreen.WorkingArea;
            }

            lock (RenderState.TextureImages)
            {
                while (RenderState.TextureImages.Count > 0)
                {
                    // Must use enumerator for removing pairs.
                    Dictionary<int, Image>.Enumerator enummer = RenderState.TextureImages.GetEnumerator();
                    if (enummer.MoveNext())
                    {
                        KeyValuePair<int, Image> texPair = enummer.Current;
                        RenderState.ImageToTexture(texPair.Key, texPair.Value, GlobalSettings.Default.CompressTextures);
                        RenderState.TextureImages.Remove(texPair.Key);
                    }
                }
            }

            // This solution is necessary because scroll events aren't enough.
            scrollPosTail.X = GetScrollPos(Handle, 0) + (ClientSize.Width - this.Width);
            scrollPosTail.Y = GetScrollPos(Handle, 1) + (ClientSize.Height - this.Height);

            if (scrollPosTail != scrollPos)
            {
                scrollPos = scrollPosTail;
                BuildItemList(DrawAttrs.Position);
            }


            // Setup list.
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            if (RenderBackground != null)
                RenderBackground(++frame);

            // Item list
            Gl.glCallList(GetDisplayList(DisplayListType.MasterList));

            // Draw selection box?
            if (dragSelectStatus != null)
            {
                if (SelectBoxDisplayList == 0)
                {
                    Gl.glEnable(Gl.GL_BLEND);
                    Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);
                    Gl.glColor4f(0.25f, 0.25f, 0.25f, 0.25f);
                    Gl.glBegin(Gl.GL_QUADS);
                    Gl.glVertex2f(dragSelectStatus.X, dragSelectStatus.Y);
                    Gl.glVertex2f(dragSelectStatus.X, Cursor.Position.Y);
                    Gl.glVertex2f(Cursor.Position.X, Cursor.Position.Y);
                    Gl.glVertex2f(Cursor.Position.X, dragSelectStatus.Y);
                    Gl.glEnd();
                }
                else
                    Gl.glCallList(SelectBoxDisplayList);
            }

            drawDelegate = NullDraw;
        }

        /// <summary>
        /// Gets or sets the display list # called for rendering selection box.
        /// Setting to zero uses system default.
        /// </summary>
        public int SelectBoxDisplayList
        {
            get
            {
                return sbDL;
            }
            set
            {
                sbDL = value;
            }
        }

        /// <summary>
        /// Optional display list for selection box rendering.
        /// </summary>
        private int sbDL = 0;

        int oldHash = 0;
        bool positioned = false;
        /// John Boero 30-NOV-2008 <summary> 
        /// <summary>
        /// Redraw icons when CWD is changed.
        /// </summary>
        public void DirChanged()
        {
            int newHash = /*Items.GetHashCode() */ Items.Count;
            // JLB rudimentary find shell icon positions if possible.
            if (!positioned)
            {
                Dictionary<string, Point> locs = Mawenzy.Util.DesktopIcs.GetDesktop();
                Options.ApplyIconPositions(locs);
                positioned = true;
            }
            if (newHash != oldHash && inited)
            {
                BuildItemList(DrawAttrs.All);
                oldHash = newHash;
            }
        }
        #endregion

        #region Overrides
        /// John Boero 15-APR-2007 <summary>
        /// Resize the control should not happen often.
        /// </summary>
        /// <param name="sender"> Ignored. </param>
        /// <param name="e"> Ignored. </param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            aspect = (Height > 0) ? (float)Width / Height : 1;

            // Don't resize the context if we don't have it yet.
            if (Wgl.wglGetCurrentContext() == IntPtr.Zero)
                return;

            if (Height == 0)
                Height = 1;

            Gl.glViewport(0, 0, Width, Height);
            BuildItemList(DrawAttrs.MasterList | DrawAttrs.Position);
        }

        /// John Boero 06-JUL-2008 <summary>
        /// Passively rebuilds the items display list and removes autoelipsis from selected item.
        /// </summary>
        /// <remarks> This replaces previous sloppy OnSelectedIndexChanged. </remarks>
        /// <param name="e"> Item being selected or unselected. </param>
        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem oldMain = null;

            base.OnItemSelectionChanged(e);

            // Unellipse primary selection.
            if (e.IsSelected)
            {
                if (mainItem != null)
                    oldMain = mainItem;

                mainItem = e.Item;

                if (oldMain != null)
                    DrawTaoItemDL(oldMain, DrawAttrs.LabelAll);
            }
            else if (e.Item == mainItem)
                mainItem = null;

            DrawTaoItemDL(e.Item, DrawAttrs.IconColor | DrawAttrs.LabelAll);
        }

        /// John Boero 13-OCT-2007 <summary>
        /// Rebuilds with disabled highlight.
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            // Should unelipse text here.
            base.OnLostFocus(e);

            foreach (ListViewItem selItem in SelectedItems)
                DrawTaoItemDL(selItem, DrawAttrs.IconColor | DrawAttrs.LabelAll);
        }

        /// John Boero 13-OCT-2007 <summary>
        /// When in doubt, rebuild item list.
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            foreach (ListViewItem selItem in SelectedItems)
                DrawTaoItemDL(selItem, DrawAttrs.IconColor | DrawAttrs.LabelAll);
        }

        /// John Boero 15-APR-2007 <summary>
        /// Calls the current drawDelegate.  It may be NullDraw or ReadyDraw.
        /// </summary>
        /// <remarks>This is more efficient than branching (if ready, draw, etc).</remarks>
        /// <param name="e">Ignored.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            drawDelegate();
        }

        /// John Boero 13-OCT-2007 <summary>
        /// Make sure to stop the animator timer on destroy.
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            animator.Stop();
            base.OnHandleDestroyed(e);
        }

        /// John Boero 15-APR-2007 <summary>
        /// Rebuilds list after a change in font color (ForeColor).
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            BuildItemList(DrawAttrs.IconColor | DrawAttrs.LabelColor);
        }

        /// John Boero 30-NOV-2008 <summary>
        /// Rebuilds list after a change in font color (ForeColor).
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            //JLB BuildItemList(DrawAttrs.IconColor | DrawAttrs.LabelColor);
        }

        /// John Boero 15-APR-2007 <summary>
        /// Stop animating if disabled.
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (animating)
            {
                if (base.Enabled)
                    animator.Start();
                else
                    animator.Stop();
            }

            base.OnEnabledChanged(e);
        }

        /// John Boero 13-OCT-2007 <summary>
        /// Just in case using system colors, rebuild for change in SystemColors.
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            BuildItemList(DrawAttrs.IconColor | DrawAttrs.LabelColor);
        }

        /// John Boero 15-APR-2007 <summary>
        /// Stop animating for invisible windows.
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (animating)
            {
                if (base.Visible)
                    animator.Start();
                else
                    animator.Stop();
            }

            base.OnVisibleChanged(e);
        }

        /// John Boero 15-APR-2007 <summary>
        /// Gets or sets the font used to draw textures.
        /// </summary>
        public override Font Font
        {
            set
            {
                base.Font = textLabel.Font = value;
                BuildItemList(DrawAttrs.LabelText);
            }
        }

        /// John Boero 13-OCT-2007 <summary>
        /// Stores the item being label edited to hide its label texture.
        /// </summary>
        /// <param name="e"> Item going into label edit. </param>
        /// <todo> Figure out why background disappears when editing last item. </todo>
        protected override void OnBeforeLabelEdit(LabelEditEventArgs e)
        {
            labelEditingItem = Items[e.Item];
            base.OnBeforeLabelEdit(e);

            if (!e.CancelEdit)
                DrawLabel(Items[e.Item], DrawAttrs.LabelAll);
            else // Unable to rename this item?
                labelEditingItem = null;
        }

        /// John Boero 13-OCT-2007 <summary>
        /// Reset the item being label edited to unhide its texture.
        /// </summary>
        /// <param name="e"> Item coming out of label edit. </param>
        /// <todo> Figure out why redraw is always autosized... </todo>
        protected override void OnAfterLabelEdit(LabelEditEventArgs e)
        {
            base.OnAfterLabelEdit(e);
            labelEditingItem = null;

            DrawLabel(Items[e.Item], DrawAttrs.LabelAll);
        }

        /// John Boero 15-APR-2007 <summary>
        /// This is how we prevent premature Tao initialization.
        /// </summary>
        /// <param name="e">Ignored.</param>
        protected override void OnParentVisibleChanged(EventArgs e)
        {
            if (Parent.Visible && !inited)
            {
                Init();
                inited = true;
            }
            if (animating)
            {
                if (Parent.Visible)
                    animator.Start();
                else
                    animator.Stop();
            }
        }

        /// <summary>
        /// Gets the mouse event args that started a drag selection.
        /// Null means there is no drag selection in progress.
        /// </summary>
        public MouseEventArgs DragSelectStatus
        {
            get
            {
                return dragSelectStatus;
            }
        }

        internal MouseEventArgs dragSelectStatus;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            dragSelectStatus = e;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            dragSelectStatus = null;
            base.OnMouseUp(e);
        }
        #endregion          

        #region Cleanup
        /// John Boero 15-APR-2007 <summary>
        /// Get rid of the rendering context.
        /// </summary>
        /// <param name="hrc">Ptr to HRC</param>
        protected void KillHRC(IntPtr hrc)
        {
            //if (prIconSelected != 0)
            //    Gl.glDeleteProgram(prIconSelected);
            //if (prLabel != 0)
            //    Gl.glDeleteProgram(prLabel);

            if (hrc != IntPtr.Zero)
            {                                            // Do We Have A Rendering Context?
                if (!Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero))
                    return;// throw new ApplicationException("Can't make RC current.");

                if (!Wgl.wglDeleteContext(hrc))
                    return;// throw new ApplicationException("Release Rendering Context Failed.");

                hRC = IntPtr.Zero;
            }
        }

        /// John Boero 15-APR-2007 <summary>
        /// Attempt proper disposal.
        /// </summary>
        /// <param name="disposing">Standard disposing flag.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Animate = false;
                drawDelegate = NullDraw;

                // Note: Manually destroying DC results in errors.

                KillHRC(hRC);
                base.Dispose(disposing);
            }
        }
        #endregion
    }
}
