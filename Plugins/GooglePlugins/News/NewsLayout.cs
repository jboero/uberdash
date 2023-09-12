using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mawenzy.UI;
using Mawenzy.Properties;
using System.IO;
using Mawenzy.Util;
using Mawenzy.Plugins;

namespace Mawenzy.Feeds
{
    public partial class NewsLayout : UserControl
    {
        private News plugInstance;
        public NewsLayout(News instance)
        {
            plugInstance = instance;
            InitializeComponent();
        }

        private void hideGoogleNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plugInstance.Shown = !plugInstance.Shown;
        }

        private void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Safety.LaunchURL(plugInstance.url.AbsoluteUri);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plugInstance.BeginNewsLoad();
        }

        private void NewsStrip_Opening(object sender, CancelEventArgs e)
        {
            hideGoogleNewsToolStripMenuItem.Text =
                String.Format("{0} Google news{1}",
                plugInstance.Shown ? "Hide" : "Show",
                    plugInstance.Shown ? String.Format(
                    " for {0} seconds.", PluginSettings.Default.NewsSwapInterval / 1000) : ".");
        }

        private void configureGoogleNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plugInstance.Deactivate();
        }

        private void builder_Tick(object sender, EventArgs e)
        {
            plugInstance.Shown = !plugInstance.Shown;
        }

        private void autoShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoShowToolStripMenuItem.Checked = !autoShowToolStripMenuItem.Checked;
        }
    }
}
