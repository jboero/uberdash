using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mawenzy.Backgrounds
{
    public partial class SlideShowConfig : UserControl
    {
        public SlideShowConfig()
        {
            InitializeComponent();
            numDuration.Value = trackDuration.Value;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text))
                dirBrowser.SelectedPath = txtPath.Text;

            if (dirBrowser.ShowDialog(this) == DialogResult.OK)
                txtPath.Text = dirBrowser.SelectedPath;
        }

        private void trackDuration_ValueChanged(object sender, EventArgs e)
        {
            if (sender is TrackBar)
                numDuration.Value = trackDuration.Value;
        }

        void numDuration_ValueChanged(object sender, System.EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                if (numDuration.Value <= trackDuration.Maximum)
                    trackDuration.Value = (int)numDuration.Value;
                else
                    trackDuration.Value = trackDuration.Maximum;
            }
        }
    }
}
