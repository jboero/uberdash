using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Mawenzy;
using Mawenzy.Util;
using System.Windows.Forms;
using ShellDll;
using System.IO;
using Mawenzy.Plugins;
using System.Drawing;
using Mawenzy.Plugins.Properties;

namespace Mawenzy.Toys
{
    public class Clock : PluginBase
    {
        /// <summary>
        /// Background and hands as JumpRects.
        /// </summary>
        private JumpRect bg, sHand, mHand, hHand;

        private Jumper camera;

        private DateTime lastDT;

        /// <summary>
        /// Construct a clock plugin instance.
        /// NOTE do not use OpenGL here: 
        /// 1. The plugin might not be enabled and/or
        /// 2. Rendering context might not be established yet.
        /// </summary>
        public Clock()
        {
        }

        #region PluginBase Members
        public override void Activate()
        {
            /// Create a custom JumpGrad for a faux camera position.  eye[XYZ], to[XYZ]
            camera = new Jumper(40, 0, 0, 0, 0, 0, 0);

            camera[2] = -2000;
            camera[3] = 1000;
            camera[4] = 500;

            bg = new JumpRect(Resources.default_clock, 50, 0, 0, 0, 0, 0, 0, 3, 3, 3, 1);
            sHand = new JumpRect(Resources.clock_hand,  6, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0.5f);
            sHand.Location = new Point(sHand.Location.X, 0);
            
            //mHand = sHand.Clone() as JumpRect;
            mHand = new JumpRect(Resources.clock_hand, 6, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0.5f);
            mHand.Location = new Point(mHand.Location.X, 0);
            
            //hHand = sHand.Clone() as JumpRect;
            hHand = new JumpRect(Resources.clock_hand, 6, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0.5f);
            hHand.Location = new Point(hHand.Location.X, 0);

            sHand[JumpRect.ScaleX] = 0.4f;
            hHand[JumpRect.ScaleY] = 0.5f;
            hHand.Speed = 40;
            mHand.Speed = 30;
            sHand[JumpRect.Alpha] =
                mHand[JumpRect.Alpha] =
                hHand[JumpRect.Alpha] = 0.75f;

            // Add ourselves to the active list through base.Activate()
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            if (sHand != null)
            {
                sHand.Dispose();
                mHand.Dispose();
                hHand.Dispose();
                bg.Dispose();

                sHand = mHand = hHand = bg = null;
            }
        }

        override public void Draw()
        {
            if (lastDT.Second != DateTime.Now.Second)
            {
                lastDT = DateTime.Now;
                bg.Force(JumpRect.Alpha, 0.8f);
                bg[JumpRect.Alpha] = 0.6f;
            }

            sHand[JumpRect.U] = 6 * lastDT.Second;
            mHand[JumpRect.U] = 6 * lastDT.Minute + (lastDT.Second / 10f);
            hHand[JumpRect.U] = 30 * lastDT.Hour + (lastDT.Minute / 10f);

            bg.Advance();
            hHand.Advance();
            mHand.Advance();
            sHand.Advance();
            camera.Advance();
            
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Util.RenderState.SetPerspective(60, Parent.Aspect, Parent.Bounds);
            Glu.gluLookAt(camera[0], camera[1], camera[2], camera[3], camera[4], camera[5], 0, 1, 0);
            Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            Gl.glEnable(Gl.GL_BLEND);
            
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);
            bg.Draw();

            Gl.glColor3f(0.1f, 0.35f, 0.5f);
            hHand.Draw();
            Gl.glColor3f(1, 1, 1);
            mHand.Draw();
            sHand.DrawWithMotionBlur(8, 0.9f);

            Gl.glDisable(Gl.GL_BLEND);
            Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            Gl.glPopMatrix();

            bg.Advance();
        }

        public override Image OptionsIcon
        {
            get
            {
                return Mawenzy.Plugins.Properties.Resources.Crystal_Clear_app_xclock;
            }
        }

        public override void ReadSettings()
        {
            PluginSettings.Default.Reload();
        }

        public override void WriteSettings()
        {
            PluginSettings.Default.Save();
        }

        public override Control ConfigControl
        {
            get { return new ClockConfig(); }
        }
        #endregion
    }
}
