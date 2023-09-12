using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;

namespace Mawenzy.Util
{
    public static class RenderState
    {
        internal static Dictionary<int, Image> TextureImages = new Dictionary<int, Image>();
        /// <summary>
        /// Builds and links a simple GLSL fragment shader.
        /// </summary>
        /// <param name="shaderSrc">String containing shader source.</param>
        /// <returns>Program name (number) of new shader.</returns>
        public static int BuildShader(string shaderSrc)
        {
            string[] shaderSources = new string[] { shaderSrc };
            int[] lengths = new int[] { shaderSrc.Length };
            int[] success = new int[shaderSources.Length];
            StringBuilder errs = null;
            int shader;
            int program;

            shader = Gl.glCreateShaderObjectARB(Gl.GL_FRAGMENT_SHADER_ARB);
            program = Gl.glCreateProgramObjectARB();

            Gl.glShaderSourceARB(shader, shaderSources.Length, shaderSources, lengths);
            Gl.glCompileShaderARB(shader);
            Gl.glGetObjectParameterivARB(shader, Gl.GL_OBJECT_COMPILE_STATUS_ARB, success);

            if (success[0] == 0)
            {
                errs = new StringBuilder(1024);
                Gl.glGetInfoLogARB(shader, errs.MaxCapacity, success, errs);
                throw new ApplicationException(errs.ToString());
            }
            else  // Link successfully compiled program.
            {
                Gl.glAttachObjectARB(program, shader);
                Gl.glLinkProgramARB(program);
                Gl.glGetObjectParameterivARB(program, Gl.GL_OBJECT_LINK_STATUS_ARB, success);

                if (success[0] == 0)
                {
                    errs = new StringBuilder(1024);
                    Gl.glGetInfoLogARB(program, errs.MaxCapacity, success, errs);
                    throw new ApplicationException(errs.ToString());
                }
            }
            return program;
        }

        /// <summary>
        /// Take an image from an ImageList and assign it a texture.
        /// </summary>
        /// <param name="texture">Texture name (number) indexing the ImageList imgs.</param>
        /// <param name="imgs">ImageList to use.  Typically this.LargeImageList in our case.</param>
        public static void ImageToTexture(int texture, Image img, bool compress)
        {
            Bitmap bmp = new Bitmap(img);
            BitmapData bitmapData = bmp.LockBits(
                Rectangle.FromLTRB(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // Use the glorious GL_TEXTURE_RECTANGLE_ARB instead of GL_TEXTURE_2D or mipmaps.
            Gl.glBindTexture(Gl.GL_TEXTURE_RECTANGLE_ARB, texture);

            if (compress)
                Gl.glTexImage2D(Gl.GL_TEXTURE_RECTANGLE_ARB, 0, Gl.GL_COMPRESSED_RGBA, 
                    bmp.Width, bmp.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            else
                Gl.glTexImage2D(Gl.GL_TEXTURE_RECTANGLE_ARB, 0, Gl.GL_RGBA, 
                    bmp.Width, bmp.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

            // These are all necessary to avoid memory constipation.
            bmp.UnlockBits(bitmapData);
            bmp.Dispose();
            img.Dispose();
        }

        /// <summary>
        /// Create a texture from a control one subcontrol at a time.
        /// This is necessary for correct transparency.
        /// </summary>
        /// <param name="texture">Texture target for image.</param>
        /// <param name="ctrl">Control to render into texture.</param>
        /// <param name="compress">Texture will be compressed if true.</param>
        public static void ImageToTexture(int texture, Control ctrl, bool compress)
        {
            Bitmap bmp = DrawControl(ctrl);
            ImageToTexture(texture, bmp, compress);
            bmp.Dispose();
        }

        /// <summary>
        /// When true, all textures will be compressed in hardware (if available).
        /// </summary>
        public static bool CompressTextures = false;

        /// <summary>
        /// Get a bitmap from a Control for texturing.  Useful for threaded layouts.
        /// </summary>
        /// <param name="ctrl">Control to draw.</param>
        /// <returns></returns>
        public static Bitmap DrawControl(Control ctrl)
        {
            Bitmap bmp = new Bitmap(ctrl.Bounds.Width, ctrl.Bounds.Height);
            Graphics gc = Graphics.FromImage(bmp);

            DrawControl(bmp, gc, ctrl, ctrl.Location);
            gc.Dispose();

            return bmp;
        }

        /// <summary>
        /// Draw a control to a bitmap based on type.
        /// Control.DrawToBitmap is not always transparency savvy.
        /// </summary>
        /// <param name="bmp">Image being drawn to.</param>
        /// <param name="gc">Graphics used to draw ctrl.  Should match size of bmp.</param>
        /// <param name="ctrl">Control to render into texture.</param>
        private static void DrawControl(Bitmap bmp, Graphics gc, Control ctrl, Point offset)
        {
            Rectangle localBounds = new Rectangle(offset, ctrl.Bounds.Size);

            if (ctrl is Panel || ctrl is ContainerControl)
            {
                // Recurse children backwards.
                for (int i = ctrl.Controls.Count - 1; i >= 0; --i)
                {
                    Control child = ctrl.Controls[i];
                    Point cp2 = FindLocation(child);
                    DrawControl(bmp, gc, child, cp2);
                }
            }
            else if (ctrl is PictureBox) // Draw picture
            {
                PictureBox pb = ctrl as PictureBox;
                if (pb.Image != null)
                    gc.DrawImage(pb.Image, localBounds);
            }
            else if (ctrl is Label) // Draw text
            {
                Label lb = ctrl as Label;
                Brush b = Brushes.White;
                Type bsType = typeof(Brushes);
                System.Reflection.PropertyInfo prop = bsType.GetProperty(ctrl.ForeColor.Name);

                if (prop != null)
                    b = prop.GetGetMethod().Invoke(null, new object[] { }) as Brush;

                gc.DrawString(lb.Text, lb.Font, b, localBounds);
            }
            else
            {
                Bitmap tmp = new Bitmap(ctrl.Width, ctrl.Height);
                ctrl.DrawToBitmap(tmp, ctrl.Bounds);
                gc.DrawImage(tmp, localBounds);
                tmp.Dispose();
            }
        }

        /// <summary>
        /// Child control location finder.
        /// PointToScreen and PointToClient are tricky without a visible form.
        /// </summary>
        /// <param name="ctrl">Control to find location within its parents.</param>
        /// <returns>True point of control within parents.</returns>
        private static Point FindLocation(Control ctrl)
        {
            Point p;
            for (p = ctrl.Location; ctrl.Parent != null; ctrl = ctrl.Parent)
                p.Offset(ctrl.Parent.Location);

            return p;
        }

        /// <summary>
        /// Sets a standard perspective matrix.
        /// </summary>
        /// <param name="fov">Field of View.</param>
        /// <param name="aspect">Aspect ratio.</param>
        public static void SetPerspective(float fov, float aspect, Rectangle bounds)
        {
            // Set up perspective
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glViewport(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            Glu.gluPerspective(fov, aspect, 1, 500000);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Aspect helper for generic Rectangle.
        /// </summary>
        /// <param name="region">Rectangle to get aspect ratio of.</param>
        /// <returns>Height / Width or safe value of 1.</returns>
        public static float GetAspect(Rectangle region)
        {
            return (region.Height > 0) ? (float)region.Width / region.Height : 1;
        }

        /// <summary>
        /// Sets a projection to orthographic screen coordinates.
        /// </summary>
        /// <param name="height"> Height of screen. </param>
        /// <param name="width"> Width of screen</param>
        public static void SetOrtho(Rectangle bounds)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glViewport(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
            Gl.glOrtho(bounds.Left, bounds.Right, bounds.Bottom, bounds.Top, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Nobody likes to draw textured quads mannually every time.
        /// Draw rectangles at screen origin top left using positive x,y values.
        /// Note: this is meant to be used in the screen coordinate modelview, not the background.
        /// </summary>
        /// <param name="texture">Texture name (number) to map to this quad.</param>
        /// <param name="reg"> Region to draw texture (in orthographic screen coords).</param>
        public static void TexturedRect(int texture, Rectangle reg)
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_RECTANGLE_ARB, texture);
            // JLB Texture clamping seems to have no effect.
            //Gl.glTexParameteri(Gl.GL_TEXTURE_RECTANGLE_ARB, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            //Gl.glTexParameteri(Gl.GL_TEXTURE_RECTANGLE_ARB, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0, reg.Height);
            Gl.glVertex2f(reg.Left, reg.Bottom);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex2f(reg.Left, reg.Top);
            Gl.glTexCoord2f(reg.Width, 0);
            Gl.glVertex2f(reg.Right, reg.Top);
            Gl.glTexCoord2f(reg.Width, reg.Height);
            Gl.glVertex2f(reg.Right, reg.Bottom);
            Gl.glEnd();
        }

        /// <summary>
        /// Light weight selection rectangle drawing.
        /// </summary>
        /// <param name="reg">Region of interest.</param>
        public static void Quad(Rectangle reg)
        {
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(reg.Left, reg.Bottom);
            Gl.glVertex2f(reg.Left, reg.Top);
            Gl.glVertex2f(reg.Right, reg.Top);
            Gl.glVertex2f(reg.Right, reg.Bottom);
            Gl.glEnd();
        }

        /// <summary>
        /// Prepare selection render state without allocating a hit buffer.
        /// </summary>
        /// <param name="hitBuffer"> Pre-allocated hit buffer. </param>
        /// <param name="p"> Point of interest. </param>
        /// <param name="region"> Area of selection for p.  Required for coordinate conversion.</param>
        public static void PrepSelectOrtho(ref int[] hits, Point p, Rectangle region)
        {
            int[] viewport = new int[4];

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
            Gl.glSelectBuffer(hits.Length, hits);
            Gl.glRenderMode(Gl.GL_SELECT);
            Gl.glInitNames();

            p.Y += viewport[3] - region.Height;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPickMatrix(p.X - 1, viewport[3] - p.Y - 1, 3, 3, viewport);
            Gl.glOrtho(p.X - 1, p.X + 1, p.Y - 1, p.Y + 1, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Prepare selection render state without allocating a hit buffer.
        /// </summary>
        /// <param name="hitBuffer"> Pre-allocated hit buffer. </param>
        /// <param name="target"> Region of interest. </param>
        /// <param name="region"> Area of renderContext for p.  Required for coordinate conversion.</param>
        public static void PrepSelectOrtho(ref int[] hits, Rectangle target, Rectangle region)
        {
            int[] viewport = new int[4];

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
            Gl.glSelectBuffer(hits.Length, hits);
            Gl.glRenderMode(Gl.GL_SELECT);
            Gl.glInitNames();

            target.Y += viewport[3] - region.Height;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPickMatrix(
                target.Left, viewport[3] - target.Bottom, 
                target.Width, target.Height, 
                viewport);
            Gl.glOrtho(
                target.Left, target.Right, 
                target.Bottom, target.Top, 
                -1000, 1000);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Prepare a selection mode render state with the standard perspective.
        /// </summary>
        /// <param name="p">Point of interest.</param>
        /// <param name="aspect">Aspect of perspective.</param>
        /// <returns>Hit buffer.</returns>
        public static void PrepSelectPerspect(ref int[] hits, Point p, float aspect)
        {
            Rectangle rectPoint = Rectangle.FromLTRB(p.X - 2, p.Y - 2, p.X + 2, p.Y + 2);
            PrepSelectPerspect(ref hits, rectPoint, aspect);
        }

        /// <summary>
        /// Prepare a selection mode render state with the standard perspective.
        /// Note: Pushes projection matrix!
        /// </summary>
        /// <param name="p">Point of interest.</param>
        /// <param name="aspect">Aspect of perspective.</param>
        /// <returns>Hit buffer.</returns>
        public static void PrepSelectPerspect(ref int[] hits, Rectangle reg, float aspect)
        {
            int[] viewport = new int[4];

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
            Gl.glSelectBuffer(hits.Length, hits);
            Gl.glRenderMode(Gl.GL_SELECT);
            Gl.glInitNames();

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Glu.gluPickMatrix(reg.Left, viewport[3] - reg.Bottom, reg.Width, reg.Height, viewport);
            Glu.gluPerspective(60f, aspect, 1, 500000);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        private static float[] lAmbient = new float[] { 0.8f, 0.8f, 0.8f, 0.8f };
        private static float[] lDiffuse = new float[] { 1, 1, 1, 1 };
        private static float[] lPos = new float[] { 0, 1, 1, 0 };

        /// <summary>
        /// Sets up some basic lighting.
        /// </summary>
        public static void SetupBasicLighting()
        {
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, lAmbient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, lDiffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lPos);
        }

        /// <summary>
        /// To avoid constant branching in paint events, use this delegate to hold a draw routine.
        /// </summary>
        public delegate void Drawer();

        /// <summary>
        /// Parameterized drawer object for render context invocations.
        /// </summary>
        /// <param name="rcObj"></param>
        public delegate void DrawerWParam(object rcObj);

        /// <summary>
        /// Default for Drawers delegates.
        /// </summary>
        public static void NullDraw()
        {
        }
    }
}
