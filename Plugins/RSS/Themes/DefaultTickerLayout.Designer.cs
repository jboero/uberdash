namespace Mawenzy.Feeds.Themes
{
    partial class DefaultTickerLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultTickerLayout));
            this.labTitle = new System.Windows.Forms.Label();
            this.labDesc = new System.Windows.Forms.Label();
            this.pbRSS = new System.Windows.Forms.PictureBox();
            this.labDate = new System.Windows.Forms.Label();
            this.cmRSSItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsRSS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLink = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsNext = new System.Windows.Forms.ToolStripMenuItem();
            this.pb = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRSS)).BeginInit();
            this.cmRSSItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.labTitle.AutoEllipsis = true;
            this.labTitle.BackColor = System.Drawing.Color.Transparent;
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.ForeColor = System.Drawing.Color.LightBlue;
            this.labTitle.Location = new System.Drawing.Point(45, 27);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(261, 127);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Title";
            // 
            // labDesc
            // 
            this.labDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labDesc.BackColor = System.Drawing.Color.Transparent;
            this.labDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDesc.ForeColor = System.Drawing.Color.Wheat;
            this.labDesc.Location = new System.Drawing.Point(312, 0);
            this.labDesc.MaximumSize = new System.Drawing.Size(800, 800);
            this.labDesc.Name = "labDesc";
            this.labDesc.Size = new System.Drawing.Size(248, 154);
            this.labDesc.TabIndex = 0;
            this.labDesc.Text = "Description";
            this.labDesc.UseMnemonic = false;
            // 
            // pbRSS
            // 
            this.pbRSS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbRSS.Image = global::Mawenzy.Plugins.Properties.Resources.rss;
            this.pbRSS.Location = new System.Drawing.Point(8, 61);
            this.pbRSS.Name = "pbRSS";
            this.pbRSS.Size = new System.Drawing.Size(32, 32);
            this.pbRSS.TabIndex = 1;
            this.pbRSS.TabStop = false;
            // 
            // labDate
            // 
            this.labDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.labDate.BackColor = System.Drawing.Color.Transparent;
            this.labDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDate.ForeColor = System.Drawing.Color.LightGray;
            this.labDate.Location = new System.Drawing.Point(45, 0);
            this.labDate.Name = "labDate";
            this.labDate.Size = new System.Drawing.Size(261, 27);
            this.labDate.TabIndex = 2;
            this.labDate.Text = "Date";
            this.labDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmRSSItem
            // 
            this.cmRSSItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRSS,
            this.tsLink,
            this.toolStripSeparator1,
            this.tsNext});
            this.cmRSSItem.Name = "cmRSSItem";
            this.cmRSSItem.Size = new System.Drawing.Size(156, 76);
            // 
            // tsRSS
            // 
            this.tsRSS.Image = global::Mawenzy.Plugins.Properties.Resources.rss;
            this.tsRSS.Name = "tsRSS";
            this.tsRSS.Size = new System.Drawing.Size(155, 22);
            this.tsRSS.Text = "Source: {RSS}";
            this.tsRSS.Click += new System.EventHandler(this.tsRSS_Click);
            // 
            // tsLink
            // 
            this.tsLink.Image = global::Mawenzy.Plugins.Properties.Resources.Crystal_Clear_app_katomic;
            this.tsLink.Name = "tsLink";
            this.tsLink.Size = new System.Drawing.Size(155, 22);
            this.tsLink.Text = "Item link: {URL}";
            this.tsLink.Click += new System.EventHandler(this.tsLink_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // tsNext
            // 
            this.tsNext.Image = global::Mawenzy.Plugins.Properties.Resources.Crystal_Clear_action_player_play;
            this.tsNext.Name = "tsNext";
            this.tsNext.Size = new System.Drawing.Size(155, 22);
            this.tsNext.Text = "Next RSS Feed";
            // 
            // pb
            // 
            this.pb.Image = global::Mawenzy.Plugins.Properties.Resources.rss_crn_tl;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(15, 15);
            this.pb.TabIndex = 3;
            this.pb.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::Mawenzy.Plugins.Properties.Resources.rss_body;
            this.pictureBox4.Location = new System.Drawing.Point(15, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(545, 139);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(15, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(545, 15);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(0, 15);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(15, 139);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 10;
            this.pictureBox7.TabStop = false;
            // 
            // DefaultTickerLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.labDate);
            this.Controls.Add(this.pbRSS);
            this.Controls.Add(this.labDesc);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pb);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(720, 154);
            this.Name = "DefaultTickerLayout";
            this.Size = new System.Drawing.Size(560, 154);
            ((System.ComponentModel.ISupportInitialize)(this.pbRSS)).EndInit();
            this.cmRSSItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label labTitle;
        internal System.Windows.Forms.Label labDesc;
        internal System.Windows.Forms.Label labDate;
        internal System.Windows.Forms.PictureBox pbRSS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem tsRSS;
        internal System.Windows.Forms.ToolStripMenuItem tsLink;
        internal System.Windows.Forms.ContextMenuStrip cmRSSItem;
        internal System.Windows.Forms.ToolStripMenuItem tsNext;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;

    }
}
