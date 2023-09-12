using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Util;
using Mawenzy.Plugins.Google_Plugs.Properties;

namespace Mawenzy.Plugins.Google_Plugs.Calendar
{
    public partial class CalendarLayout : UserControl
    {
        public CalendarLayout()
        {
            InitializeComponent();
        }

        private void viewEventDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Safety.LaunchURL("https://www.google.com/calendar/");
        }

        private void addEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EventForm().Show();
        }
    }
}
