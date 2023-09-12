namespace Mawenzy.Plugins.Google_Plugs.Alerts
{
    partial class AlertsConfig
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labGID = new System.Windows.Forms.Label();
            this.labGPW = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbPW = new Mawenzy.UI.EncryptedTextBox();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            groupTitle = new System.Windows.Forms.GroupBox();
            groupTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.Controls.Add(this.tableLayoutPanel1);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Google Calendar";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labGID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labGPW, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbPW, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 54);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labGID
            // 
            this.labGID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labGID.AutoSize = true;
            this.labGID.Location = new System.Drawing.Point(3, 6);
            this.labGID.Name = "labGID";
            this.labGID.Size = new System.Drawing.Size(58, 13);
            this.labGID.TabIndex = 0;
            this.labGID.Text = "Google ID:";
            // 
            // labGPW
            // 
            this.labGPW.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labGPW.AutoSize = true;
            this.labGPW.Location = new System.Drawing.Point(3, 32);
            this.labGPW.Name = "labGPW";
            this.labGPW.Size = new System.Drawing.Size(93, 13);
            this.labGPW.TabIndex = 0;
            this.labGPW.Text = "Google Password:";
            // 
            // tbID
            // 
            this.tbID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbID.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.Google_Plugs.Properties.GoogleSettings.Default, "GoogleID", true));
            this.tbID.Location = new System.Drawing.Point(102, 3);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(184, 20);
            this.tbID.TabIndex = 1;
            this.tbID.Text = global::Mawenzy.Plugins.Google_Plugs.Properties.GoogleSettings.Default.GoogleID;
            // 
            // tbPW
            // 
            this.tbPW.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbPW.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.Google_Plugs.Properties.GoogleSettings.Default, "GooglePW", true));
            this.tbPW.Location = new System.Drawing.Point(102, 29);
            this.tbPW.Name = "tbPW";
            this.tbPW.PasswordChar = '*';
            this.tbPW.Size = new System.Drawing.Size(184, 20);
            this.tbPW.TabIndex = 2;
            this.tbPW.Text = global::Mawenzy.Plugins.Google_Plugs.Properties.GoogleSettings.Default.GooglePW;
            // 
            // AlertsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "AlertsConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labGID;
        private System.Windows.Forms.Label labGPW;
        private System.Windows.Forms.TextBox tbID;
        private Mawenzy.UI.EncryptedTextBox tbPW;
    }
}
