using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Mawenzy;
using Mawenzy.Plugins;
using Mawenzy.UI;
using System.Diagnostics;
using Mawenzy.Util;
using Mawenzy.Properties;
using System.Threading;
using System.Reflection;

namespace Mawenzy.UI
{
    internal partial class UberdashMain : Form
    {
        #region Interop
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(
            string lpClassName, 
            string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(
            IntPtr parentHandle, 
            IntPtr childAfter, 
            string className, 
            IntPtr windowTitle);

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(
            IntPtr hWndChild, 
            IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(
            IntPtr hWnd, 
            int Msg, 
            int wParam, 
            int lParam);
        #endregion

        internal static IntPtr DefView;

        private static UberdashMain MainForm = null;

        /// JLB <summary>
        /// Main entry point for BackDrop.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            if (SingletonController.IamFirst(new SingletonController.ReceiveDelegate(ReceiveArgs)))
            {
                try
                {
#if DEBUG
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(MainForm = new UberdashMain());
#else
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                try
                {
                    Application.Run(MainForm = new UberdashMain());
                }
                catch (Exception ex)
                {
                    ErrForm.Show(ex);
                }
#endif
                }
                catch (Exception ex)
                {
                    ErrForm.instance.Error = new ApplicationException(
                        Resources.ERR_GeneralUnhandled, ex);
                    ErrForm.instance.ShowDialog();
                }
            }
            else
                SingletonController.Send(args);
        }

        /// <summary>
        /// Called when a new instance tries to start with arguments.
        /// Pass these arguments to plugins.
        /// </summary>
        /// <remarks>
        /// Example: RSS Plugin.
        /// When you click "subscribe to this feed" using Uberdash in Firefox,
        /// Firefox tries to run a new instance of Uberdash.  If an instance
        /// is already running, the args will be snagged by the RSS plugin and
        /// added to the list of RSS feeds.  Slick, but beware misuse...
        /// </remarks>
        /// <param name="args"></param>
        static void ReceiveArgs(string[] args)
        {
            try
            {
                // Find a plugin that wants these args.
                foreach (PluginBase plug in Options.ActivePlugins.Values)
                    if (plug.HandleArgs(args))
                        return;
            }
            catch (Exception ex)
            {
                // Inform the user that no plugin wanted their message.
                MainForm.nicon.ShowBalloonTip(5000, GlobalSettings.Default.NoAction,
                    String.Format(GlobalSettings.Default.ArgError, ex.Message),
                    ToolTipIcon.Error);
            }

            // Inform the user that no plugin wanted their message.
            MainForm.nicon.ShowBalloonTip(5000, GlobalSettings.Default.NoAction,
                GlobalSettings.Default.NoPluginFound, ToolTipIcon.Info);
        }

        /// JLB <summary>
        /// Init the main window and get it ready to stick over desktop.
        /// </summary>
        public UberdashMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            ErrForm.Init(this);
        }

        /// JLB <summary>
        /// Make sure to throw ourselves over the desktop before showing.
        /// This yields the least Flicker.
        /// </summary>
        /// <param name="value"> Show or not? </param>
        protected override void SetVisibleCore(bool value)
        {
            if (value)
            {
                // JLB Find desktop and... 
                IntPtr slv32 = IntPtr.Zero;
                IntPtr progman = FindWindow("progman", null);
                if (progman != IntPtr.Zero)
                    DefView = FindWindowEx(progman, IntPtr.Zero, "SHELLDLL_DefView", IntPtr.Zero);
                if (DefView != IntPtr.Zero)
                    slv32 = FindWindowEx(DefView, IntPtr.Zero, "SysListView32", IntPtr.Zero);

                // throw ourself on top of it maximizedly.
                SetParent(this.Handle, progman);
                FormBorderStyle = FormBorderStyle.None;
                base.SetVisibleCore(value);
                browser.SelectedItem = sb.DesktopItem;
                WindowState = FormWindowState.Normal;
            }
            else
                base.SetVisibleCore(value);
        }

        /// JLB <summary>
        /// Halt, end, fini, close, return 0, etc.
        /// </summary>
        /// <param name="sender"> Ignored. </param>
        /// <param name="e"> Ignored. </param>
        private void Exit(object sender, EventArgs e)
        {
            // Don't use ActivePlugins, as the collection will be modified.
            foreach (PluginBase plug in Options.AllPlugins.Values)
                if (plug.Active)
                    plug.Deactivate();

            Options.OptsInst.SaveSettings();
            Close();
        }

        /// JLB <summary>
        /// Show options dialog
        /// </summary>
        /// <param name="sender"> Ignore. </param>
        /// <param name="e"> Ignore. </param>
        private void showOptions(object sender, EventArgs e)
        {
            Options.ShowDialog();
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                base.SetVisibleCore(browser.SelectedItem != null);
                WindowState = FormWindowState.Maximized;
            }
            else
                base.OnClientSizeChanged(e);
        }

        /// JLB <summary>
        /// Rudimentary manual garbage collection for memory leak check.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> Ignored. </param>
        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Offscreen XML version checking.
            Safety.LaunchURL("http://www.mawenzy.com/download.php");
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOptions(null, EventArgs.Empty);
        }
    }
}
