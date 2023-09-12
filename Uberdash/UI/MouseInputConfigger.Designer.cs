
using Mawenzy.Properties;
namespace Mawenzy.UI
{
    partial class MouseInputConfigger
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labButton = new System.Windows.Forms.Label();
            this.labModif = new System.Windows.Forms.Label();
            this.cbButton = new System.Windows.Forms.ComboBox();
            this.cbModifier = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mawenzy.Properties.Resources.Crystal_Clear_app_mouse;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labButton
            // 
            this.labButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labButton.Location = new System.Drawing.Point(52, 3);
            this.labButton.Name = "labButton";
            this.labButton.Size = new System.Drawing.Size(49, 17);
            this.labButton.TabIndex = 1;
            this.labButton.Text = "Button";
            this.labButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labModif
            // 
            this.labModif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labModif.Location = new System.Drawing.Point(52, 26);
            this.labModif.Name = "labModif";
            this.labModif.Size = new System.Drawing.Size(49, 17);
            this.labModif.TabIndex = 2;
            this.labModif.Text = "Modifier";
            this.labModif.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbButton
            // 
            this.cbButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbButton.FormattingEnabled = true;
            this.cbButton.Location = new System.Drawing.Point(107, 2);
            this.cbButton.Name = "cbButton";
            this.cbButton.Size = new System.Drawing.Size(121, 21);
            this.cbButton.TabIndex = 1;
            // 
            // cbModifier
            // 
            this.cbModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModifier.FormattingEnabled = true;
            this.cbModifier.Location = new System.Drawing.Point(107, 25);
            this.cbModifier.Name = "cbModifier";
            this.cbModifier.Size = new System.Drawing.Size(121, 21);
            this.cbModifier.TabIndex = 2;
            this.cbModifier.SelectedIndexChanged += new System.EventHandler(this.cbModifier_SelectedIndexChanged);
            // 
            // MouseInputConfigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbModifier);
            this.Controls.Add(this.cbButton);
            this.Controls.Add(this.labModif);
            this.Controls.Add(this.labButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MouseInputConfigger";
            this.Size = new System.Drawing.Size(231, 48);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labButton;
        private System.Windows.Forms.Label labModif;
        private System.Windows.Forms.ComboBox cbButton;
        private System.Windows.Forms.ComboBox cbModifier;
    }
}
