using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using System.Windows.Forms;

namespace Mawenzy.Toys
{
    class Instance
    {
        /// <summary>
        /// Current state of rotation, color, scale.
        /// </summary>
        private int seed;

        /// <summary>
        /// Quadric for drawing point cloud.
        /// </summary>
        internal static Glu.GLUquadric Quad;

        public Instance(int initialSeed)
        {
            this.seed = initialSeed;
        }

        /// <summary>
        /// Draw this 
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="smooth"></param>
        public void Draw(int detail, bool smooth, bool move)
        {
            double t = seed++ / 10.0;
            int revI = detail;

            // Do NOT enable this on older GPUs or performance will be abismal...
            if (smooth)
            {
                Gl.glEnable(Gl.GL_POINT_SMOOTH);
                Gl.glHint(Gl.GL_POINT_SMOOTH_HINT, Gl.GL_FASTEST);
            }
            Gl.glPushMatrix();

            if (move)
                Gl.glTranslated(Math.Sin(t / 20) * 400, Math.Cos(t / 30) * 240, Math.Sin(t / 50) * 400);

            Gl.glRotatef(Cursor.Position.X / 10.0f, 0, 1, 0);
            Gl.glRotatef(Cursor.Position.Y / 10.0f, 1, 0, 0);
            Gl.glRotated(t, 1, 0, 0);
            Gl.glRotated(t * 2, 0, 1, 0);
            Gl.glRotated(t, 0, 0, 1);

            for (int i = 0; i < detail; ++i, --revI)
            {
                Gl.glRotated(t, 1, 0, 0);
                Gl.glRotated(t, 0, 1, 0);
                Gl.glRotated(t * 2, 0, 0, 1);

                Gl.glPointSize(((float)Math.Sin((i - t) / 4) + 2) * 8);
                Gl.glColor4f(
                    ((float)Math.Sin((t + i) / 16f) + 1) / 3,
                    ((float)Math.Cos((t + i) / 10f) + 1) / 3,
                    ((float)Math.Cos((t + i) / 25f) + 1) / 3,
                    (float)i / detail);

                Gl.glPushMatrix();
                Gl.glScalef(100 + (revI * 10), 100 + (revI * 10), 100 + (revI * 10));
                Glu.gluSphere(Quad, 1, detail, detail);
                Gl.glPopMatrix();
            }

            Gl.glPopMatrix();
        }
    }
}
