namespace Mawenzy
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.splitter2 = new System.Windows.Forms.SplitContainer();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDn = new System.Windows.Forms.Button();
            this.listPlugins = new System.Windows.Forms.ListView();
            this.colPlugin = new System.Windows.Forms.ColumnHeader();
            this.pluginIconList = new System.Windows.Forms.ImageList(this.components);
            this.btnInstall = new System.Windows.Forms.Button();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.btnRemove = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splitter.Panel1.SuspendLayout();
            this.splitter.SuspendLayout();
            this.splitter2.Panel1.SuspendLayout();
            this.splitter2.Panel2.SuspendLayout();
            this.splitter2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(465, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(384, 281);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OK);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(546, 281);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.Apply);
            // 
            // splitter
            // 
            this.splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitter.Location = new System.Drawing.Point(12, 12);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.splitter2);
            this.splitter.Panel1.Controls.Add(this.listPlugins);
            this.splitter.Panel1MinSize = 160;
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.BackgroundImage = global::Mawenzy.Properties.Resources.mw_blur;
            this.splitter.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splitter.Size = new System.Drawing.Size(609, 263);
            this.splitter.SplitterDistance = 197;
            this.splitter.TabIndex = 8;
            // 
            // splitter2
            // 
            this.splitter2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitter2.IsSplitterFixed = true;
            this.splitter2.Location = new System.Drawing.Point(170, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitter2.Panel1
            // 
            this.splitter2.Panel1.Controls.Add(this.btnUp);
            // 
            // splitter2.Panel2
            // 
            this.splitter2.Panel2.Controls.Add(this.btnDn);
            this.splitter2.Size = new System.Drawing.Size(28, 263);
            this.splitter2.SplitterDistance = 131;
            this.splitter2.TabIndex = 12;
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUp.Enabled = false;
            this.btnUp.Image = global::Mawenzy.Properties.Resources.up;
            this.btnUp.Location = new System.Drawing.Point(0, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 131);
            this.btnUp.TabIndex = 14;
            this.toolTip.SetToolTip(this.btnUp, "Move the selected plugin up in the draw order.\r\nPutting background plugins at the" +
                    " top\r\nof this list will cover any plugins below.");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.MoveUp);
            // 
            // btnDn
            // 
            this.btnDn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDn.Enabled = false;
            this.btnDn.Image = global::Mawenzy.Properties.Resources.dn;
            this.btnDn.Location = new System.Drawing.Point(0, 0);
            this.btnDn.Name = "btnDn";
            this.btnDn.Size = new System.Drawing.Size(28, 128);
            this.btnDn.TabIndex = 16;
            this.toolTip.SetToolTip(this.btnDn, "Move the selected plugin down in the draw order.\r\nBackground plugins should be at" +
                    " the bottom of this list.");
            this.btnDn.UseVisualStyleBackColor = true;
            this.btnDn.Click += new System.EventHandler(this.MoveDown);
            // 
            // listPlugins
            // 
            this.listPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPlugins.AutoArrange = false;
            this.listPlugins.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listPlugins.BackgroundImage")));
            this.listPlugins.BackgroundImageTiled = true;
            this.listPlugins.CheckBoxes = true;
            this.listPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPlugin});
            this.listPlugins.HideSelection = false;
            this.listPlugins.LargeImageList = this.pluginIconList;
            this.listPlugins.Location = new System.Drawing.Point(0, 0);
            this.listPlugins.MultiSelect = false;
            this.listPlugins.Name = "listPlugins";
            this.listPlugins.ShowGroups = false;
            this.listPlugins.ShowItemToolTips = true;
            this.listPlugins.Size = new System.Drawing.Size(168, 263);
            this.listPlugins.SmallImageList = this.pluginIconList;
            this.listPlugins.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listPlugins.TabIndex = 7;
            this.listPlugins.UseCompatibleStateImageBehavior = false;
            this.listPlugins.View = System.Windows.Forms.View.Details;
            this.listPlugins.SelectedIndexChanged += new System.EventHandler(this.SelectionChanged);
            // 
            // colPlugin
            // 
            this.colPlugin.Text = "Plugin";
            this.colPlugin.Width = 144;
            // 
            // pluginIconList
            // 
            this.pluginIconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.pluginIconList.ImageSize = new System.Drawing.Size(32, 32);
            this.pluginIconList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInstall.Location = new System.Drawing.Point(12, 281);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(99, 23);
            this.btnInstall.TabIndex = 9;
            this.btnInstall.Text = "Install Plugins...";
            this.toolTip.SetToolTip(this.btnInstall, "Install a plugin after downloading it from Uberdash.com.\r\n\r\nWARNING: do not downl" +
                    "oad or try to install untrusted plugins.\r\nThey may contain a virus or malicious " +
                    "code.");
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.InstallPlugins);
            // 
            // openFD
            // 
            this.openFD.Filter = "Plugin Assemblies|*.dll";
            this.openFD.Title = "Browse for plugin assembly.";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(117, 281);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(78, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.toolTip.SetToolTip(this.btnRemove, "Remove a plugin from this list if you no longer want to use it.");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.Remove);
            // 
            // Options
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(633, 316);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Überdash Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.ResumeLayout(false);
            this.splitter2.Panel1.ResumeLayout(false);
            this.splitter2.Panel2.ResumeLayout(false);
            this.splitter2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ListView listPlugins;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.ColumnHeader colPlugin;
        private System.Windows.Forms.ImageList pluginIconList;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.SplitContainer splitter2;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDn;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolTip toolTip;
    }
}