namespace Mawenzy.Backgrounds
{
    partial class WinDesktopConfig
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
            this.chkCompress = new System.Windows.Forms.CheckBox();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            groupTitle = new System.Windows.Forms.GroupBox();
            groupTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.Controls.Add(this.chkCompress);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Plain old Wallpaper";
            // 
            // chkCompress
            // 
            this.chkCompress.AutoSize = true;
            this.chkCompress.Checked = global::Mawenzy.Properties.GlobalSettings.Default.CompressTextures;
            this.chkCompress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompress.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Mawenzy.Properties.GlobalSettings.Default, "CompressTextures", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCompress.Location = new System.Drawing.Point(6, 19);
            this.chkCompress.Name = "chkCompress";
            this.chkCompress.Size = new System.Drawing.Size(162, 17);
            this.chkCompress.TabIndex = 0;
            this.chkCompress.Text = "Compress Wallpaper Texture";
            this.chkCompress.UseVisualStyleBackColor = true;
            // 
            // WinDesktopConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "WinDesktopConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            groupTitle.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.CheckBox chkCompress;
    }
}
