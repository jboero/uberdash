namespace Mawenzy.Plugins.GooglePlugins.Weather
{
    partial class GWConfig
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
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.labReg = new System.Windows.Forms.Label();
            this.tbRegion = new System.Windows.Forms.TextBox();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.tbRegion);
            this.gbMain.Controls.Add(this.labReg);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(464, 271);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Google Weather Config";
            // 
            // labReg
            // 
            this.labReg.Location = new System.Drawing.Point(6, 30);
            this.labReg.Name = "labReg";
            this.labReg.Size = new System.Drawing.Size(112, 21);
            this.labReg.TabIndex = 0;
            this.labReg.Text = "Region:";
            // 
            // tbRegion
            // 
            this.tbRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRegion.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.PluginSettings.Default, "NewsRegion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbRegion.Location = new System.Drawing.Point(124, 27);
            this.tbRegion.Name = "tbRegion";
            this.tbRegion.Size = new System.Drawing.Size(334, 20);
            this.tbRegion.TabIndex = 1;
            this.tbRegion.Text = global::Mawenzy.Plugins.PluginSettings.Default.NewsRegion;
            // 
            // GWConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMain);
            this.Name = "GWConfig";
            this.Size = new System.Drawing.Size(464, 271);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label labReg;
        private System.Windows.Forms.TextBox tbRegion;
    }
}
