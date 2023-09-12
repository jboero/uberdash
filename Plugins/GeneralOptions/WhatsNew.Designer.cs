namespace Mawenzy.Plugins.Config
{
    partial class WhatsNew
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
            this.flower = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flower
            // 
            this.flower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flower.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flower.Location = new System.Drawing.Point(0, 0);
            this.flower.Name = "flower";
            this.flower.Size = new System.Drawing.Size(448, 175);
            this.flower.TabIndex = 0;
            // 
            // WhatsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flower);
            this.Name = "WhatsNew";
            this.Size = new System.Drawing.Size(448, 175);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flower;
    }
}
