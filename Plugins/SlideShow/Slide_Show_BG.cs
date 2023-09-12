using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Mawenzy;
using Mawenzy.Util;
using System.Windows.Forms;
using ShellDll;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using Mawenzy.Plugins;
using System.Threading;
using Mawenzy.Plugins.Properties;

namespace Mawenzy.Backgrounds
{
    public class Slide_Show_BG : PluginBase
    {
        /// JLB <summary>
        /// A Forms.Timer that rotates the selected background images.
        /// </summary>
        /// <remarks>
        /// Note the type of timer.  System.Windows.Forms.Timer will fire between renderings
        /// and avert context threading issues.
        /// </remarks>
        private System.Windows.Forms.Timer flipper;
        /// JLB <summary>
        /// List of background texture rectangles stored as Jumpers.
        /// </summary>
        private List<JumpRect> jumpers;
        /// JLB <summary>
        /// List used to select a picture file from user specified folder.
        /// </summary>
        private List<string> pics;
        /// JLB <summary>
        /// Store images in memory for threaded loading.
        /// </summary>
        private List<Image> loadedPics;
        /// JLB <summary>
        /// Randomized picture selection.
        /// </summary>
        private Random picIndexRand;
        /// JLB <summary>
        /// Index of current picture for rotation.
        /// </summary>
        private int picIndex = 0;

        /// JLB <summary>
        /// Construct a new slide show background plugin.
        /// </summary>
        public Slide_Show_BG()
        {
            flipper = new System.Windows.Forms.Timer();
            jumpers = new List<JumpRect>();
            loadedPics = new List<Image>();
            pics = new List<string>();
            picIndexRand = new Random();
            flipper.Tick += new EventHandler(FlipScreens);
        }

        /// JLB <summary>
        /// Build a list of supported images in the user specified folder.  Then build random jumper list.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FlipScreens(object sender, EventArgs e)
        {
            flipper.Stop();

            if (!Directory.Exists(PluginSettings.Default.SlideShowPath))
                PluginSettings.Default.SlideShowPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            foreach (string extension in PluginSettings.Default.SuppImageTypes)
                pics.AddRange(Directory.GetFiles(
                    PluginSettings.Default.SlideShowPath, extension, SearchOption.AllDirectories));

            // No pictures in folder.
            if (pics.Count == 0)
                return;

            Thread loader = new Thread(new ThreadStart(LoadImageThreaded));
            loader.IsBackground = true;
            loader.Priority = ThreadPriority.Lowest;
            loader.Start();

            // Get ready to delete old pictures.
            foreach (JumpRect jr in jumpers)
                jr.EventIn((uint)(5000f / PluginSettings.Default.SlideShowSpeed));
        }

        private void LoadImageThreaded()
        {
            for (int i = 0; i < Screen.AllScreens.Length; ++i)
            {
                if (PluginSettings.Default.SlideShow_rotationMode == "Random")
                    picIndex = picIndexRand.Next(pics.Count);
                else
                    picIndex = (picIndex + 1) % pics.Count;
                
                try
                {
                    loadedPics.Add(Image.FromFile(pics[picIndex]));
                    pics.RemoveAt(picIndex);
                }
                catch (Exception)
                {
                    // Ignoreage
                }
            }

            try
            {
                pics.Clear();
                Parent.Invoke(new JoinRenderThread(BuildJumpers));
            }
            catch (Exception)
            {
            }
        }

        private void BuildJumpers()
        {
            foreach (Screen scr in Screen.AllScreens)
            {
                // Somehow lost a screen since then?
                if (loadedPics.Count == 0)
                    break;

                Image img = loadedPics[0];

                float scale =
                    ((float)img.Width / img.Height > (float)scr.Bounds.Width / scr.Bounds.Height) ?
                    (float)scr.Bounds.Height / img.Height * 1.001f:
                    (float)scr.Bounds.Width / img.Width * 1.001f;
                JumpRect jumper = new JumpRect(img, 1000f / PluginSettings.Default.SlideShowSpeed,
                    scr.Bounds.Left + (scr.Bounds.Width / 2), // X
                    scr.Bounds.Top + (scr.Bounds.Height / 2), // Y
                    0,              // Z
                    0, 0, 0,        // Rotation
                    scale, scale, scale, 0);    // Scale, Alpha

                loadedPics.RemoveAt(0);
                jumper.FrameEvent += new Jumper.EventOnFrame(JumperExpire);
                jumper[JumpRect.Alpha] = 1;
                jumpers.Add(jumper);
            }

            flipper.Start();
        }

        /// JLB <summary>
        /// Once a texture fades out, remove it from the list and dispose to delete its texture.
        /// </summary>
        /// <param name="sender">JumpRect that has faded out.</param>
        private void JumperExpire(Jumper sender)
        {
            jumpers.Remove(sender as JumpRect);
            sender.Dispose();
        }

        #region PluginBase Members
        /// JLB <summary>
        /// Adds ourselves to Options.ActivePlugins by calling base.Activate and starts our timer.
        /// </summary>
        public override void Activate()
        {
            base.Activate();
            flipper.Start();
        }

        /// JLB <summary>
        /// Draws each frame.  Jumpers set up during FlipScreens.
        /// </summary>
        override public void Draw()
        {
            Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            foreach (Screen scrn in Screen.AllScreens)
            {
                Gl.glPushMatrix();
                // Note SetOrtho adjusts viewport to clamp each screen.
                // Future: tile effect option to span all screens.
                RenderState.SetOrtho(scrn.Bounds);
                Gl.glLoadIdentity();
                for (int i = 0; i < jumpers.Count; ++i)
                {
                    jumpers[i].Draw();
                    if (!jumpers[i].Advance())
                        --i;
                }
                Gl.glPopMatrix();
            }
            Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);
        }

        /// JLB <summary>
        /// Special thanks to Everaldo Coelho for the Crystal Clear icon set.
        /// </summary>
        override public Image OptionsIcon
        {
            get
            {
                return Resources.Crystal_Clear_app_desktopshare;
            }
        }

        /// JLB <summary>
        /// Gets options panel instance.
        /// </summary>
        public override Control ConfigControl
        {
            get { return new SlideShowConfig(); }
        }

        /// JLB <summary>
        /// Reads Mawenzy.Backgrounds.SlideShow.Settings.Default and applies settings to next timer tick.
        /// </summary>
        public override void ReadSettings()
        {
            PluginSettings.Default.Reload();
            flipper.Interval = PluginSettings.Default.SlideShowDuration * 1000;
            flipper.Start();
        }

        /// JLB <summary>
        /// Writes settings and applies speed instantly to each jumper.
        /// Note this is called when options dialog gets OK or Apply.
        /// </summary>
        public override void WriteSettings()
        {
            PluginSettings.Default.Save();

            flipper.Interval = PluginSettings.Default.SlideShowDuration * 1000;

            foreach (JumpRect jumper in jumpers)
                jumper.Speed = PluginSettings.Default.SlideShowSpeed;
        }

        /// JLB <summary>
        /// If no upper layer plugins handled a middle mouse click, do a manual swap of backgrounds.
        /// </summary>
        /// <param name="e">Ignored.</param>
        /// <returns>True if button was middle.</returns>
        public override bool HandleMouseClick(MouseEventArgs e)
        {
            // Did we get a middle button click anywhere?
            if (Parent.Focused && e.Button == MouseButtons.Middle)
            {
                FlipScreens(null, EventArgs.Empty);

                // Restart timer.
                flipper.Stop();
                flipper.Start();

                // Block lower layers from handling click.
                return true;
            }
            return false;
        }
        #endregion
    }
}
