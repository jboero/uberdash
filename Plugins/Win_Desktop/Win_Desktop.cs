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
using Mawenzy.Plugins.Properties;

namespace Mawenzy.Backgrounds
{
    public class Win_Desktop : PluginBase
    {
        /// <summary>
        /// Rectangle for wallpaper image, if applicable.
        /// </summary>
        private Rectangle wpRect;
        /// <summary>
        /// Direct enum mapping of WallpaperStyle in Registry
        /// </summary>
        private enum WallpaperStyle
        {
            None = -1,
            Center = 0,
            Tile = 1,
            Stretch = 2
        }
        /// <summary>
        /// Stores the user's chosen wallpaper style at time of load from registry.
        /// </summary>
        private WallpaperStyle wpStyle;
        /// <summary>
        /// Texture name of background image, if applicable.
        /// </summary>
        private int imgTexture = -1;

        /// <summary>
        /// Create a Win_Desktop instance that mocks the standard Windows desktop.
        /// </summary>
        public Win_Desktop()
        {
            // This is much quicker than reading it from the Registry.. 
            // even when you code that first out of ignorance.
            Parent.BackColor = SystemColors.Desktop;          
        }

        /// <summary>
        /// Tries to load wallpaper settings from registry.
        /// </summary>
        private void LoadWallpaper()
        {
            // This is much quicker than reading it from the Registry.. 
            // even when you code that first out of ignorance.
            Parent.BackColor = SystemColors.Desktop;

            try
            {
                // Wallpaper
                RegistryKey wpKey = Registry.CurrentUser.
                    OpenSubKey("Control Panel").
                    OpenSubKey("Desktop");
                string bgPath = wpKey.GetValue("Wallpaper") as string;
                int style = Convert.ToInt32(wpKey.GetValue("WallpaperStyle"));
                int tile = Convert.ToInt32(wpKey.GetValue("TileWallpaper"));

                if (File.Exists(bgPath))
                {
                    Image im = Image.FromFile(bgPath);

                    wpRect = new Rectangle(new Point(0, 0), im.Size);
                    Gl.glGenTextures(1, out imgTexture);
                    RenderState.ImageToTexture(imgTexture, im, Mawenzy.Properties.GlobalSettings.Default.CompressTextures);

                    if (style == 2)
                    {
                        wpStyle = WallpaperStyle.Stretch;
                        wpRect.Offset(-wpRect.Width / 2, -wpRect.Height / 2);
                    }
                    else if (tile == 1)
                        wpStyle = WallpaperStyle.Tile;
                    else
                    {
                        wpStyle = WallpaperStyle.Center;
                        wpRect.Offset(-wpRect.Width / 2, -wpRect.Height / 2);
                    }
                }
                else
                    wpStyle = WallpaperStyle.None;
            }
            catch (Exception ex)
            {
                throw new PluginException(this, Resources.ERR_WinDesktop, ex);
            }
        }

        #region PluginBase Members
        public override void Activate()
        {
            LoadWallpaper();
            base.Activate();
        }

        override public void Draw()
        {
            Gl.glColor3f(1, 1, 1);

            switch (wpStyle)
            {
                case WallpaperStyle.Stretch:
                    foreach (Screen scrn in Screen.AllScreens)
                    {
                        Gl.glPushMatrix();
                        RenderState.SetOrtho(scrn.Bounds);
                        Gl.glTranslatef((scrn.Bounds.Left + scrn.Bounds.Right) / 2,
                            (scrn.Bounds.Bottom + scrn.Bounds.Top) / 2, 0);
                        Gl.glScalef((float)scrn.Bounds.Width / (float)wpRect.Width,
                            (float)scrn.Bounds.Height / (float)wpRect.Height, 0);
                        Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
                        RenderState.TexturedRect(imgTexture, wpRect);
                        Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);
                        Gl.glPopMatrix();
                    }
                    break;
                case WallpaperStyle.Tile:
                    Gl.glPushMatrix();
                    RenderState.SetOrtho(Parent.Bounds);
                    Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
                    // Note GL_TEXTURE_WRAP doesn't work for GL_TEXTURE_RETANGLE_ARB.
                    // The only advantage here is correct multiple monitor support for large textures.
                    //Gl.glTexParameterf(Gl.GL_TEXTURE_RECTANGLE_ARB, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
                    //Gl.glTexParameterf(Gl.GL_TEXTURE_RECTANGLE_ARB, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);

                    Gl.glColor3f(1, 1, 1);
                    Gl.glBindTexture(Gl.GL_TEXTURE_RECTANGLE_ARB, imgTexture);
                    Gl.glBegin(Gl.GL_QUADS);
                    Gl.glTexCoord2f (Parent.Left,   Parent.Top);
                    Gl.glVertex2f   (Parent.Left,   Parent.Top);
                    Gl.glTexCoord2f (Parent.Left,   Parent.Bottom);
                    Gl.glVertex2f   (Parent.Left,   Parent.Bottom);
                    Gl.glTexCoord2f (Parent.Right,  Parent.Bottom);
                    Gl.glVertex2f   (Parent.Right,  Parent.Bottom);
                    Gl.glTexCoord2f (Parent.Right,  Parent.Top);
                    Gl.glVertex2f   (Parent.Right,  Parent.Top);
                    Gl.glEnd();

                    Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);
                    Gl.glPopMatrix();

                    break;
                case WallpaperStyle.Center:
                    // Draw centered on each screen.
                    foreach (Screen scrn in Screen.AllScreens)
                    {
                        RenderState.SetOrtho(scrn.Bounds);
                        Gl.glPushMatrix();
                        Gl.glTranslatef((scrn.Bounds.Left + scrn.Bounds.Right) / 2,
                            (scrn.Bounds.Bottom + scrn.Bounds.Top) / 2, 0);
                        Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
                        RenderState.TexturedRect(imgTexture, wpRect);
                        Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);

                        Gl.glPopMatrix();
                    }
                    break;
            }
        }

        override public Image OptionsIcon
        {
            get
            {
                return Mawenzy.Plugins.Properties.Resources.Crystal_Clear_app_tutorials;
            }
        }

        public override void WriteSettings()
        {
            PluginSettings.Default.Save();

            // Refresh with compression settings.
            if (Active)
                LoadWallpaper();
        }

        public override Control ConfigControl
        {
            get { return new WinDesktopConfig(); }
        }
        #endregion
    }
}
