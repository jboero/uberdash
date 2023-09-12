using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;
using System.Diagnostics;
using Mawenzy.Plugins.Properties;
using Raccoom.Xml;
using Mawenzy.Util;
using Tao.OpenGl;
using Mawenzy.UI;
using Mawenzy.Plugins;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using Mawenzy.Config;
using Mawenzy.Properties;

namespace Mawenzy.Feeds
{
    public partial class RSS_Reader : TickerTock
    {
        #region Fields
        /// <summary>
        /// Themeable layout for RSS items.
        /// </summary>
        private Themes.DefaultTickerLayout layout = null;

        /// <summary>
        /// Random generator for random rotation mode.
        /// </summary>
        private Random rssRandomIndex = null;

        private int rssIndex = 0;
        #endregion

        /// <summary>
        /// Construct a RSS_Reader instance and 
        /// </summary>
        public RSS_Reader()
        {
        }

        public override void Activate()
        {
            ParentTicker = General_Options.MawenzyTicker;
            layout = new Themes.DefaultTickerLayout();
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            if (layout != null)
                layout.Dispose();
            layout = null;
        }

        /// <summary>
        /// Use GPL RSS feed icon retrieved from wiki.
        /// </summary>
        public override Image OptionsIcon
        {
            get
            {
                return Resources.rss;
            }
        }

        /// <summary>
        /// Just load Mawenzy.Plugins.RSS.Settings
        /// </summary>
        public override void ReadSettings()
        {
            PluginSettings.Default.Reload();
        }

        /// <summary>
        /// Just save Mawenzy.Plugins.RSS.Settings
        /// </summary>
        public override void WriteSettings()
        {
             PluginSettings.Default.Save();
        }

        public override List<Image> Fetch()
        {
            int tocks = 0;
            StringCollection feeds = PluginSettings.Default.RSSAddressList;
            List<Image> res = new List<Image>();
            if (feeds.Count <= 0)
                return res;

            // TODO: develop some artistic talent and hammer out theme selection.
            string feed = feeds[rssIndex++ % feeds.Count];
            Feeds.Themes.DefaultTickerLayout cookieCutter = layout as Themes.DefaultTickerLayout;
            Regex regex = new Regex(@"\<\!\[CDATA\[(?<text>[^\]]*)\]\]\>", RegexOptions.None);
            string htmlPattern = @"<(.|\n)*?>";
            RssChannel chan = new RssChannel(new Uri(feed), null);

            foreach (RssItem blip in chan.Items)
            {
                // - Annoying when people put HTML in RSS/XML feeds.
                // If you wanted HTML, you should have used HTML pages instead of RSS...
                // .NET 3.0 added HTML formatting tools, but why require 3.0?  Que Atom :-)
                Match title = regex.Match(blip.Title);
                if (title.Success)
                    cookieCutter.labTitle.Text =
                        chan.Title + ": " + regex.Match(blip.Title).Groups["text"].Value;
                else
                    cookieCutter.labTitle.Text = chan.Title + ": " + blip.Title;

                Match regexMatch = regex.Match(blip.Description);

                if (regexMatch.Success)
                    cookieCutter.labDesc.Text = Regex.Replace(
                        regex.Match(blip.Description).Groups["text"].Value,
                        htmlPattern, String.Empty);
                else 
                    cookieCutter.labDesc.Text = blip.Description;

                cookieCutter.labDate.Text = blip.PubDate.ToString();
                cookieCutter.Size = new Size(cookieCutter.labDesc.PreferredWidth + 360, cookieCutter.Height);

                Image img = RenderState.DrawControl(cookieCutter);
                img.Tag = new JumpRect.ClickBundle(new string[] { chan.Link, blip.Link }, ShowLink);
                res.Add(img);

                if (++tocks >= PluginSettings.Default.RSS_MaxItems)
                    break;
            }

            return res;
        }

        private bool ShowLink(MouseEventArgs e, object args)
        {
            if (e.Button == PluginSettings.Default.StickerMouseButton)
            {
                string[] argStr = args as string[];
                if (argStr == null)
                    return false;

                layout.tsRSS.Text = argStr[0];
                layout.tsRSS.Tag = argStr[0];
                layout.tsLink.Text = argStr[1];
                layout.tsLink.Tag = argStr[1];

                layout.cmRSSItem.Show(e.Location);
            }
            return false;
        }

        /// <summary>
        /// Get an RSSConfig to display settings.
        /// </summary>
        public override Control ConfigControl
        {
            get
            {
                return new RSSConfig();
            }
        }

        /// <summary>
        /// If using Uberdash as an RSS subscriber, the args will pop in here during a subscription.
        /// </summary>
        /// <param name="args">Possibly an RSS feed URI or two.</param>
        /// <returns>True iff these were RSS feeds.</returns>
        public override bool HandleArgs(string[] args)
        {
            bool rss = true;

            foreach (string feed in args)
            {
                // HttpWebRequest will barf on us if we don't change feed:// to http://
                // ... jerk.
                if (!feed.StartsWith("feed://"))
                    rss = false;
                else
                    PluginSettings.Default.RSSAddressList.Add(
                        feed.Replace("feed://", "http://"));
            }

            return rss;
        }
    }
}
