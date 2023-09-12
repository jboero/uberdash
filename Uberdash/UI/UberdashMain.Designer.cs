namespace Mawenzy.UI
{
    partial class UberdashMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UberdashMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Desktop", 38, 602);
            this.nicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browser = new Mawenzy.Browser();
            this.browserPluginWrapper1 = new Mawenzy.BrowserPluginWrapper();
            this.sb = new ShellDll.ShellBrowser();
            this.cm.SuspendLayout();
            this.SuspendLayout();
            // 
            // nicon
            // 
            this.nicon.ContextMenuStrip = this.cm;
            this.nicon.Icon = ((System.Drawing.Icon)(resources.GetObject("nicon.Icon")));
            this.nicon.Text = "Uberdash";
            this.nicon.Visible = true;
            this.nicon.DoubleClick += new System.EventHandler(this.showOptions);
            // 
            // cm
            // 
            this.cm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.cm.Name = "cm";
            this.cm.Size = new System.Drawing.Size(181, 76);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::Mawenzy.Properties.Resources.Crystal_Clear_action_configure;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::Mawenzy.Properties.Resources.Crystal_Clear_app_ark2;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Check for &Updates...";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Mawenzy.Properties.Resources.Crystal_Clear_action_exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // browser
            // 
            this.browser.AllowDrop = true;
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.ListViewMode = System.Windows.Forms.View.LargeIcon;
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.Name = "browser";
            this.browser.PluginWrapper = this.browserPluginWrapper1;
            treeNode1.ImageIndex = 38;
            treeNode1.Name = "Desktop";
            treeNode1.SelectedImageIndex = 602;
            treeNode1.Text = "Desktop";
            this.browser.SelectedNode = treeNode1;
            this.browser.ShellBrowser = this.sb;
            this.browser.Size = new System.Drawing.Size(292, 266);
            this.browser.TabIndex = 0;
            // 
            // UberdashMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.browser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UberdashMain";
            this.Text = "Uberdash Backstage";
            this.cm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Mawenzy.Browser browser;
        private ShellDll.ShellBrowser sb;
        internal System.Windows.Forms.NotifyIcon nicon;
        private System.Windows.Forms.ContextMenuStrip cm;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private Mawenzy.BrowserPluginWrapper browserPluginWrapper1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

