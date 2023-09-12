using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Properties;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using Mawenzy.Plugins;

namespace Mawenzy.UI
{
    public partial class ErrForm : Form
    {
        protected delegate void TattleToParent();

        internal static ErrForm instance;

        private Exception currErr = null;

        private Size normSize = new Size(720, 512);

        private static UberdashMain Backstage;

        private List<Exception> errList = new List<Exception>();

        private string stackTrace;

        internal Exception Error
        {
            get { return currErr; }
            set
            {
                lock (this)
                {
                    currErr = value;

                    if (currErr == null)
                        return;

                    if (currErr is PluginException)
                        pbPluginIcon.Image = (currErr as PluginException).Icon;
                    else
                        pbPluginIcon.Image = null;

                    stackTrace = currErr.StackTrace;
                    errList.Add(currErr);
                    Detail.Text = currErr.ToString();

                    Summary.Text = currErr.Message;

                    //for (Exception inner = currErr;
                    //    stackTrace == null && currErr.InnerException != null;
                    //    inner = inner.InnerException)
                    //    stackTrace = inner.StackTrace;

                    if (stackTrace != null)
                        ErrCode.Text = String.Format("{0,8:X8}",
                            stackTrace.GetHashCode()).Trim();
                    else
                        ErrCode.Text = "UNKNOWN";

                    Summary.Text = currErr.Message;

                    Text = String.Format("Error [{0}]: {1}", ErrCode.Text, Summary.Text);
                }
            }
        }

        internal static void Init(UberdashMain parent)
        {
            instance = new ErrForm();
            Backstage = parent;
        }

        /// <summary>
        /// Handles an error safely from most threads using the user's error setting.
        /// </summary>
        /// <param name="error"> Exception passed from plugin or core application. </param>
        public static void Show(Exception error)
        {
            if (Backstage == null)
                instance.Show();

            // Note thread lock in Error property.
            instance.Error = error;

            string message = error.Message;

            if (error.InnerException != null)
                message += "\r\n\r\n" + error.InnerException.Message;
            
            switch (GlobalSettings.Default.ErrorMode)
            {
                // Balloon tip.
                case 0:
                    Backstage.nicon.ShowBalloonTip(10000, error.HelpLink, message, ToolTipIcon.Info);
                    break;
                // Interactive dialog.
                case 1:
                    if (!instance.Visible)
                        Backstage.Invoke(new TattleToParent(ParentShow));
                    break;
                // Beep and log.
                case 2:
                    System.Media.SystemSounds.Exclamation.Play();
                    break;
            }

            string errSource = "UNKNONWN";
            if (error.Source != null)
                errSource = error.Source.Length > 24 ? error.Source.Substring(0, 24) : error.Source;

            Options.sTables.Errors.AddErrorsRow(DateTime.Now, errSource, error.StackTrace);
            // Note this needs to be written out at program quit...
        }

        private ErrForm()
        {
            InitializeComponent();

#if !DEBUG
            btnDebug.Visible = false;
#endif
        }

        private void detail_CheckedChanged(object sender, EventArgs e)
        {
            btnReport.Enabled = false;

            if (cbDetails.Checked)
            {
                string url = GlobalSettings.Default.URLBugGenie +
                    String.Format(GlobalSettings.Default.BugSearch, ErrCode.Text);
                
                Size = normSize;
                bugBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(completeSearch);
                bugBrowser.Navigate(url);
            }
            else
            {
                normSize = Size;
                Size = MinimumSize;
            }

            bugBrowser.Visible =
                btnReport.Visible = cbDetails.Checked;
        }

        private void completeSearch(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            bugBrowser.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler(completeSearch);
            btnReport.Enabled = true;
        }

        /// <summary>
        /// Experimental bug reporting.  BugGenie isn't exactly built with this in mind.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportBug(object sender, EventArgs e)
        {
            Uri reportUrl = new Uri(GlobalSettings.Default.URLBugGenie + GlobalSettings.Default.BugReport);

            if (bugBrowser.Url != reportUrl)
            {
                bugBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(ScriptReportBug);
                bugBrowser.Navigate(reportUrl);
            }
            else
                ScriptReportBug(null, null);
        }

        private void ScriptReportBug(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument htm = bugBrowser.Document;

            htm.InvokeScript("setComponent", new object[] { 4 });
            htm.InvokeScript("setCategory", new object[] { 37 });
            htm.InvokeScript("setSeverity", new object[] { 18 });

            Assembly ca = Assembly.GetExecutingAssembly();
            string[] attribs = ca.ToString().Split(',');
            string file = Path.GetFileName(ca.Location);
            string vers = attribs[1].Substring(attribs[1].IndexOf('=') + 1);

            HtmlElement title = htm.GetElementById("rni_step3_title");
            if (title != null)
                title.SetAttribute("value", String.Format("[{0}]: {1}", ErrCode.Text, currErr.Message));

            HtmlElement description = htm.GetElementById("step3_description");
            if (description != null)
                description.InnerText =
                    String.Format("[{0}];{1};{2};{3}\r\n{4}",
                    ErrCode.Text, DateTime.Now, file, vers, currErr.ToString());
        }

        private static void ParentShow()
        {
            if (!instance.Visible)
                instance.ShowDialog(Backstage);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Backstage.Close();

            // Try to write error log and such first.
            try
            {
                GlobalSettings.Default.Save();
                string xmlPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Options.sTables.WriteXml(xmlPath + "\\Mawenzy\\Mawenzy.Backdrop.xml");
            }
            catch (Exception)
            {
                // Do we need to taddle on the way out?
                // Nah. User has had enough trouble already.
            }

            Environment.Exit(1);
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            Debugger.Break();
        }

        private void ErrForm_Load(object sender, EventArgs e)
        {
            cbErrMode.SelectedIndex = GlobalSettings.Default.ErrorMode;
        }

        private void cbErrMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Just change setting with the ambiguity of which button should commit.
            GlobalSettings.Default.ErrorMode = cbErrMode.SelectedIndex;
        }

        public static void RethrowJoinThread(Exception ex)
        {
            ErrForm.Show(ex);
        }
    }
}
