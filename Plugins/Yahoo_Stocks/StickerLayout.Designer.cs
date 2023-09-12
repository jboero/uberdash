namespace Mawenzy.Feeds
{
    partial class StickerLayout
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
            System.Windows.Forms.Label labOpen;
            System.Windows.Forms.Label labHigh;
            System.Windows.Forms.Label labLow;
            this.Change = new System.Windows.Forms.Label();
            this.Arrow = new System.Windows.Forms.PictureBox();
            this.Open = new System.Windows.Forms.Label();
            this.Symbol = new System.Windows.Forms.Label();
            this.High = new System.Windows.Forms.Label();
            this.Low = new System.Windows.Forms.Label();
            this.LastTrade = new System.Windows.Forms.Label();
            this.Company = new System.Windows.Forms.Label();
            this.cmLink = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOpenLink = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            labOpen = new System.Windows.Forms.Label();
            labHigh = new System.Windows.Forms.Label();
            labLow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow)).BeginInit();
            this.cmLink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labOpen
            // 
            labOpen.AutoSize = true;
            labOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labOpen.Location = new System.Drawing.Point(30, 84);
            labOpen.Name = "labOpen";
            labOpen.Size = new System.Drawing.Size(48, 20);
            labOpen.TabIndex = 17;
            labOpen.Text = "Open";
            // 
            // labHigh
            // 
            labHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labHigh.AutoSize = true;
            labHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labHigh.ForeColor = System.Drawing.Color.LightGreen;
            labHigh.Location = new System.Drawing.Point(273, 84);
            labHigh.Name = "labHigh";
            labHigh.Size = new System.Drawing.Size(42, 20);
            labHigh.TabIndex = 15;
            labHigh.Text = "High";
            // 
            // labLow
            // 
            labLow.Anchor = System.Windows.Forms.AnchorStyles.None;
            labLow.AutoSize = true;
            labLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labLow.ForeColor = System.Drawing.Color.Red;
            labLow.Location = new System.Drawing.Point(164, 84);
            labLow.Name = "labLow";
            labLow.Size = new System.Drawing.Size(38, 20);
            labLow.TabIndex = 14;
            labLow.Text = "Low";
            // 
            // Change
            // 
            this.Change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Change.Location = new System.Drawing.Point(272, 39);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(82, 28);
            this.Change.TabIndex = 18;
            this.Change.Text = "Change";
            this.Change.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Arrow
            // 
            this.Arrow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Arrow.Location = new System.Drawing.Point(115, 3);
            this.Arrow.Name = "Arrow";
            this.Arrow.Size = new System.Drawing.Size(128, 124);
            this.Arrow.TabIndex = 1;
            this.Arrow.TabStop = false;
            // 
            // Open
            // 
            this.Open.AutoSize = true;
            this.Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open.Location = new System.Drawing.Point(29, 101);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(73, 29);
            this.Open.TabIndex = 16;
            this.Open.Text = "Open";
            // 
            // Symbol
            // 
            this.Symbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Symbol.AutoSize = true;
            this.Symbol.BackColor = System.Drawing.Color.White;
            this.Symbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Symbol.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Symbol.Location = new System.Drawing.Point(272, 11);
            this.Symbol.Name = "Symbol";
            this.Symbol.Size = new System.Drawing.Size(72, 29);
            this.Symbol.TabIndex = 13;
            this.Symbol.Text = "AAPL";
            // 
            // High
            // 
            this.High.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.High.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.High.Location = new System.Drawing.Point(272, 101);
            this.High.Name = "High";
            this.High.Size = new System.Drawing.Size(82, 28);
            this.High.TabIndex = 9;
            this.High.Text = "High";
            this.High.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Low
            // 
            this.Low.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Low.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Low.Location = new System.Drawing.Point(150, 101);
            this.Low.Name = "Low";
            this.Low.Size = new System.Drawing.Size(93, 28);
            this.Low.TabIndex = 12;
            this.Low.Text = "Low";
            // 
            // LastTrade
            // 
            this.LastTrade.AutoSize = true;
            this.LastTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastTrade.Location = new System.Drawing.Point(26, 39);
            this.LastTrade.Name = "LastTrade";
            this.LastTrade.Size = new System.Drawing.Size(197, 42);
            this.LastTrade.TabIndex = 11;
            this.LastTrade.Text = "Last Trade";
            // 
            // Company
            // 
            this.Company.AutoEllipsis = true;
            this.Company.BackColor = System.Drawing.Color.Transparent;
            this.Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Company.Location = new System.Drawing.Point(27, 3);
            this.Company.Name = "Company";
            this.Company.Size = new System.Drawing.Size(226, 37);
            this.Company.TabIndex = 8;
            this.Company.Text = "Compania fshzl";
            // 
            // cmLink
            // 
            this.cmLink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tsSymbol,
            this.tsOpenLink});
            this.cmLink.Name = "cmLink";
            this.cmLink.Size = new System.Drawing.Size(153, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Image = global::Mawenzy.Plugins.Properties.Resources.cc_yahoo_finance;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShowShortcutKeys = false;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Sticker Plugin";
            // 
            // tsSymbol
            // 
            this.tsSymbol.Enabled = false;
            this.tsSymbol.Name = "tsSymbol";
            this.tsSymbol.Size = new System.Drawing.Size(152, 22);
            this.tsSymbol.Text = "Symbol: ";
            // 
            // tsOpenLink
            // 
            this.tsOpenLink.Image = global::Mawenzy.Plugins.Properties.Resources.Crystal_Clear_mimetype_log;
            this.tsOpenLink.Name = "tsOpenLink";
            this.tsOpenLink.Size = new System.Drawing.Size(152, 22);
            this.tsOpenLink.Text = "Open: {LINK}";
            this.tsOpenLink.Click += new System.EventHandler(this.openLink);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Mawenzy.Plugins.Properties.Resources.stickerHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // SticketLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(labOpen);
            this.Controls.Add(this.Open);
            this.Controls.Add(labLow);
            this.Controls.Add(this.Symbol);
            this.Controls.Add(this.Company);
            this.Controls.Add(this.LastTrade);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Low);
            this.Controls.Add(labHigh);
            this.Controls.Add(this.High);
            this.Controls.Add(this.Arrow);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SticketLayout";
            this.Size = new System.Drawing.Size(360, 128);
            ((System.ComponentModel.ISupportInitialize)(this.Arrow)).EndInit();
            this.cmLink.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox Arrow;
        internal System.Windows.Forms.Label Open;
        internal System.Windows.Forms.Label Symbol;
        internal System.Windows.Forms.Label High;
        internal System.Windows.Forms.Label Low;
        internal System.Windows.Forms.Label LastTrade;
        internal System.Windows.Forms.Label Company;
        internal System.Windows.Forms.Label Change;
        internal System.Windows.Forms.ContextMenuStrip cmLink;
        internal System.Windows.Forms.ToolStripMenuItem tsOpenLink;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem tsSymbol;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
