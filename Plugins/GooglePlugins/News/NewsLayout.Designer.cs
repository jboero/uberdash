namespace Mawenzy.Feeds
{
    partial class NewsLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.NewsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hideGoogleNewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureGoogleNewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.builder = new System.Windows.Forms.Timer(this.components);
            this.NewsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Browser
            // 
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(0, 0);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.ScrollBarsEnabled = false;
            this.Browser.Size = new System.Drawing.Size(600, 800);
            this.Browser.TabIndex = 0;
            // 
            // NewsStrip
            // 
            this.NewsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.hideGoogleNewsToolStripMenuItem,
            this.autoShowToolStripMenuItem,
            this.toolStripSeparator1,
            this.openInBrowserToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.configureGoogleNewsToolStripMenuItem});
            this.NewsStrip.Name = "NewsStrip";
            this.NewsStrip.Size = new System.Drawing.Size(177, 164);
            this.NewsStrip.Opening += new System.ComponentModel.CancelEventHandler(this.NewsStrip_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Image = global::Mawenzy.Plugins.Properties.Resources.news_16;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem1.Text = "News Plugin";
            // 
            // hideGoogleNewsToolStripMenuItem
            // 
            this.hideGoogleNewsToolStripMenuItem.Image = global::Mawenzy.Plugins.Properties.Resources.min_16;
            this.hideGoogleNewsToolStripMenuItem.Name = "hideGoogleNewsToolStripMenuItem";
            this.hideGoogleNewsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.hideGoogleNewsToolStripMenuItem.Text = "&Hide News";
            this.hideGoogleNewsToolStripMenuItem.Click += new System.EventHandler(this.hideGoogleNewsToolStripMenuItem_Click);
            // 
            // autoShowToolStripMenuItem
            // 
            this.autoShowToolStripMenuItem.Image = global::Mawenzy.Plugins.Properties.Resources.auto_16;
            this.autoShowToolStripMenuItem.Name = "autoShowToolStripMenuItem";
            this.autoShowToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.autoShowToolStripMenuItem.Text = "Auto Show";
            this.autoShowToolStripMenuItem.Click += new System.EventHandler(this.autoShowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // openInBrowserToolStripMenuItem
            // 
            this.openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            this.openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.openInBrowserToolStripMenuItem.Text = "&Open in Browser...";
            this.openInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::Mawenzy.Plugins.Properties.Resources.Refresh_16;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // configureGoogleNewsToolStripMenuItem
            // 
            this.configureGoogleNewsToolStripMenuItem.Image = global::Mawenzy.Plugins.Properties.Resources.no_16;
            this.configureGoogleNewsToolStripMenuItem.Name = "configureGoogleNewsToolStripMenuItem";
            this.configureGoogleNewsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.configureGoogleNewsToolStripMenuItem.Text = "Disable News";
            this.configureGoogleNewsToolStripMenuItem.Click += new System.EventHandler(this.configureGoogleNewsToolStripMenuItem_Click);
            // 
            // builder
            // 
            this.builder.Enabled = global::Mawenzy.Plugins.PluginSettings.Default.NewsAutoRefresh;
            this.builder.Interval = global::Mawenzy.Plugins.PluginSettings.Default.NewsSwapInterval;
            this.builder.Tick += new System.EventHandler(this.builder_Tick);
            // 
            // NewsLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Browser);
            this.Name = "NewsLayout";
            this.Size = new System.Drawing.Size(600, 800);
            this.NewsStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.WebBrowser Browser;
        private System.Windows.Forms.ToolStripMenuItem hideGoogleNewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip NewsStrip;
        private System.Windows.Forms.ToolStripMenuItem configureGoogleNewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer builder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

    }
}
