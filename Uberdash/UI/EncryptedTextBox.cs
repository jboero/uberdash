using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Properties;

namespace Mawenzy.UI
{
    public partial class EncryptedTextBox : TextBox
    {
        public EncryptedTextBox() : base()
        {
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (Modified)
                Text = Util.Encoder.Encrypt(base.Text, GlobalSettings.Default.MasterKey);

            base.OnValidating(e);
        }

        /** /
        protected override void OnValidated(EventArgs e)
        {
            if (Modified)
            {
                Text = Util.Encoder.Encrypt(base.Text, GlobalSettings.Default.MasterKey);
                base.OnTextChanged(EventArgs.Empty);
            }

            base.OnValidated(e);
        }
        /**/
    }
}
