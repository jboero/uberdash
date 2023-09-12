namespace Mawenzy.Plugins.Google_Plugs.Weather
{
    partial class DayLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayLayout));
            this.pbCurrent = new System.Windows.Forms.PictureBox();
            this.labDay = new System.Windows.Forms.Label();
            this.labCond = new System.Windows.Forms.Label();
            this.labLowTemp = new System.Windows.Forms.Label();
            this.labHighTemp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCurrent
            // 
            this.pbCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCurrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCurrent.Location = new System.Drawing.Point(164, 9);
            this.pbCurrent.Name = "pbCurrent";
            this.pbCurrent.Size = new System.Drawing.Size(80, 80);
            this.pbCurrent.TabIndex = 2;
            this.pbCurrent.TabStop = false;
            // 
            // labDay
            // 
            this.labDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labDay.AutoSize = true;
            this.labDay.BackColor = System.Drawing.Color.Transparent;
            this.labDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDay.Location = new System.Drawing.Point(3, 9);
            this.labDay.Name = "labDay";
            this.labDay.Size = new System.Drawing.Size(46, 24);
            this.labDay.TabIndex = 4;
            this.labDay.Text = "date";
            this.labDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labCond
            // 
            this.labCond.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labCond.AutoSize = true;
            this.labCond.BackColor = System.Drawing.Color.Transparent;
            this.labCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCond.Location = new System.Drawing.Point(84, 15);
            this.labCond.Name = "labCond";
            this.labCond.Size = new System.Drawing.Size(38, 16);
            this.labCond.TabIndex = 9;
            this.labCond.Text = "cond";
            this.labCond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labLowTemp
            // 
            this.labLowTemp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labLowTemp.AutoSize = true;
            this.labLowTemp.BackColor = System.Drawing.Color.Transparent;
            this.labLowTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLowTemp.Location = new System.Drawing.Point(3, 65);
            this.labLowTemp.Name = "labLowTemp";
            this.labLowTemp.Size = new System.Drawing.Size(52, 24);
            this.labLowTemp.TabIndex = 8;
            this.labLowTemp.Text = "temp";
            this.labLowTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labHighTemp
            // 
            this.labHighTemp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labHighTemp.AutoSize = true;
            this.labHighTemp.BackColor = System.Drawing.Color.Transparent;
            this.labHighTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHighTemp.Location = new System.Drawing.Point(83, 65);
            this.labHighTemp.Name = "labHighTemp";
            this.labHighTemp.Size = new System.Drawing.Size(52, 24);
            this.labHighTemp.TabIndex = 8;
            this.labHighTemp.Text = "temp";
            this.labHighTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // DayLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.labDay);
            this.Controls.Add(this.labCond);
            this.Controls.Add(this.labLowTemp);
            this.Controls.Add(this.labHighTemp);
            this.Controls.Add(this.pbCurrent);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DayLayout";
            this.Size = new System.Drawing.Size(256, 96);
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbCurrent;
        internal System.Windows.Forms.Label labDay;
        internal System.Windows.Forms.Label labCond;
        internal System.Windows.Forms.Label labLowTemp;
        internal System.Windows.Forms.Label labHighTemp;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
