using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Mawenzy.Feeds
{
    public partial class StickerConfig : UserControl
    {
        public StickerConfig()
        {
            InitializeComponent();
            labDelay.Text = String.Format(
                "Delay between showings: ({0}s)", tbDelay.Value);
        }

        private void ColorChange(object sender, EventArgs e)
        {
            colorPicker.Color = (sender as Button).BackColor;
            if (colorPicker.ShowDialog(this) == DialogResult.OK)
                (sender as Button).BackColor = colorPicker.Color;
        }

        private void tbDelay_Scroll(object sender, EventArgs e)
        {
            labDelay.Text = String.Format(
                "Delay between showings: ({0}s)", tbDelay.Value);
        }
    }
}
