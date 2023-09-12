using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Plugins.Properties;

namespace Mawenzy.Feeds
{
    public partial class NewsConfig : UserControl
    {
        public NewsConfig()
        {
            InitializeComponent();
            labDelay.Text = String.Format(Resources.LabRefresh, tbDelay.Value / 1000);
        }

        private void tbDelay_ValueChanged(object sender, EventArgs e)
        {
            labDelay.Text = String.Format(Resources.LabRefresh, tbDelay.Value / 1000);
        }
    }
}
