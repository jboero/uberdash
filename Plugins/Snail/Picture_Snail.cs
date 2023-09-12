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

namespace Mawenzy.Toys
{
    public class Picture_Snail : PluginBase
    {
        private const float depthShear = 4650f;

        private List<JumpRect> allJumpers = null;
        private List<JumpRect> ringJumpers = null;

        public Picture_Snail()
        {
            allJumpers = new List<JumpRect>();
            ringJumpers = new List<JumpRect>();
        }

        private void jumper_AfterExpire(Jumper sender)
        {
            JumpRect jr = sender as JumpRect;

            allJumpers.Remove(jr);

            if (ringJumpers.Contains(jr))
                ringJumpers.Remove(jr);

            sender.Dispose();
            Shuffle();
        }

        #region PluginBase Members

        override public void Draw()
        {
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            RenderState.SetPerspective(60f, Parent.Aspect, Parent.Bounds);

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            for (int i = 0, ip = allJumpers.Count + 1; i < allJumpers.Count; ++i, --ip)
            {
                if (PluginSettings.Default.SnailBlurQuality == 1)
                    allJumpers[i].Draw();
                else
                {
                    float blur = Math.Max(2, (float)PluginSettings.Default.SnailBlurQuality / ip);
                    allJumpers[i].DrawWithMotionBlur(blur, 10f);
                }

                if (!allJumpers[i].Advance())
                    --i;
            }

            Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            Gl.glPopMatrix();
        }

        override public void HandleSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            string path = ShellItem.GetRealPath(e.Item.Tag as ShellItem);
            string extension = Path.GetExtension(path).ToLower();

            if (e.IsSelected && PluginSettings.Default.SuppImageTypes.Contains("*" + extension))
            {
                ListViewItem lvi = e.Item;
                ShellItem shItem = lvi.Tag as ShellItem;
                string imagePath = ShellItem.GetRealPath(shItem);

                // Picture not there any more?
                if (!File.Exists(imagePath))
                    return;

                JumpRect newJumper = new JumpRect(imagePath, 14, // TODO uncomment Parent.MaxFrameRate / 6f,
                    (((float)lvi.Position.X / Parent.Width) - 0.5f) * Parent.Aspect * depthShear + 100, // X
                    -(((float)lvi.Position.Y / Parent.Height) - 0.5f) * depthShear - 80, // Y
                    -4000, // Z 
                    -90,   // S
                    100,   // T
                    180,   // U
                    0, 0, 0, 0); // scale, alpha

                newJumper.FrameEvent += new Jumper.EventOnFrame(jumper_AfterExpire);

                for (int i = (int)PluginSettings.Default.SnailMaxPics; i <= allJumpers.Count; ++i)
                    HideJumper(e, allJumpers[allJumpers.Count - i]);

                allJumpers.Add(newJumper);
                ringJumpers.Add(newJumper);

                Shuffle();

                newJumper[JumpRect.S] = 0;
                newJumper[JumpRect.T] = 160;
                newJumper[JumpRect.Alpha] = 1;
            }
            else
                foreach (JumpRect jumper in allJumpers)
                    if (jumper.ImagePath == path || !File.Exists(jumper.ImagePath))
                        HideJumper(e, jumper);
        }

        private void HideJumper(ListViewItemSelectionChangedEventArgs e, JumpRect jumper)
        {
            if (ringJumpers.Contains(jumper))
                ringJumpers.Remove(jumper);

            if (e != null && Parent.Items.Contains(e.Item))
            {
                jumper[JumpRect.X] = ((float)e.Item.Position.X / Parent.Width - 0.5f) * Parent.Aspect * depthShear;
                jumper[JumpRect.Y] = -((float)e.Item.Position.Y / Parent.Height - 0.5f) * depthShear - 80;
                jumper[JumpRect.Z] = -4000;
                jumper[JumpRect.S] = -80;
                jumper[JumpRect.T] = 110;
                jumper[JumpRect.U] = 180;
                jumper[JumpRect.ScaleX] =
                jumper[JumpRect.ScaleY] =
                jumper[JumpRect.ScaleZ] = 0;
            }

            jumper[JumpRect.Alpha] = 0;

            //jumper.GoHome();  This doesn't work for moved items.
            jumper.EventIn(50);
        }

        private void Shuffle()
        {
            float increment = 1f / allJumpers.Count;
            float rank = 0;

            // Special case for just one.
            if (ringJumpers.Count == 1)
            {
                JumpRect only = ringJumpers[0];
                only[JumpRect.X] =
                only[JumpRect.Y] = 0;
                only[JumpRect.Z] = -700;
                only[JumpRect.ScaleX] =
                    only[JumpRect.ScaleY] =
                    only[JumpRect.ScaleZ] = 500f / only.Bounds.Width;
            }
            else  // Arrange others in ring.
                for (int i = 0; i < ringJumpers.Count; ++i)
                {
                    JumpRect jr = ringJumpers[i];

                    float alpha = (float)Math.Cos(5f * rank);
                    float theta = (float)Math.Sin(5f * rank);
                    float scale = 500f / jr.Bounds.Width / (ringJumpers.Count - i);

                    jr[JumpRect.X] = (250 * alpha) + 150;
                    jr[JumpRect.Y] = (250 * theta) + 100;
                    jr[JumpRect.Z] = -800;
                    jr[JumpRect.ScaleX] =
                    jr[JumpRect.ScaleY] =
                    jr[JumpRect.ScaleZ] = scale;

                    rank += increment;
                }
        }

        int[] hits = new int[40];
        public override bool HandleMouseClick(MouseEventArgs e)
        {
            // Feature - allow config of button for poor saps without middle button...
            if (e.Button == MouseButtons.Middle)
            {
                RenderState.PrepSelectPerspect(ref hits, e.Location, Parent.Aspect);

                for (int i = ringJumpers.Count - 1; i >= 0; --i)
                {
                    Gl.glPushName(i);
                    ringJumpers[i].Draw();
                    Gl.glPopName();
                }

                if (Gl.glRenderMode(Gl.GL_RENDER) > 0)
                {
                    // Scoot topmost image forward.
                    JumpRect clicked = ringJumpers[hits[3]];
                    allJumpers.Remove(clicked);
                    ringJumpers.Remove(clicked);
                    allJumpers.Add(clicked);
                    ringJumpers.Add(clicked);
                    Shuffle();
                    return true;
                }
            }
            return false;
        }

        public override bool HandleMouseWheel(MouseEventArgs e)
        {
            if (!PluginSettings.Default.SnailRotateOnMouseWheel || ringJumpers.Count < 2)
                return false;   // Pass event down to other plugins.

            if (e.Delta < 0)
            {
                JumpRect forward = ringJumpers[0];
                ringJumpers.Remove(forward);
                allJumpers.Remove(forward);
                ringJumpers.Add(forward);
                allJumpers.Add(forward);
            }
            else if (e.Delta > 0)
            {
                JumpRect backward = ringJumpers[ringJumpers.Count - 1];
                ringJumpers.Remove(backward);
                allJumpers.Remove(backward);
                ringJumpers.Insert(0, backward);
                allJumpers.Insert(0, backward);
            }

            Shuffle();
            return true;    // Stop event from descending other plugins.
        }

        public override Image OptionsIcon
        {
            get
            {
                return Mawenzy.Plugins.Properties.Resources.icon_snail;
            }
        }

        public override void ReadSettings()
        {
            PluginSettings.Default.Reload();
            while (allJumpers.Count > allJumpers.Capacity)
                allJumpers.RemoveAt(allJumpers.Count - 1);

            allJumpers.Capacity = (int)PluginSettings.Default.SnailMaxPics;
        }

        public override void WriteSettings()
        {
            PluginSettings.Default.Save();
        }

        public override Control ConfigControl
        {
            get { return new SnailConfig(); }
        }
        #endregion
    }
}
