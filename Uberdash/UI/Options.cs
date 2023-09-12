using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Plugins;
using Mawenzy.Properties;
using System.Collections;
using System.Reflection;
using ShellDll;
using System.IO;
using Mawenzy.UI;
using System.Diagnostics;

namespace Mawenzy
{
    public partial class Options : Form
    {
        static internal Options optsInst = null;

        /// <summary>
        /// Gets the singleton Options instance.
        /// </summary>
        static public Options OptsInst
        {
            get
            {
                return optsInst;
            }
        }

        /// JLB <summary>
        /// Save setting option tables for plugins and icon positions.
        /// </summary>
        static internal  SettingsTables sTables = new SettingsTables();

        /// JLB <summary>
        /// Singleton map of all plugins enabled or not.
        /// </summary>
        static internal SortedList<int, PluginBase> AllPlugins = new SortedList<int, PluginBase>();

        /// JLB <summary>
        /// Singleton map of active plugins sorted by layer.
        /// </summary>
        static internal SortedList<int, PluginBase> ActivePlugins = new SortedList<int, PluginBase>();

        /// JLB <summary>
        /// Singleton map of all loaded plugin assemblies.
        /// </summary>
        static internal Dictionary<string, Assembly> PlugAssMap = new Dictionary<string, Assembly>();

        /// JLB <summary>
        /// Parent listview.
        /// </summary>
        static private BrowserListView parent;

        /// <summary>
        /// A list of plugins flagged for deactivation.
        /// </summary>
        private List<ListViewItem> removeds = null;

        new internal static void ShowDialog()
        {
            OptsInst.Options_Load(null, EventArgs.Empty);
            OptsInst.Show();
            OptsInst.WindowState = FormWindowState.Normal;
            OptsInst.BringToFront();
        }

        internal Options(BrowserListView active)
        {
            parent = active;
            InitializeComponent();
            listPlugins.ListViewItemSorter = new PluginSorter();
        }

        private void EnableButtons()
        {
            if (listPlugins.SelectedItems.Count > 0)
            {
                btnDn.Enabled = listPlugins.SelectedItems[0].Index < listPlugins.Items.Count - 1;
                btnUp.Enabled = listPlugins.SelectedItems[0].Index > 0;
            }
            else
                btnUp.Enabled = btnDn.Enabled = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
            Hide();

            foreach (Control sub in splitter.Panel2.Controls)
                sub.Dispose();

            splitter.Panel2.Controls.Clear();
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                btnRemove.Enabled = listPlugins.SelectedItems.Count > 0;

                foreach (Control sub in splitter.Panel2.Controls)
                    sub.Dispose();
                
                splitter.Panel2.Controls.Clear();

                if (listPlugins.SelectedItems.Count > 0)
                {
                    Control setup = (listPlugins.SelectedItems[0].Tag as PluginBase).ConfigControl;
                    setup.Dock = DockStyle.Fill;
                    splitter.Panel2.Controls.Add(setup);
                }

                EnableButtons();
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException("Plugin configuration error.", ex));
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            // Note overridden Close hides and purges panels.
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OK(object sender, EventArgs e)
        {
            Apply(null, EventArgs.Empty);
            // Note overridden Close hides and purges panels.
            Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalSettings.Default.Reload();  // Pointless with creation of sTables

                listPlugins.BeginUpdate();
                listPlugins.Items.Clear();
                // TODO remove
                foreach (PluginBase plugin in Options.AllPlugins.Values)
                {
                    int hash = plugin.GetHashCode();
                    ListViewItem lit = new ListViewItem(plugin.GetType().Name.Replace('.', ' ').Replace('_', ' '));
                    lit.Tag = plugin;
                    lit.SubItems.Add(plugin.Layer.ToString()); // Old layer.

                    pluginIconList.Images.Add(hash.ToString(), plugin.OptionsIcon);
                    lit.ImageIndex = pluginIconList.Images.IndexOfKey(hash.ToString());

                    string nsp = plugin.GetType().Namespace;
                    lit.Group = listPlugins.Groups[nsp];

                    if (lit.Group == null)
                    {
                        ListViewGroup lvg = new ListViewGroup(nsp, nsp.Replace('.', ' '));
                        listPlugins.Groups.Add(lit.Group = lvg);
                    }

                    lit.Checked = ActivePlugins.ContainsKey(plugin.Layer);
                    lit.ToolTipText = plugin.ToString().Replace('_', ' ').Replace(":", "\r\nVersion ");
                    listPlugins.Items.Add(lit);
                }

                listPlugins.SelectedItems.Clear();
                listPlugins.Sort();
                listPlugins.EndUpdate();
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.ERR_OptionsDialog, ex));
            }
        }

        private void Apply(object sender, EventArgs e)
        {
            try
            {
                // JLB - commit settings values if user hits enter without losing focus.
                Focus();

                sTables.Plugins.Clear();

                List<PluginBase> reorder = new List<PluginBase>(AllPlugins.Values);

                AllPlugins.Clear();

                // Deactivate all active plugins that were uninstalled.
                if (removeds != null)
                {
                    foreach (ListViewItem lit in removeds)
                    {
                        PluginBase plugRemoved = lit.Tag as PluginBase;
                        if (plugRemoved != null && plugRemoved.Active)
                        {
                            try
                            {
                                plugRemoved.Deactivate();
                            }
                            catch (Exception) { }
                        }
                    }
                    removeds.Clear();
                    removeds = null;
                }

                ActivePlugins.Clear();
                foreach (ListViewItem lit in listPlugins.Items)
                {
                    PluginBase plugin = lit.Tag as PluginBase;
                    int newLayer = Convert.ToInt32(lit.SubItems[1].Text);

                    plugin.Layer = newLayer;
                    sTables.Plugins.AddPluginsRow(
                        plugin.GetType().ToString(),
                        plugin.GetType().Assembly.Location,
                        lit.Checked,
                        plugin.Layer,
                        null);

                    AllPlugins.Add(newLayer, plugin);

                    if (lit.Checked)
                    {
                        if (!plugin.Active)
                            plugin.Activate();
                        else  // Just place it back in the active list.
                            ActivePlugins.Add(plugin.Layer, plugin);
                    }
                    else if (plugin.Active)
                        plugin.Deactivate();
                }

                OptsInst.SaveSettings();
                GlobalSettings.Default.Save();
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.ErrSaving, ex));
            }

            GC.Collect();
        }

        private void MoveDown(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selItem = listPlugins.SelectedItems[0];
                ListViewItem nextItem = listPlugins.Items[selItem.Index + 1];

                ListViewItem.ListViewSubItem selLayer = selItem.SubItems[1];
                selItem.SubItems[1] = nextItem.SubItems[1];
                nextItem.SubItems[1] = selLayer;

                listPlugins.Sort();
                EnableButtons();
            }
            catch (Exception)
            {
                btnDn.Enabled = false;
            }
        }

        private void MoveUp(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selItem = listPlugins.SelectedItems[0];
                ListViewItem nextItem = listPlugins.Items[selItem.Index - 1];

                ListViewItem.ListViewSubItem selLayer = selItem.SubItems[1];
                selItem.SubItems[1] = nextItem.SubItems[1];
                nextItem.SubItems[1] = selLayer;

                listPlugins.Sort();
                EnableButtons();
            }
            catch (Exception)
            {
                btnUp.Enabled = false;
            }
        }

        internal void LoadPlugins()
        {
            Options.ActivePlugins.Clear();
            Options.AllPlugins.Clear();

            try
            {
                string xmlPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                sTables.ReadXml(xmlPath + "\\Mawenzy\\Mawenzy.Backdrop.xml");
            }
            catch (Exception)
            {
                // Couldn't load previous session? Skip & start over.
            }

            // Load plugins as specified in settings tables.
            foreach (SettingsTables.PluginsRow plugRow in sTables.Plugins)
            {
                try
                {
                    Assembly extension = null;
                    if (!PlugAssMap.ContainsKey(plugRow.Assembly))
                    {
                        extension = Assembly.LoadFile(plugRow.Assembly);
                        PlugAssMap.Add(plugRow.Assembly, extension);
                    }
                    else
                        extension = PlugAssMap[plugRow.Assembly];

                    // Reflection fetch plugin type.
                    Type plugType = extension.GetType(plugRow.PlugName);
                    if (plugType != null)
                    {
                        PluginBase plugInstance = plugType.GetConstructor(new Type[] { }).Invoke(null) as PluginBase;

                        plugInstance.Layer = plugRow.Layer;
                        AllPlugins.Add(plugInstance.Layer, plugInstance);

                        // Activate the plugin if settings say so.
                        if (plugRow.Enabled)
                            plugInstance.Activate();

                        ListViewItem lit = new ListViewItem(plugRow.PlugName.Replace('_', ' '));

                        lit.Tag = plugRow;
                        pluginIconList.Images.Add(plugRow.PlugName, plugInstance.OptionsIcon);
                        lit.ImageIndex = pluginIconList.Images.IndexOfKey(plugRow.PlugName);

                        string nsp = plugInstance.GetType().Namespace;
                        lit.Group = listPlugins.Groups[nsp];
                        
                        // Add plugin group if not established.
                        if (lit.Group == null)
                        {
                            ListViewGroup lvg = new ListViewGroup(nsp, nsp.Replace('_', ' ').Replace('.', ' '));
                            listPlugins.Groups.Add(lit.Group = lvg);
                        }
                    }
                    //else No PluginBase.NotifyIcon yet, so just ignore an invalid or moved plugin.
                }
                catch (Exception ex)
                {
                    ErrForm.Show(new ApplicationException(
                        "Plugin load error: " + plugRow.PlugName, ex));
                }
            }

            ReadSettings();
        }

        internal void SaveSettings()
        {
            try
            {
                string xmlPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                if (!Directory.Exists(xmlPath + "\\Mawenzy"))
                    Directory.CreateDirectory(xmlPath + "\\Mawenzy");

                sTables.IconPositions.Clear();
                foreach (ListViewItem lit in parent.Items)
                    sTables.IconPositions.AddIconPositionsRow(
                        ShellItem.GetRealPath(lit.Tag as ShellItem), 
                        lit.Position.X, 
                        lit.Position.Y);

                sTables.WriteXml(xmlPath + "\\Mawenzy\\Mawenzy.Backdrop.xml");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to write settings file.", ex);
            }

            foreach (PluginBase plugin in AllPlugins.Values)
                plugin.WriteSettings();

            GlobalSettings.Default.Save();
        }

        internal void ReadSettings()
        {
            GlobalSettings.Default.Reload();

            foreach (PluginBase plugin in AllPlugins.Values)
                plugin.ReadSettings();
        }

        internal static void ApplyIconPositions(Dictionary<string,Point> pos)
        {
            foreach (ListViewItem lit in parent.Items)
            {
                if (pos.ContainsKey(lit.Text))
                    lit.Position = pos[lit.Text];
                else
                    parent.Items.Remove(lit);
            }
        }

        public void InstallPlugins(object sender, EventArgs e)
        {
            try
            {
                openFD.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\plugins";

                // Find a plugin dll.
                if (openFD.ShowDialog(this) != DialogResult.OK)
                    return;

                PluginBrowser pBrowser = null;
                if (PlugAssMap.ContainsKey(openFD.FileName))
                    pBrowser = new PluginBrowser(PlugAssMap[openFD.FileName]);
                else
                    pBrowser = new PluginBrowser(Assembly.LoadFile(openFD.FileName));

                // Post healthy warning about installing malicious plugins.
                pBrowser.tbWarn.Text = Resources.PluginWarning;

                if (pBrowser.ShowDialog(this) != DialogResult.OK)
                    return;

                if (!PlugAssMap.ContainsKey(openFD.FileName))
                    PlugAssMap.Add(openFD.FileName, pBrowser.BrowsingAssembly);

                foreach (ListViewItem lit in pBrowser.listInstall.Items)
                {
                    Type plugType = lit.Tag as Type;
                    try
                    {
                        PluginBase pb = plugType.GetConstructor(new Type[] { }).Invoke(null) as PluginBase;
                        for (pb.Layer = 0; AllPlugins.ContainsKey(pb.Layer); --pb.Layer) ;

                        AllPlugins.Add(pb.Layer, pb);
                    }
                    catch (Exception ex)
                    {
                        ErrForm.Show(new ApplicationException(
                            "Failed plugin load: " + plugType, ex));
                    }
                }
                Options_Load(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException(
                    "Failed read of plugin assembly: " + openFD.FileName, ex));
            }
        }

        private void Remove(object sender, EventArgs e)
        {
            if (removeds == null)
                removeds = new List<ListViewItem>();

            // JLB This should never happen because button should be disabled,
            // but that doesn't mean it never happened to me somehow...
            if (listPlugins.SelectedItems.Count < 1)
                return;

            ListViewItem lit = listPlugins.SelectedItems[0];
            listPlugins.Items.Remove(listPlugins.SelectedItems[0]);
            removeds.Add(lit);
        }
    }

    public class PluginSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItem litX = x as ListViewItem;
            ListViewItem litY = y as ListViewItem;
            int lX = Convert.ToInt32(litX.SubItems[1].Text);
            int lY = Convert.ToInt32(litY.SubItems[1].Text);

            return lY.CompareTo(lX);
        }
    }
}
