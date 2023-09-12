using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mawenzy.Plugins.Properties;
using System.Reflection;
using Mawenzy.Properties;
using System.IO;
using Mawenzy.UI;
using Mawenzy.Util;

namespace Mawenzy.Config
{
    public partial class MawenzyConfig : UserControl
    {
        public MawenzyConfig()
        {
            InitializeComponent();

            linkLab.Text = Assembly.GetEntryAssembly().FullName;

            if (GlobalSettings.Default.ErrorMode >= 0 
                && GlobalSettings.Default.ErrorMode < cbErrMode.Items.Count)
                cbErrMode.SelectedIndex = GlobalSettings.Default.ErrorMode;
        }

        private void linkLab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Safety.LaunchURL(Resources.URLUberdash);
        }

        private void cbErrMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Will not be saved until GlobalSettings.Save is called.
            GlobalSettings.Default.ErrorMode = cbErrMode.SelectedIndex;
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
