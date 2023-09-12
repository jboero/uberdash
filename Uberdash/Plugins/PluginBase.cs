using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Mawenzy.UI;
using System.Reflection;

namespace Mawenzy.Plugins
{
    public abstract class PluginBase
    {
        /// JLB <summary>
        /// The layer - or draw order of this plugin.
        /// </summary>
        private int layer = -1;

        /// JLB <summary>
        /// A dictionary of plugin names - fully qualified type names to their draw order.
        /// </summary>
        private static Dictionary<string, int> layerMap = new Dictionary<string, int>();

        /// JLB <summary>
        /// Holds whether or not we are in the active draw list.
        /// </summary>
        private bool active;

        /// JLB <summary>
        /// Gets or sets whether we should show an error from this plugin that the user has already seen.
        /// </summary>
        /// <remarks>
        /// The use of this is completely up to each plugin.
        /// </remarks>
        protected bool AwareOfErr;

        /// JLB <summary>
        /// Singleton current view for all plugins.
        /// </summary>
        static private BoeroViewShell parent = null;

        /// JLB <summary>
        /// Gets singleton current shell view.
        /// </summary>
        static public BoeroViewShell Parent
        {
            get
            {
                return parent;
            }
        }

        /// JLB <summary>
        /// Gets the Uberdash NotifyIcon for the option of alerts without dialogs.
        /// </summary>
        public NotifyIcon NotifyIcon
        {
            get
            {
                UberdashMain pForm = parent.FindForm() as UberdashMain;

                if (pForm != null)
                    return pForm.nicon;

                return null;
            }
        }

        /// <summary>
        /// Sets internal shell view.
        /// See BoeroView constructor.
        /// </summary>
        /// <param name="bv"></param>
        static internal void SetParent(BoeroViewShell bv)
        {
            parent = bv;
        }

        /// <summary>
        /// Perform all rendering here.  Note this is called in the render thread.
        /// </summary>
        virtual public void Draw()
        {
        }

        /// JLB <summary>
        /// Finish background threads with invoke to render context.
        /// </summary>
        protected delegate void JoinRenderThread();

        /// JLB <summary>
        /// Finish background threads with invoke to render context.
        /// </summary>
        protected delegate void JoinRenderThreadParam(object obj);

        /// <summary>
        /// Rejoin renderthread returning an exception generated during threaded operations.
        /// </summary>
        /// <param name="ex">Rethrown exception from a worker thread.</param>
        protected delegate void JoinRenderThreadEx(Exception ex);

        /// JLB <summary>
        /// Triggered when the desktop selection changes.
        /// </summary>
        /// <param name="e"></param>
        virtual public void HandleSelectionChanged(ListViewItemSelectionChangedEventArgs e) { }

        /// JLB <summary>
        /// Get an icon to represent this plugin in options dialog.
        /// </summary>
        abstract public Image OptionsIcon
        {
            get;
        }

        /// JLB <summary>
        /// Optionally override to read settings.
        /// </summary>
        virtual public void ReadSettings()
        {
        }

        /// JLB <summary>
        /// Optionally override to write settings.
        /// </summary>
        virtual public void WriteSettings()
        {
        }
        
        /// JLB <summary>
        /// Gets the render order of this plugin.
        /// </summary>
        public int Layer
        {
            get
            {
                return layer;
            }
            internal set
            {
                layer = value;
            }
        }

        /// JLB <summary>
        /// Get an instance of the plugin's custom control for show in Options pane.
        /// </summary>
        public abstract Control ConfigControl
        { get; }

        /// JLB <summary>
        /// Simple ToString gets name and layer.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetType().FullName + ':' + Version.ToString() + ':' + layer;
        }

        /// JLB <summary>
        /// Optional override to handle a mouse click event.
        /// </summary>
        /// <param name="e">Click args.</param>
        /// <returns>True iff we used this click and don't want it to pass down to lower layers.</returns>
        virtual public bool HandleMouseClick(MouseEventArgs e)
        {
            return false;
        }

        /// JLB <summary>
        /// Optional override to handle mouse wheel events.
        /// </summary>
        /// <param name="e">Wheel args.</param>
        /// <returns>True iff we used this event and won't pass it down to lower layers.</returns>
        virtual public bool HandleMouseWheel(MouseEventArgs e)
        {
            return false;
        }

        /// JLB <summary>
        /// Gets whether this plugin is active or not.
        /// </summary>
        virtual public bool Active
        {
            get
            {
                return active;
            }
        }

        /// JLB <summary>
        /// Adds this plugin to global active queue.  Perform additional activation by overriding.
        /// </summary>
        virtual public void Activate()
        {
            if (!Options.ActivePlugins.ContainsValue(this))
            {
                Options.ActivePlugins.Add(layer, this);
                active = true;
                AwareOfErr = false;
            }
        }

        /// JLB <summary>
        /// Removes this from global active queue.  
        /// Perform additional deactivation/disposal by overriding.
        /// </summary>
        virtual public void Deactivate()
        {
            if (Active && Options.ActivePlugins.ContainsValue(this))
                Options.ActivePlugins.RemoveAt(Options.ActivePlugins.IndexOfValue(this));

            active = false;
            GC.Collect();
        }

        /// JLB <summary>
        /// Gets the version of this plugin or the assembly version by default.
        /// </summary>
        virtual public Version Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// If the shell passes args to Uberdash, they are passed down
        /// to the plugins, even if the app is running.  Use them and
        /// return true if they were useful.  Otherwise return false
        /// and pass them down to the next plugin.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        virtual public bool HandleArgs(string[] args)
        {
            return false;
        }
    }
}
