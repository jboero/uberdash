using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Properties;
using Mawenzy.Util;
using Mawenzy.Plugins.GooglePlugins;

namespace Mawenzy.Plugins.Google_Plugs.Weather
{
    public partial class WeatherLayout : UserControl
    {
        public WeatherLayout()
        {
            InitializeComponent();
        }

        private void cmWeather_Opening(object sender, CancelEventArgs e)
        {
            locationToolStripMenuItem.Text = String.Format(
                "Location: {0}", GlobalSettings.Default.Region);
        }

        private void openGoogleWeatherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Safety.LaunchURL(GoogleSettings.Default.WeatherURL.Replace(
                "{REGION}", GlobalSettings.Default.Region));
        }
    }
}
