namespace Mawenzy.Backgrounds
{
    partial class OverlayDesktopConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverlayDesktopConfig));
            this.labExplain = new System.Windows.Forms.Label();
            this.tbSample = new System.Windows.Forms.TextBox();
            this.btnPicker = new System.Windows.Forms.Button();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            groupTitle = new System.Windows.Forms.GroupBox();
            groupTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            groupTitle.Controls.Add(this.labExplain);
            groupTitle.Controls.Add(this.tbSample);
            groupTitle.Controls.Add(this.btnPicker);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Overlay Background Color";
            // 
            // labExplain
            // 
            this.labExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labExplain.Location = new System.Drawing.Point(6, 16);
            this.labExplain.Name = "labExplain";
            this.labExplain.Size = new System.Drawing.Size(474, 193);
            this.labExplain.TabIndex = 2;
            this.labExplain.Text = resources.GetString("labExplain.Text");
            // 
            // tbSample
            // 
            this.tbSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSample.BackColor = global::Mawenzy.Plugins.PluginSettings.Default.OverlayColor;
            this.tbSample.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Mawenzy.Plugins.PluginSettings.Default, "OverlayColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSample.Location = new System.Drawing.Point(6, 212);
            this.tbSample.Multiline = true;
            this.tbSample.Name = "tbSample";
            this.tbSample.Size = new System.Drawing.Size(474, 49);
            this.tbSample.TabIndex = 1;
            this.tbSample.Text = "Overlay Sample";
            this.tbSample.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPicker
            // 
            this.btnPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPicker.Location = new System.Drawing.Point(339, 267);
            this.btnPicker.Name = "btnPicker";
            this.btnPicker.Size = new System.Drawing.Size(141, 23);
            this.btnPicker.TabIndex = 0;
            this.btnPicker.Text = "Select Overlay Color...";
            this.btnPicker.UseVisualStyleBackColor = true;
            // 
            // OverlayDesktopConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "OverlayDesktopConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            groupTitle.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.Button btnPicker;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox tbSample;
        private System.Windows.Forms.Label labExplain;
    }
}
