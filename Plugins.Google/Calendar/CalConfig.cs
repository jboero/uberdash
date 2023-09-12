using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Properties;
using Mawenzy.Plugins.Google_Plugs.Properties;

namespace Mawenzy.Plugins.Google_Plugs.Calendar
{
    public partial class CalConfig : UserControl
    {
        public CalConfig()
        {
            InitializeComponent();
        }

        private void tbMarqueeSpeed_Scroll(object sender, EventArgs e)
        {
            labMarqueeSpeed.Text = String.Format(Resources.MarqueeSpeed,
                TimeSpan.FromMilliseconds(tbMarqueeSpeed.Value).ToString(),
                TimeSpan.FromMilliseconds(tbMarqueeSpeed.Maximum).ToString());
        }
    }
}
