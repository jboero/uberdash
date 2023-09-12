using System;
using System.Collections.Generic;
using System.Text;
using Mawenzy.Plugins;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using Mawenzy.Util;
using Tao.OpenGl;
using System.Diagnostics;
using Mawenzy.UI;
using Mawenzy.Plugins.Properties;
using Mawenzy.Config;

namespace Mawenzy.Feeds
{
    /// <summary>
    /// A plugin to load and show a news (or any) web page with the option to
    /// </summary>
    public class News : TickerTock
    {
        const int jumperSpeed = 8;
        const int blendQuality = 5;
        const int shutterSpeed = 10;

        private RenderState.Drawer drawer = RenderState.NullDraw;
        private NewsLayout stamp;
        private JumpRect browserJumper;
        internal Uri url;

        private bool jShown = false;

        internal bool Shown
        {
            get
            {
                return jShown;
            }
            set
            {
                if (value && !jShown)
                {
                    if (browserJumper == null)
                    {
                        browserJumper = new JumpRect(stamp, jumperSpeed,
                            -2000 * Parent.Aspect, -1000, -4000,
                            180, 0, 0,
                            1, 1, 1, 0);
                    }
                    else
                        browserJumper.SetTexture(stamp);

                    browserJumper[JumpRect.X] =
                        browserJumper[JumpRect.Y] = 0;
                    browserJumper[JumpRect.Alpha] = 1;
                    browserJumper[JumpRect.Z] = -1000;
                }
                else if (!value && jShown)
                {
                    browserJumper[JumpRect.X] = -2000 * Parent.Aspect;
                    browserJumper[JumpRect.Y] = -1000;
                    browserJumper[JumpRect.Z] = -4000;
                    browserJumper[JumpRect.Alpha] = 0.2f;

                }

                jShown = value;
            }
        }

        public News()
        {
            // Use the Mawenzy marquee when showing.
            ParentTicker = General_Options.MawenzyTicker;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            //QueueHide();

            if (browserJumper != null)
                browserJumper.Dispose();

            if (stamp != null)
                stamp.Dispose();

            browserJumper = null;
            stamp = null;
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            if (stamp != null)
            {
                lock (stamp)
                {
                    (sender as System.Windows.Forms.Timer).Stop();
                    //base.QueueHide();
                }
            }
        }

        private void ShowJumper()
        {
            Shown = true;
            Shown = false;
        }
       
        internal void BeginNewsLoad()
        {
            try
            {
                url = new Uri(PluginSettings.Default.NewsURL.Replace("{REGION}",
                    Mawenzy.Properties.GlobalSettings.Default.Region));

                stamp = new NewsLayout(this);
                stamp.Browser.ScrollBarsEnabled = false;
                stamp.Browser.Navigate(url);
                stamp.Browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Browser_DocumentCompleted);
            }
            catch (Exception ex)
            {
                ErrForm.Show(ex);
            }
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (browserJumper != null)
                browserJumper.Dispose();

            browserJumper = new JumpRect(stamp, jumperSpeed,
                -2000 * Parent.Aspect, -1000, -4000,
                180, 0, 0,
                1, 1, 1, 0);

            drawer = ActiveDraw;
        }

        private void ActiveDraw()
        {
            RenderState.SetPerspective(60f, Parent.Aspect, Parent.Bounds);

            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            //browserJumper.DrawWithMotionBlur(blendQuality, shutterSpeed);
            Gl.glDisable(Gl.GL_BLEND);
            browserJumper.Draw();
            browserJumper.Advance();
            Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);
        }

        public override void Draw()
        {
            drawer();
        }

        private int[] hits = new int[40];
        public override bool HandleMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && browserJumper != null)
            {
                RenderState.PrepSelectPerspect(ref hits, e.Location, Parent.Aspect);

                Gl.glPushName(1);
                browserJumper.Draw();
                Gl.glPopName();

                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glPopMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);

                int hitCount = Gl.glRenderMode(Gl.GL_RENDER);

                if (hitCount > 0 && stamp != null)
                {
                    stamp.NewsStrip.Show(e.Location);
                    return true;
                }
            }

            return false;
        }

        public override Control ConfigControl
        {
            get { return new NewsConfig(); }
        }

        public override Image OptionsIcon
        {
            get
            {
                return Resources.news;
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

        internal void Reset()
        {
            Shown = false;
            Shown = true;
        }

        public override List<Image> Fetch()
        {
            throw new NotImplementedException();
        }
    }
}
