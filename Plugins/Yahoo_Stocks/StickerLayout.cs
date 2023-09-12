using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Util;

namespace Mawenzy.Feeds
{
    public partial class StickerLayout : UserControl
    {
        public StickerLayout()
        {
            InitializeComponent();
        }

        private void openLink(object sender, EventArgs e)
        {
            ToolStripMenuItem mitem = sender as ToolStripMenuItem;
            if (mitem != null && mitem.Tag != null)
                Safety.LaunchURLwAds(mitem.Tag.ToString());
        }
    }
}
