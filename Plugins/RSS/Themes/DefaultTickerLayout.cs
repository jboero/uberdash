using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Util;

namespace Mawenzy.Feeds.Themes
{
    internal partial class DefaultTickerLayout : UserControl
    {
        public DefaultTickerLayout()
        {
            InitializeComponent();
        }

        private void tsLink_Click(object sender, EventArgs e)
        {
            if (tsLink.Tag != null)
                Safety.LaunchURLwAds(tsLink.Tag.ToString());
        }

        private void tsRSS_Click(object sender, EventArgs e)
        {
            if (tsRSS.Tag != null)
                Safety.LaunchURL(tsRSS.Tag.ToString());
        }
    }
}
