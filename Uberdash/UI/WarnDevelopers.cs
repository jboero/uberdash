using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Properties;

namespace Mawenzy.UI
{
    public partial class WarnDevelopers : Form
    {
        public WarnDevelopers()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbIgnoreToday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIgnoreToday.Checked)
                GlobalSettings.Default.DeveloperModeOK = DateTime.Today;
        }
    }
}
