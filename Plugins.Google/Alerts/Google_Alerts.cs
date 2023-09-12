using System;
using System.Collections.Generic;
using System.Text;
using Mawenzy.Plugins;
using Mawenzy.Plugins.Google_Plugs.Properties;
using Mawenzy.Plugins.Google_Plugs.Alerts;
using Google.GData.Client;
using System.Windows.Forms;

namespace Mawenzy.Plugins.Google_Plugs
{
    public class Google_Alerts : TickerTock
    {
        public Google_Alerts()
        {
        }

        public override List<System.Drawing.Image> Fetch()
        {
            throw new NotImplementedException();
        }

        public override System.Drawing.Image OptionsIcon
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Windows.Forms.Control ConfigControl
        {
            get { throw new NotImplementedException(); }
        }
    }
}
