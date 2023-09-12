using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Mawenzy;
using Mawenzy.Util;
using System.Windows.Forms;
using ShellDll;
using System.IO;
using Mawenzy.Plugins;
using System.Drawing;
using System.Net;
using System.Threading;
using Mawenzy.UI;
using System.Diagnostics;
using Mawenzy.Plugins.Properties;
using Mawenzy.Config;

namespace Mawenzy.Feeds
{
    /// <summary>
    /// StockTICKER.  Special thanks to Yahoo for their über simple quote api.
    /// </summary>
    public class Yahoo_Stocks : TickerTock
    {
        /// <summary>
        /// Row-corresponding enum to CSV result columns.  Depends on LoadStickers GetYFinanc parameter.
        /// </summary>
        private enum CSVCols
        {
            Symbol,
            LastTrade,
            Change,
            Low,
            High,
            Open,
            CompanyName
        }

        /// <summary>
        /// Record for a symbol's data.
        /// </summary>
        private struct SymbolRec
        {
            public string symbol;
            public string company;
            public string lastTrade;
            public float low;
            public float change;
            public float high;
            public float open;
        }

        /// <summary>
        /// Single layout control for our textures and context menu.
        /// </summary>
        private StickerLayout cookieCutter;

        /// <summary>
        /// Construct and add ourselves to MarQ.
        /// </summary>
        public Yahoo_Stocks()
        {
        }

        /// <summary>
        /// Get data on a set of symbols.  Called in background thread.
        /// </summary>
        /// <remarks>
        /// Static internal in case verification is added in options dialog.
        /// </remarks>
        /// <param name="symbols">Symbols conforming to Yahoo specification separated by comma.</param>
        /// <param name="format">Which fields to obtain for each stock symbol.</param>
        /// <returns>CSV resulting data in one symbol per line format.</returns>
        internal static string GetYFinanc(string symbols, string format)
        {
            // Note: 
            // Ignore false warning that Uri constructor is deprecated.
            string addy = String.Format(
                PluginSettings.Default.StockURL, symbols, format);

            // JLB - Deprecation warning is bogus.
            // Claim is "don't escape" is always true.
            // Reality shows otherwise...  Don't let URI 
            // escape formatting.  It kills index carats (^IDX)
            #pragma warning disable
            Uri fetchAddr = new Uri(addy, true);
            #pragma warning enable

            WebRequest req = HttpWebRequest.Create(fetchAddr);
            
            // JLB Issue #6,7,8.  FINALLY - how intuitive that the
            // proxy bug solution makes absolutely no sense... sigh.
            WebRequest.DefaultWebProxy = null;
            StreamReader nameReader = new StreamReader(req.GetResponse().GetResponseStream());
            string result = nameReader.ReadToEnd();
            nameReader.BaseStream.Close();
            nameReader.Close();

            return result;
        }

        /// JLB <summary>
        /// Allocate collections and display lists.
        /// </summary>
        public override void Activate()
        {
            ParentTicker = General_Options.MawenzyTicker;
            cookieCutter = new StickerLayout();

            // Add ourselves to Ticker
            base.Activate();
        }

        public override Image OptionsIcon
        {
            get { return Mawenzy.Plugins.Properties.Resources.cc_yahoo_finance; }
        }

        public override void ReadSettings()
        {
            PluginSettings.Default.Reload();
        }

        public override void WriteSettings()
        {
            PluginSettings.Default.Save();
        }

        public override Control ConfigControl
        {
            get { return new StickerConfig(); }
        }

        /// <summary>
        /// Load stock data and build images from layout.
        /// </summary>
        /// <returns>List of drawn images for texture.</returns>
        public override List<Image> Fetch()
        {
            List<Image> res = new List<Image>();
            string symbolList = PluginSettings.Default.StickerSymbols.Replace("\r\n", ",");

            symbolList.Remove(symbolList.Length - 1, 1);

            string symList = symbolList.ToString();
            string[] yData = GetYFinanc(symList, "slcghon").Split('\n');

            // Symbol,LastTrade,Change,Low,High,Open,Name
            foreach (string rowText in yData)
            {
                if (rowText.Length < 1)
                    continue;

                SymbolRec stockRec;
                string[] attribs = rowText.Replace('"', ' ').Split(',');
                string change = attribs[(int)CSVCols.Change].Trim();
                change = change.Substring(0, change.IndexOf(' '));

                stockRec.lastTrade = attribs[(int)CSVCols.LastTrade];
                int boldIndex = stockRec.lastTrade.IndexOf("<b>") + 3;
                int boldEnd = stockRec.lastTrade.IndexOf("</b>") - boldIndex;
                stockRec.lastTrade = stockRec.lastTrade.Substring(boldIndex, boldEnd);

                stockRec.symbol = attribs[(int)CSVCols.Symbol].Trim();
                stockRec.low = (attribs[(int)CSVCols.Low] != "N/A") ?
                    Convert.ToSingle(attribs[(int)CSVCols.Low].Trim()) : 0;
                stockRec.change = Convert.ToSingle(change);
                stockRec.high = (attribs[(int)CSVCols.High] != "N/A") ?
                    Convert.ToSingle(attribs[(int)CSVCols.High].Trim()) : 0;
                stockRec.open = (attribs[(int)CSVCols.Open] != "N/A") ?
                    Convert.ToSingle(attribs[(int)CSVCols.Open].Trim()) : 0;
                stockRec.company = attribs[(int)CSVCols.CompanyName].Trim();

                cookieCutter.Arrow.Image = stockRec.change >= 0 ? Resources.up : Resources.down;
                cookieCutter.Company.Text = stockRec.company.ToString();
                cookieCutter.High.Text = stockRec.high.ToString();
                cookieCutter.LastTrade.Text = stockRec.lastTrade.ToString();
                cookieCutter.Low.Text = stockRec.low.ToString();
                cookieCutter.Open.Text = stockRec.open.ToString();
                cookieCutter.Symbol.Text = stockRec.symbol.ToString();
                cookieCutter.Change.Text = ((stockRec.change > 0) ? "+" : "") + stockRec.change.ToString();

                if (stockRec.change > 0)
                    cookieCutter.Change.ForeColor = Color.LightGreen;
                else if (stockRec.change < 0)
                    cookieCutter.Change.ForeColor = Color.Red;
                else
                    cookieCutter.Change.ForeColor = Color.White;

                Image img = RenderState.DrawControl(cookieCutter);
                img.Tag = new JumpRect.ClickBundle(stockRec, ShowStockMenu);
                res.Add(img);
            }

            return res;
        }

        /// <summary>
        /// Customize and show menu for each stock symbol.
        /// This required 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ShowStockMenu(MouseEventArgs e, object args)
        {
            if (e.Button == PluginSettings.Default.StickerMouseButton)
            {
                SymbolRec stockData = (SymbolRec)args;

                // Set description (disabled) text.
                cookieCutter.tsSymbol.Text = String.Format(
                    Resources.INFO_SymbolPrefix, stockData.symbol);

                // Set title of URL for user to see.
                cookieCutter.tsOpenLink.Text = String.Format(
                    Resources.INFO_SymbolOpen, String.Format(
                        PluginSettings.Default.StickerLinkFormat, stockData.symbol));

                // Set cmLink.Tag to the URL for launching.
                // See StickerLayout.openLink()
                cookieCutter.tsOpenLink.Tag = String.Format(
                    PluginSettings.Default.StickerLinkFormat, stockData.symbol);

                cookieCutter.cmLink.Show(e.Location);

                return true;
            }

            return false;
        }
    }
}
