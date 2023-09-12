using System.Drawing;
namespace Mawenzy.Feeds
{
    partial class NewsConfig
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
            System.Windows.Forms.GroupBox groupTitle;
            System.Windows.Forms.TableLayoutPanel tableLayout;
            System.Windows.Forms.Label labRegion;
            System.Windows.Forms.Label label1;
            this.labDelay = new System.Windows.Forms.Label();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tbRegion = new System.Windows.Forms.TextBox();
            this.comboNewsSource = new System.Windows.Forms.ComboBox();
            this.tbDelay = new System.Windows.Forms.TrackBar();
            this.cbAutoRefresh = new System.Windows.Forms.CheckBox();
            groupTitle = new System.Windows.Forms.GroupBox();
            tableLayout = new System.Windows.Forms.TableLayoutPanel();
            labRegion = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupTitle.SuspendLayout();
            tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            groupTitle.Controls.Add(tableLayout);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "News";
            // 
            // tableLayout
            // 
            tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayout.BackColor = System.Drawing.Color.Transparent;
            tableLayout.ColumnCount = 2;
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.16034F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.83966F));
            tableLayout.Controls.Add(this.tbRegion, 1, 0);
            tableLayout.Controls.Add(labRegion, 0, 0);
            tableLayout.Controls.Add(label1, 0, 1);
            tableLayout.Controls.Add(this.comboNewsSource, 1, 1);
            tableLayout.Controls.Add(this.labDelay, 0, 2);
            tableLayout.Controls.Add(this.tbDelay, 1, 2);
            tableLayout.Controls.Add(this.cbAutoRefresh, 1, 3);
            tableLayout.Location = new System.Drawing.Point(6, 19);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 4;
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayout.Size = new System.Drawing.Size(474, 130);
            tableLayout.TabIndex = 1;
            // 
            // labRegion
            // 
            labRegion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labRegion.AutoSize = true;
            labRegion.Location = new System.Drawing.Point(3, 6);
            labRegion.Name = "labRegion";
            labRegion.Size = new System.Drawing.Size(44, 13);
            labRegion.TabIndex = 0;
            labRegion.Text = "Region:";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 13);
            label1.TabIndex = 0;
            label1.Text = "News URL format:";
            // 
            // labDelay
            // 
            this.labDelay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labDelay.AutoSize = true;
            this.labDelay.Location = new System.Drawing.Point(3, 65);
            this.labDelay.Name = "labDelay";
            this.labDelay.Size = new System.Drawing.Size(72, 26);
            this.labDelay.TabIndex = 0;
            this.labDelay.Text = "Refresh delay\r\n(10 sec):";
            // 
            // tbRegion
            // 
            this.tbRegion.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.PluginSettings.Default, "NewsRegion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRegion.Location = new System.Drawing.Point(127, 3);
            this.tbRegion.Name = "tbRegion";
            this.tbRegion.Size = new System.Drawing.Size(344, 20);
            this.tbRegion.TabIndex = 1;
            this.tbRegion.Text = global::Mawenzy.Plugins.PluginSettings.Default.NewsRegion;
            // 
            // comboNewsSource
            // 
            this.comboNewsSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.PluginSettings.Default, "NewsURL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboNewsSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboNewsSource.FormattingEnabled = true;
            this.comboNewsSource.Items.AddRange(new object[] {
            "http://news.yahoo.com/localnews/12780826/{REGION}",
            "http://news.google.com/?geo={REGION}"});
            this.comboNewsSource.Location = new System.Drawing.Point(127, 29);
            this.comboNewsSource.Name = "comboNewsSource";
            this.comboNewsSource.Size = new System.Drawing.Size(344, 21);
            this.comboNewsSource.TabIndex = 2;
            this.comboNewsSource.Text = global::Mawenzy.Plugins.PluginSettings.Default.NewsURL;
            // 
            // tbDelay
            // 
            this.tbDelay.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "NewsSwapInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDelay.LargeChange = 10000;
            this.tbDelay.Location = new System.Drawing.Point(127, 56);
            this.tbDelay.Maximum = 3600000;
            this.tbDelay.Minimum = 10000;
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(344, 45);
            this.tbDelay.SmallChange = 1000;
            this.tbDelay.TabIndex = 3;
            this.tbDelay.TickFrequency = 100000;
            this.tbDelay.Value = global::Mawenzy.Plugins.PluginSettings.Default.NewsSwapInterval;
            this.tbDelay.ValueChanged += new System.EventHandler(this.tbDelay_ValueChanged);
            // 
            // cbAutoRefresh
            // 
            this.cbAutoRefresh.AutoSize = true;
            this.cbAutoRefresh.Checked = global::Mawenzy.Plugins.PluginSettings.Default.NewsAutoRefresh;
            this.cbAutoRefresh.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Mawenzy.Plugins.PluginSettings.Default, "NewsAutoRefresh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutoRefresh.Location = new System.Drawing.Point(127, 107);
            this.cbAutoRefresh.Name = "cbAutoRefresh";
            this.cbAutoRefresh.Size = new System.Drawing.Size(142, 17);
            this.cbAutoRefresh.TabIndex = 4;
            this.cbAutoRefresh.Text = "Auto refresh and present";
            this.cbAutoRefresh.UseVisualStyleBackColor = true;
            // 
            // NewsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "NewsConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelay)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.TextBox tbRegion;
        private System.Windows.Forms.ComboBox comboNewsSource;
        private System.Windows.Forms.TrackBar tbDelay;
        private System.Windows.Forms.Label labDelay;
        private System.Windows.Forms.CheckBox cbAutoRefresh;
    }
}
