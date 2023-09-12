using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Plugins.Properties;
using Mawenzy.UI;
using System.Diagnostics;
using Mawenzy.Util;
using Mawenzy.Plugins;

namespace Mawenzy.Feeds
{
    public partial class RSSConfig : UserControl
    {
        public RSSConfig()
        {
            InitializeComponent();

            foreach (string feedURL in PluginSettings.Default.RSSAddressList)
            {
                Image icon = null;
                // TODO get icon.

                dgvFeeds.Rows.Add(icon, feedURL);
            }
        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = tbAddress.Text.Length > 0;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRem.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Image icon = null;

                // TODO find actual icon (if any).

                Uri uri = new Uri(tbAddress.Text.Trim());
                dgvFeeds.Rows.Add(icon, uri.ToString());
                PluginSettings.Default.RSSAddressList.Add(uri.ToString());
                tbAddress.Text = String.Empty;
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.RSS_Invalid_NoChannel, ex));
            }
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selecteds = dgvFeeds.SelectedRows;
            try
            {
                foreach (DataGridViewRow row in selecteds)
                {
                    string feed = row.Cells[1].Value.ToString();
                    // Too bad ListView can't bind to a StringCollection setting.
                    if (PluginSettings.Default.RSSAddressList.Contains(feed))
                        PluginSettings.Default.RSSAddressList.Remove(feed);

                    dgvFeeds.Rows.Remove(row);
                }
            }
            catch (Exception)
            {
            }
        }

        private void tbAddress_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tbAddress_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
                tbAddress.Text = (string)e.Data.GetData(typeof(string));
        }

        private void tbAddress_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvFeeds_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                tbAddress.Text = (string)e.Data.GetData(typeof(string));
                btnAdd_Click(null, EventArgs.Empty);
            }
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Safety.LaunchURL(Resources.URLUberdashRSSPolicy);
        }
    }
}
