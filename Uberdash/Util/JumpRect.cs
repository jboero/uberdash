using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tao.OpenGl;
using System.Windows.Forms;

namespace Mawenzy.Util
{
    /// <summary>
    /// A simple abastraction of taking a 2D graphic and placing it in a 3D texture.
    /// Allows smooth motion, rotation, color tinting, and RAM/VRAM managent.
    /// </summary>
    /// <remarks>
    /// TODO: This should be easy enough to adopt for VBOs some day..
    /// </remarks>
    public class JumpRect : Jumper, ICloneable
    {
        /// <summary>
        /// A class to help JumpRects handle customized mouse events.
        /// </summary>
        public class ClickBundle
        {
            private object jumperArgs;
            public delegate bool JumperClickHandle(MouseEventArgs mouseArgs, object jumperArgs);
            private JumperClickHandle handler;

            public ClickBundle(object menuArgs, JumperClickHandle menuShower)
            {
                jumperArgs = menuArgs;
                handler = menuShower;
            }

            public bool Show(MouseEventArgs mouseArgs)
            {
                if (handler != null)
                    return handler(mouseArgs, jumperArgs);

                return false;
            }
        }

        protected ClickBundle clickHandler;

        private AnchorStyles anchor = AnchorStyles.None;

        /// <summary>
        /// The anchor of origin coordinates for drawing.  Default is center.
        /// </summary>
        public AnchorStyles Anchor
        {
            get
            {
                return anchor;
            }
            set
            {
                if ((anchor = value) == AnchorStyles.None)
                {
                    bounds = new Rectangle(Location.X - (bounds.Width / 2), Location.Y - (bounds.Height / 2), bounds.Height, bounds.Width);
                    return;
                }

                int halfH = bounds.Height / 2;
                int halfW = bounds.Width / 2;
                if ((anchor & AnchorStyles.Left) == AnchorStyles.Left)
                    bounds = new Rectangle(Location.X + halfW, bounds.Y, bounds.Width, bounds.Height);
                if ((anchor & AnchorStyles.Top) == AnchorStyles.Top)
                    bounds = new Rectangle(Location.X, Location.Y + halfH, bounds.Width, bounds.Height);
                if ((anchor & AnchorStyles.Right) == AnchorStyles.Right)
                    bounds = new Rectangle(Location.X - halfW, bounds.Y, bounds.Width, bounds.Height);
                if ((anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                    bounds = new Rectangle(Location.X, Location.Y - halfH, bounds.Width, bounds.Height);
            }
        }

        /// <summary>
        /// Gets or sets a ClickBundle for this jumper to use.
        /// </summary>
        public ClickBundle ClickHandler
        {
            get
            {
                return clickHandler;
            }
            set
            {
                clickHandler = value;
            }
        }

        /// <summary>
        /// Texture number inside the OpenGL context.
        /// </summary>
        protected int Tex = 0;
        protected Rectangle bounds;
        protected string imagePath = null;

        /// <summary>
        /// Axis array indexers for standard JumpRect.
        /// </summary>
        public const int
            X = 0,
            Y = 1,
            Z = 2,
            S = 3,
            T = 4,
            U = 5,
            ScaleX = 6,
            ScaleY = 7,
            ScaleZ = 8,
            Alpha = 9;

        /// <summary>
        /// Gets the path to this image.
        /// </summary>
        public string ImagePath
        {
            get { return imagePath; }
        }

        /// <summary>
        /// Gets the bounds of this JumpRect.  Must match texture size.
        /// </summary>
        public Rectangle Bounds
        {
            get { return bounds; }
        }

        /// <summary>
        /// Gets or sets the offset of the rectangle when drawing.  Centered by default.
        /// </summary>
        public Point Location
        {
            get
            {
                return bounds.Location;
            }
            set
            {
                bounds.Location = value;
            }
        }

        public float Aspect
        {
            get
            {
                return (float)bounds.Height / bounds.Width;
            }
        }

        protected JumpRect()
        {
        }

        /// <summary>
        /// Special constructor without image.  Should not be used except by sub classes.
        /// </summary>
        /// <param name="speed"> Speed of transitions for this JumpRect. </param>
        /// <param name="dimensions"> Initial dimensions.  Should have 10 for JumpRect. </param>
        protected JumpRect(float speed, params float[] dimensions) 
            : base(speed, dimensions)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texImage"></param>
        /// <param name="speed"></param>
        /// <param name="dimensions">XYZ θΦα ScaleX ScaleY ScaleZ Alpha</param>
        public JumpRect(Image texImage, float speed, params float[] dimensions)
            : this(speed, dimensions)
        {
            Gl.glGenTextures(1, out this.Tex);

            bounds = new Rectangle(new Point(-texImage.Width / 2, -texImage.Height / 2), texImage.Size);
            RenderState.ImageToTexture(Tex, texImage, RenderState.CompressTextures);
            texImage.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texControl"></param>
        /// <param name="speed"></param>
        /// <param name="dimensions">XYZ θΦα ScaleX ScaleY ScaleZ Alpha</param>
        public JumpRect(Control texControl, float speed, params float[] dimensions)
            : this(speed, dimensions)
        {
            int availableTex;
            Gl.glGenTextures(1, out availableTex);
            Tex = availableTex;

            SetTexture(texControl);
        }

        /// <summary>
        /// Sets this jumpers texture without actually recreating it.
        /// </summary>
        /// <param name="texControl"></param>
        public void SetTexture(Image image)
        {
            Gl.glDeleteTextures(1, ref Tex);
            bounds = new Rectangle(new Point(-image.Width / 2, -image.Height / 2), image.Size);
            RenderState.ImageToTexture(Tex, image, RenderState.CompressTextures);
        }

        /// <summary>
        /// Sets this jumpers texture without actually recreating it.
        /// </summary>
        /// <param name="texControl"></param>
        public void SetTexture(Control texControl)
        {
            Gl.glDeleteTextures(1, ref Tex);
            RenderState.ImageToTexture(Tex, texControl, RenderState.CompressTextures);
            bounds = new Rectangle(new Point(-texControl.Width / 2, -texControl.Height / 2), texControl.Size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texImage"></param>
        /// <param name="compress"></param>
        /// <param name="speed"></param>
        /// <param name="dimensions">XYZ θΦα ScaleX ScaleY ScaleZ Alpha</param>
        public JumpRect(Image texImage, bool compress, float speed, params float[] dimensions)
            : base(speed, dimensions)
        {
            int availableTex;
            Gl.glGenTextures(1, out availableTex);
            Tex = availableTex;

            bounds = new Rectangle(new Point(texImage.Width / 2, texImage.Height / 2), texImage.Size);
            RenderState.ImageToTexture(Tex, texImage, RenderState.CompressTextures);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="speed"></param>
        /// <param name="dimensions">XYZ θΦα ScaleX ScaleY ScaleZ Alpha</param>
        public JumpRect(string imageFile, float speed, params float[] dimensions)
            : this(Image.FromFile(imageFile), speed, dimensions)
        {
            imagePath = imageFile;
        }
        
        /// <summary>
        /// Standard, single-pass drawring.
        /// </summary>
        public virtual void Draw()
        {
            Gl.glColor4f(1, 1, 1, base[Alpha]);
            DrawColorless();
        }

        /// JLB <summary>
        /// Unified standard Draw and Advance.  Helpful in loops.
        /// </summary>
        /// <remarks>
        /// Preferred to branching in every Draw: if (advance) advance();
        /// </remarks>
        public virtual void DrawWithAdvance()
        {
            Draw();
            Advance();
        }

        /// JLB <summary>
        /// Draw this jumper without modifying color state (alpha).
        /// </summary>
        public virtual void DrawColorless()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(base[X], base[Y], base[Z]);
            Gl.glRotatef(base[S], 1, 0, 0);
            Gl.glRotatef(base[T], 0, 1, 0);
            Gl.glRotatef(base[U], 0, 0, 1);
            Gl.glScalef(base[ScaleX], base[ScaleY], base[ScaleZ]);
            Gl.glNormal3d(0, 0, 1);

            RenderState.TexturedRect(Tex, bounds);
            Gl.glPopMatrix();
        }

        /// <summary>
        /// Draw a JumpRect with manual region and UV texture coords.  Handy for Ortho projections.
        /// Scale, rotation, position will be ignored.
        /// </summary>
        /// <param name="reg">Rectangle for specified vertices. </param>
        /// <param name="uv">Rectangle for UV texture coords.</param>
        public virtual void DrawManualUV(Rectangle reg, Rectangle uv)
        {
            Gl.glPushMatrix();
            Gl.glColor4f(1, 1, 1, base[Alpha]);
            Gl.glNormal3d(0, 0, 1);
            Gl.glBindTexture(Gl.GL_TEXTURE_RECTANGLE_ARB, Tex);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(uv.Left, uv.Top);
            Gl.glVertex2f(reg.Left, reg.Bottom);
            Gl.glTexCoord2f(uv.Left, uv.Bottom);
            Gl.glVertex2f(reg.Left, reg.Top);
            Gl.glTexCoord2f(uv.Right, uv.Bottom);
            Gl.glVertex2f(reg.Right, reg.Top);
            Gl.glTexCoord2f(uv.Right, uv.Top);
            Gl.glVertex2f(reg.Right, reg.Bottom);
            Gl.glEnd();
            Gl.glPopMatrix();
        }

        /// JLB <summary>
        /// Unified DrawColorless and Advance.  Helpful for loops.
        /// </summary>
        /// <remarks>
        /// Preferred to branching in every Draw: if (advance) advance();
        /// </remarks>
        public virtual void DrawColorlessWithAdvance()
        {
            DrawColorless();
            Advance();
        }

        public virtual void DrawSelectMode()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(base[X], base[Y], base[Z]);
            Gl.glRotatef(base[S], 1, 0, 0);
            Gl.glRotatef(base[T], 0, 1, 0);
            Gl.glRotatef(base[U], 0, 0, 1);
            Gl.glScalef(base[ScaleX], base[ScaleY], base[ScaleZ]);
            RenderState.Quad(bounds);
            Gl.glPopMatrix();
        }

        /// JLB <summary>
        /// Poor man's motion blur.  Should probably be done on the GPU.
        /// </summary>
        /// <param name="quality"> Indirectly controls passes to render motion blur with.  Should be between 1 and 20 or so. </param>
        public virtual void DrawWithMotionBlur(float quality, float shutterSpeed)
        {
            float 
                x = base[X],
                y = base[Y],
                z = base[Z],
                s = base[S],
                t = base[T],
                u = base[U],
                sx = base[ScaleX],
                sy = base[ScaleY],
                sz = base[ScaleZ],
                a = base[Alpha],

                qFactor = quality * shutterSpeed,

                dx = (matrix[X, 1] - x) / qFactor,
                dy = (matrix[Y, 1] - y) / qFactor,
                dz = (matrix[Z, 1] - z) / qFactor,
                //dsx = (matrix[ScaleX, 1] - matrix[ScaleX, 0]) / qFactor,
                //dsy = (matrix[ScaleY, 1] - matrix[ScaleY, 0]) / qFactor,
                //dsz = (matrix[ScaleZ, 1] - matrix[ScaleZ, 0]) / qFactor,
                drx = (matrix[S, 1] - matrix[S, 0]) / qFactor,
                dry = (matrix[T, 1] - matrix[T, 0]) / qFactor,
                drz = (matrix[U, 1] - matrix[U, 0]) / qFactor,
                //dsc = 1 + (matrix[ScaleX, 1] - matrix[ScaleX, 0]) / qFactor,
                da = a / quality * 10;

            // Poor man's motion blur.
            Gl.glPushMatrix();
            Gl.glTranslatef(x, y, z);
            Gl.glRotatef(s, 1, 0, 0);
            Gl.glRotatef(t, 0, 1, 0);
            Gl.glRotatef(u, 0, 0, 1);
            Gl.glNormal3f(0, 0, 1);
            Gl.glColor4f(1, 1, 1, a);
            Gl.glScalef(sx, sy, sz);

            for (int i = (int)-quality; i < (int)quality; ++i)
            {
                float factor = (quality - Math.Abs(i)) / quality;
                float alpha = factor * da * a / 2;
                Gl.glTranslatef(dx, -dy, dz);
                
                Gl.glRotatef(drx, 1, 0, 0);
                Gl.glRotatef(dry, 0, 1, 0);
                Gl.glRotatef(drz, 0, 0, 1);
                //Gl.glScalef(dsc, dsc, dsc);
                Gl.glColor4f(1, 1, 1, alpha);

                RenderState.TexturedRect(Tex, bounds);
            }
            Gl.glPopMatrix();
        }

        public override void Dispose()
        {
            Gl.glDeleteTextures(1, ref Tex);
            base.Dispose();
        }

        public override string ToString()
        {
            return String.Format("{0}, x:{1} y:{2} z:{3} a:{4}", 
                bounds.ToString(), this[X], this[Y], this[Z], this[Alpha]);
        }

        #region ICloneable Members
        /// <summary>
        /// Clone jumpers with shared texture.
        /// </summary>
        /// <returns> A copy of this. </returns>
        public object Clone()
        {
            JumpRect jr = new JumpRect();
            jr.bounds = this.bounds;
            jr.Tex = this.Tex;
            jr.matrix = this.matrix.Clone() as float[,];

            return jr;
        }
        #endregion
    }
}
