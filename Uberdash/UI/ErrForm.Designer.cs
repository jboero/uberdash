namespace Mawenzy.UI
{
    partial class ErrForm
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
            System.Windows.Forms.Label labErr;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label labDetail;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Detail = new System.Windows.Forms.TextBox();
            this.Summary = new System.Windows.Forms.TextBox();
            this.ErrCode = new System.Windows.Forms.TextBox();
            this.bugBrowser = new System.Windows.Forms.WebBrowser();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.cbDetails = new System.Windows.Forms.CheckBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.cbErrMode = new System.Windows.Forms.ComboBox();
            this.pbPluginIcon = new System.Windows.Forms.PictureBox();
            labErr = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            labDetail = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPluginIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labErr
            // 
            labErr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            labErr.AutoSize = true;
            labErr.Location = new System.Drawing.Point(3, 6);
            labErr.Name = "labErr";
            labErr.Size = new System.Drawing.Size(60, 13);
            labErr.TabIndex = 0;
            labErr.Text = "Error Code:";
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 13);
            label1.TabIndex = 2;
            label1.Text = "Summary:";
            // 
            // labDetail
            // 
            labDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            labDetail.AutoSize = true;
            labDetail.Location = new System.Drawing.Point(3, 128);
            labDetail.Name = "labDetail";
            labDetail.Size = new System.Drawing.Size(60, 13);
            labDetail.TabIndex = 4;
            labDetail.Text = "Detail:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Detail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(labDetail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Summary, 1, 1);
            this.tableLayoutPanel1.Controls.Add(labErr, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ErrCode, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 196);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Detail
            // 
            this.Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Detail.Location = new System.Drawing.Point(69, 76);
            this.Detail.Multiline = true;
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            this.Detail.Size = new System.Drawing.Size(450, 117);
            this.Detail.TabIndex = 7;
            // 
            // Summary
            // 
            this.Summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Summary.Location = new System.Drawing.Point(69, 29);
            this.Summary.Multiline = true;
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            this.Summary.Size = new System.Drawing.Size(450, 41);
            this.Summary.TabIndex = 3;
            // 
            // ErrCode
            // 
            this.ErrCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ErrCode.Location = new System.Drawing.Point(69, 3);
            this.ErrCode.Name = "ErrCode";
            this.ErrCode.ReadOnly = true;
            this.ErrCode.Size = new System.Drawing.Size(111, 20);
            this.ErrCode.TabIndex = 1;
            // 
            // bugBrowser
            // 
            this.bugBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bugBrowser.Location = new System.Drawing.Point(12, 207);
            this.bugBrowser.MinimumSize = new System.Drawing.Size(20, 1);
            this.bugBrowser.Name = "bugBrowser";
            this.bugBrowser.Size = new System.Drawing.Size(522, 1);
            this.bugBrowser.TabIndex = 1;
            this.bugBrowser.Visible = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Location = new System.Drawing.Point(459, 214);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnContinue.Location = new System.Drawing.Point(378, 214);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // cbDetails
            // 
            this.cbDetails.AutoSize = true;
            this.cbDetails.Location = new System.Drawing.Point(198, 18);
            this.cbDetails.Name = "cbDetails";
            this.cbDetails.Size = new System.Drawing.Size(152, 17);
            this.cbDetails.TabIndex = 3;
            this.cbDetails.Text = "View current details online.";
            this.cbDetails.UseVisualStyleBackColor = true;
            this.cbDetails.CheckedChanged += new System.EventHandler(this.detail_CheckedChanged);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(12, 214);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(84, 23);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report Bug";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.ReportBug);
            // 
            // btnDebug
            // 
            this.btnDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebug.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDebug.Location = new System.Drawing.Point(297, 214);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 2;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // cbErrMode
            // 
            this.cbErrMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbErrMode.FormattingEnabled = true;
            this.cbErrMode.Items.AddRange(new object[] {
            "Balloon tip in tray.",
            "Dialog with bug reporting.",
            "System beep with log."});
            this.cbErrMode.Location = new System.Drawing.Point(102, 216);
            this.cbErrMode.Name = "cbErrMode";
            this.cbErrMode.Size = new System.Drawing.Size(189, 21);
            this.cbErrMode.TabIndex = 4;
            this.cbErrMode.SelectedIndexChanged += new System.EventHandler(this.cbErrMode_SelectedIndexChanged);
            // 
            // pbPluginIcon
            // 
            this.pbPluginIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPluginIcon.Location = new System.Drawing.Point(458, 11);
            this.pbPluginIcon.Name = "pbPluginIcon";
            this.pbPluginIcon.Size = new System.Drawing.Size(48, 48);
            this.pbPluginIcon.TabIndex = 5;
            this.pbPluginIcon.TabStop = false;
            // 
            // ErrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnContinue;
            this.ClientSize = new System.Drawing.Size(546, 249);
            this.Controls.Add(this.cbErrMode);
            this.Controls.Add(this.cbDetails);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.bugBrowser);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pbPluginIcon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(540, 160);
            this.Name = "ErrForm";
            this.Text = "Irwin";
            this.Load += new System.EventHandler(this.ErrForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPluginIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox ErrCode;
        private System.Windows.Forms.TextBox Summary;
        private System.Windows.Forms.WebBrowser bugBrowser;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.CheckBox cbDetails;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TextBox Detail;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.ComboBox cbErrMode;
        private System.Windows.Forms.PictureBox pbPluginIcon;
    }
}