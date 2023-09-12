using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mawenzy.Plugins;
using System.Reflection;
using Mawenzy.UI;
using Mawenzy.Properties;

namespace Mawenzy
{
    public partial class PluginBrowser : Form
    {
        private Assembly ass = null;

        internal Assembly BrowsingAssembly
        {
            set
            {
                ass = value;

                typeTree.BeginUpdate();

                foreach (Type t in ass.GetTypes())
                {
                    // Do we implement PluginBase??
                    if (typeof(PluginBase).IsAssignableFrom(t))
                    {
                        bool alreadyInstalled = false;
                        foreach (PluginBase existingPlugin in Options.AllPlugins.Values)
                        {
                            if (existingPlugin.GetType() == t)
                            {
                                alreadyInstalled = true;
                                break;
                            }
                        }
                        if (alreadyInstalled)
                            continue;

                        try
                        {
                            string ns = t.Namespace;
                            string[] nSplit = t.Namespace.Split('.');
                            int cutOff = 0;
                            TreeNode tnParent = null;

                            for (int i = 0; i < nSplit.Length; ++i)
                            {
                                cutOff += nSplit[i].Length;

                                string subSp = ns.Substring(0, cutOff);

                                if (tnParent == null)
                                {
                                    if (typeTree.Nodes.ContainsKey(subSp))
                                        tnParent = typeTree.Nodes[subSp];
                                    else
                                    {
                                        tnParent = new TreeNode(nSplit[i]);
                                        tnParent.Name = subSp;
                                        typeTree.Nodes.Add(tnParent);
                                    }
                                }
                                else
                                {
                                    if (tnParent.Nodes.ContainsKey(subSp))
                                        tnParent = tnParent.Nodes[subSp];
                                    else
                                    {
                                        TreeNode child = new TreeNode(nSplit[i]);
                                        child.Name = subSp;
                                        tnParent.Nodes.Add(child);
                                        tnParent = child;
                                    }
                                }

                                ++cutOff;
                            }

                            TreeNode plugNode = new TreeNode(t.Name);
                            plugNode.Tag = t;
                            plugNode.ImageIndex =
                            plugNode.StateImageIndex = 1;
                            tnParent.Nodes.Add(plugNode);
                        }
                        catch (Exception ex)
                        {
                            ErrForm.Show(new ApplicationException(
                                "Failed to load plugin " + t, ex));
                        }
                    }
                }

                typeTree.ExpandAll();
                typeTree.EndUpdate();
            }
            get
            {
                return ass;
            }
        }

        public PluginBrowser(Assembly pluginAssembly)
        {
            InitializeComponent();

            BrowsingAssembly = pluginAssembly;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void typeTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Type)
                props.SelectedObject = e.Node.Tag;
            else
                props.SelectedObject = null;
        }

        private void typeTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Type plugType = e.Node.Tag as Type;
            
            if (plugType == null)
                return;

            if (!listInstall.Items.ContainsKey(plugType.FullName))
            {
                ListViewItem lit = new ListViewItem();
                lit.Text = plugType.Name;
                lit.Name = plugType.FullName;
                lit.Tag = plugType;
                listInstall.Items.Add(lit);
                listInstall.Update();
            }
        }
    }
}
