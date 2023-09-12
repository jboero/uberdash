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
    /// JLB <summary>
    /// Overlays most common on Windows XP and earlier, or older Macs and some Linux.
    /// Desktop overlays used by VLC, BSPlayer, hardware TV tuners, etc.
    /// Basically, the background is cleared with the overlay key color, showing any overlay behind.
    /// </summary>
    public class Overlay_Desktop : PluginBase
    {
        /// JLB <summary>
        /// Create a Overlay_Desktop instance that mocks the standard Windows overlay color.
        /// </summary>
        public Overlay_Desktop()
        {
            // This is much quicker than reading it from the Registry.. 
            // even when you code that first out of ignorance.
            Parent.BackColor = SystemColors.Desktop;
        }

        #region PluginBase Members
        override public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
        }

        override public Image OptionsIcon
        {
            get
            {
                return Mawenzy.Plugins.Properties.Resources.overlay;
            }
        }

        public override void WriteSettings()
        {
            PluginSettings.Default.Save();
            // JLB NOTE
            // Do NOT use glClearColorIiEXT despite how friendly it sounds.
            Gl.glClearColor(
                PluginSettings.Default.OverlayColor.R / 255f,
                PluginSettings.Default.OverlayColor.G / 255f,
                PluginSettings.Default.OverlayColor.B / 255f,
                PluginSettings.Default.OverlayColor.A / 255f);
        }

        public override void ReadSettings()
        {
            base.ReadSettings();
            // JLB NOTE
            // Do NOT use glClearColorIiEXT despite how friendly it sounds.
            Gl.glClearColor(
                PluginSettings.Default.OverlayColor.R / 255f,
                PluginSettings.Default.OverlayColor.G / 255f,
                PluginSettings.Default.OverlayColor.B / 255f,
                PluginSettings.Default.OverlayColor.A / 255f);
        }

        public override Control ConfigControl
        {
            get { return new OverlayDesktopConfig(); }
        }
        #endregion
    }
}
