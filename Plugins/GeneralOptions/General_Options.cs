using System;
using System.Collections.Generic;
using System.Text;
using Mawenzy.Util;
using System.Windows.Forms;
using Tao.OpenGl;
using Mawenzy.Plugins.Properties;
using ShellDll;
using System.Drawing;
using Mawenzy.UI;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using Microsoft.Win32;
using Mawenzy.Properties;
using Mawenzy.Plugins;
using System.Diagnostics;
using System.IO;

namespace Mawenzy.Config
{
    public class General_Options : Ticker
    {
        static public General_Options singleton;
        /// <summary>
        /// Gets singleton Mawenzy Ticker instance of General_Options.
        /// </summary>
        static public Ticker MawenzyTicker
        {
            get
            {
                return singleton;
            }
        }

        /// <summary>
        /// Check assembly signature.  Warn if this is not an official build.
        /// </summary>
        public General_Options()
        {
            singleton = this;

            Assembly appAssembly = Assembly.GetEntryAssembly();
            AssemblyName appName = appAssembly.GetName();
            byte[] signature = appName.GetPublicKey();

            // Developer mode expiration and signature check (optional)
            if (signature != null || GlobalSettings.Default.DeveloperModeOK < DateTime.Today)
                return;

            new WarnDevelopers().Show(Parent);
        }

        /// JLB <summary>
        /// Use MawenzyConfig for configuration in options window.
        /// </summary>
        public override System.Windows.Forms.Control ConfigControl
        {
            get
            {
                return new MawenzyConfig();
            }
        }

        /// JLB <summary>
        /// Use Uberdash icon.
        /// </summary>
        public override System.Drawing.Image OptionsIcon
        {
            get
            {
                return Mawenzy.Plugins.Properties.Resources.uberdash_32;
            }
        }

        public override void WriteSettings()
        {
            // Get ErrorMode
            GlobalSettings.Default.Save();

            // Apply frame rate.
            GlobalSettings.Default.FPS = (int)PluginSettings.Default.FPS;
            Parent.MaxFrameRate = GlobalSettings.Default.FPS;
        }

        public override void ReadSettings()
        {
            GlobalSettings.Default.Reload();

            // Apply frame rate.
            GlobalSettings.Default.FPS = (int)PluginSettings.Default.FPS;
            Parent.MaxFrameRate = GlobalSettings.Default.FPS;
        }
    }
}
