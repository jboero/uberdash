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
    public partial class MouseInputConfigger : UserControl
    {
        public MouseInputConfigger()
        {
            InitializeComponent();

            cbButton.Items.Clear();
            cbButton.Items.AddRange(Enum.GetNames(typeof(MouseButtons)));

            cbModifier.Items.Clear();
            cbModifier.Items.AddRange(new string[]{
                Keys.None.ToString(),
                Keys.Alt.ToString(),
                Keys.Control.ToString(),
                Keys.Shift.ToString()});

            AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        [Browsable(true)]
        [SettingsBindable(true)]
        public MouseButtons Button
        {
            get
            {
                try
                {
                    return (MouseButtons)Enum.Parse(typeof(MouseButtons), cbButton.Text);
                }
                catch (Exception)
                {
                    return MouseButtons.None;
                }
            }
            set
            {
                try
                {
                    cbButton.Text = value.ToString();
                }
                catch (Exception)
                {
                    cbButton.Text = "None";
                }
            }
        }

        [Browsable(true)]
        [SettingsBindable(true)]
        public Keys Modifiers
        {
            get
            {
                try
                {
                    return (Keys)Enum.Parse(typeof(Keys), cbModifier.Text);
                }
                catch (Exception)
                {
                    return Keys.None;
                }
            }
            set
            {
                try
                {
                    cbModifier.Text = value.ToString();
                }
                catch (Exception)
                {
                    cbModifier.Text = Keys.None.ToString();
                }
            }
        }

        private void cbModifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindings["Modifiers"].WriteValue();
        }
    }
}
