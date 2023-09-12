using System.Drawing;
namespace Mawenzy.Feeds
{
    partial class RSSConfig
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
            System.Windows.Forms.GroupBox groupTitle;
            System.Windows.Forms.PictureBox pbClock;
            this.numMaxItems = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.LinkLabel();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRem = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.dgvFeeds = new System.Windows.Forms.DataGridView();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Feed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            groupTitle = new System.Windows.Forms.GroupBox();
            pbClock = new System.Windows.Forms.PictureBox();
            groupTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pbClock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeds)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            groupTitle.Controls.Add(this.numMaxItems);
            groupTitle.Controls.Add(this.label1);
            groupTitle.Controls.Add(this.link);
            groupTitle.Controls.Add(this.cbMode);
            groupTitle.Controls.Add(this.label3);
            groupTitle.Controls.Add(pbClock);
            groupTitle.Controls.Add(this.btnRem);
            groupTitle.Controls.Add(this.btnAdd);
            groupTitle.Controls.Add(this.tbAddress);
            groupTitle.Controls.Add(this.dgvFeeds);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "RSS Feeds";
            // 
            // numMaxItems
            // 
            this.numMaxItems.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "RSS_MaxItems", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMaxItems.Location = new System.Drawing.Point(162, 43);
            this.numMaxItems.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxItems.Name = "numMaxItems";
            this.numMaxItems.Size = new System.Drawing.Size(120, 20);
            this.numMaxItems.TabIndex = 14;
            this.numMaxItems.Value = global::Mawenzy.Plugins.PluginSettings.Default.RSS_MaxItems;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Max items to fetch:";
            this.toolTip.SetToolTip(this.label1, "How to present RSS items.");
            // 
            // link
            // 
            this.link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.link.Location = new System.Drawing.Point(408, 277);
            this.link.Name = "link";
            this.link.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.link.Size = new System.Drawing.Size(75, 13);
            this.link.TabIndex = 12;
            this.link.TabStop = true;
            this.link.Text = "Policy";
            this.link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.link, "If you are using the RSS plugin, \r\nyou have agreed to this policy.");
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // cbMode
            // 
            this.cbMode.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.PluginSettings.Default, "RSS_RotationMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Random",
            "Sequential Descending",
            "Sequential Ascending"});
            this.cbMode.Location = new System.Drawing.Point(162, 16);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(240, 21);
            this.cbMode.TabIndex = 11;
            this.cbMode.Text = global::Mawenzy.Plugins.PluginSettings.Default.RSS_RotationMode;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Scroll mode:";
            this.toolTip.SetToolTip(this.label3, "How to present RSS items.");
            // 
            // pbClock
            // 
            pbClock.Image = global::Mawenzy.Plugins.Properties.Resources.cc_history_48;
            pbClock.Location = new System.Drawing.Point(6, 19);
            pbClock.Name = "pbClock";
            pbClock.Size = new System.Drawing.Size(48, 48);
            pbClock.TabIndex = 9;
            pbClock.TabStop = false;
            // 
            // btnRem
            // 
            this.btnRem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRem.Location = new System.Drawing.Point(408, 99);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(72, 23);
            this.btnRem.TabIndex = 4;
            this.btnRem.Text = "Remove";
            this.btnRem.UseVisualStyleBackColor = true;
            this.btnRem.Click += new System.EventHandler(this.btnRem_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(408, 70);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbAddress
            // 
            this.tbAddress.AllowDrop = true;
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddress.Location = new System.Drawing.Point(6, 73);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(396, 20);
            this.tbAddress.TabIndex = 2;
            this.toolTip.SetToolTip(this.tbAddress, "Type, copy, or drag your RSS links here.");
            this.tbAddress.TextChanged += new System.EventHandler(this.tbAddress_TextChanged);
            this.tbAddress.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbAddress_DragDrop);
            this.tbAddress.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbAddress_DragEnter);
            this.tbAddress.DragOver += new System.Windows.Forms.DragEventHandler(this.tbAddress_DragOver);
            // 
            // dgvFeeds
            // 
            this.dgvFeeds.AllowDrop = true;
            this.dgvFeeds.AllowUserToAddRows = false;
            this.dgvFeeds.AllowUserToDeleteRows = false;
            this.dgvFeeds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFeeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.Feed});
            this.dgvFeeds.Location = new System.Drawing.Point(6, 99);
            this.dgvFeeds.Name = "dgvFeeds";
            this.dgvFeeds.ReadOnly = true;
            this.dgvFeeds.RowHeadersWidth = 4;
            this.dgvFeeds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeeds.Size = new System.Drawing.Size(396, 191);
            this.dgvFeeds.TabIndex = 1;
            this.dgvFeeds.DragOver += new System.Windows.Forms.DragEventHandler(this.tbAddress_DragOver);
            this.dgvFeeds.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbAddress_DragEnter);
            this.dgvFeeds.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvFeeds_DragDrop);
            // 
            // Icon
            // 
            this.Icon.HeaderText = "Icon";
            this.Icon.Image = global::Mawenzy.Plugins.Properties.Resources.rss;
            this.Icon.MinimumWidth = 20;
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Width = 32;
            // 
            // Feed
            // 
            this.Feed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Feed.HeaderText = "Feed";
            this.Feed.Name = "Feed";
            this.Feed.ReadOnly = true;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // RSSConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "RSSConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            groupTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pbClock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeds)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnRem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.DataGridView dgvFeeds;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feed;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.LinkLabel link;
        private System.Windows.Forms.NumericUpDown numMaxItems;
        private System.Windows.Forms.Label label1;
    }
}
