namespace Mawenzy.Plugins.Google_Plugs.Weather
{
    partial class WeatherLayout
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbCurrent = new System.Windows.Forms.PictureBox();
            this.labKDate = new System.Windows.Forms.Label();
            this.labLocation = new System.Windows.Forms.Label();
            this.labCond = new System.Windows.Forms.Label();
            this.labTemp = new System.Windows.Forms.Label();
            this.labWind = new System.Windows.Forms.Label();
            this.labHumidity = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmWeather = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openGoogleWeatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmWeather.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Location = new System.Drawing.Point(275, 168);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(76, 21);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pbCurrent
            // 
            this.pbCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCurrent.BackColor = System.Drawing.Color.Transparent;
            this.pbCurrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCurrent.Location = new System.Drawing.Point(271, 14);
            this.pbCurrent.Name = "pbCurrent";
            this.pbCurrent.Size = new System.Drawing.Size(80, 80);
            this.pbCurrent.TabIndex = 2;
            this.pbCurrent.TabStop = false;
            // 
            // labKDate
            // 
            this.labKDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labKDate.BackColor = System.Drawing.Color.Transparent;
            this.labKDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labKDate.Location = new System.Drawing.Point(5, 156);
            this.labKDate.Name = "labKDate";
            this.labKDate.Size = new System.Drawing.Size(80, 21);
            this.labKDate.TabIndex = 4;
            this.labKDate.Text = "date";
            this.labKDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labLocation
            // 
            this.labLocation.AutoSize = true;
            this.labLocation.BackColor = System.Drawing.Color.Transparent;
            this.labLocation.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLocation.Location = new System.Drawing.Point(8, 14);
            this.labLocation.Name = "labLocation";
            this.labLocation.Size = new System.Drawing.Size(188, 33);
            this.labLocation.TabIndex = 7;
            this.labLocation.Text = "Thiensville, WI";
            this.labLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labCond
            // 
            this.labCond.AutoSize = true;
            this.labCond.BackColor = System.Drawing.Color.Transparent;
            this.labCond.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCond.Location = new System.Drawing.Point(8, 47);
            this.labCond.Name = "labCond";
            this.labCond.Size = new System.Drawing.Size(63, 29);
            this.labCond.TabIndex = 9;
            this.labCond.Text = "cond";
            this.labCond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTemp
            // 
            this.labTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labTemp.AutoSize = true;
            this.labTemp.BackColor = System.Drawing.Color.Transparent;
            this.labTemp.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTemp.Location = new System.Drawing.Point(284, 97);
            this.labTemp.Name = "labTemp";
            this.labTemp.Size = new System.Drawing.Size(67, 29);
            this.labTemp.TabIndex = 8;
            this.labTemp.Text = "temp";
            this.labTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labWind
            // 
            this.labWind.BackColor = System.Drawing.Color.Transparent;
            this.labWind.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWind.Location = new System.Drawing.Point(8, 76);
            this.labWind.Name = "labWind";
            this.labWind.Size = new System.Drawing.Size(237, 29);
            this.labWind.TabIndex = 11;
            this.labWind.Text = "wind";
            this.labWind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labHumidity
            // 
            this.labHumidity.BackColor = System.Drawing.Color.Transparent;
            this.labHumidity.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHumidity.Location = new System.Drawing.Point(8, 103);
            this.labHumidity.Name = "labHumidity";
            this.labHumidity.Size = new System.Drawing.Size(209, 29);
            this.labHumidity.TabIndex = 10;
            this.labHumidity.Text = "humidity";
            this.labHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Mawenzy.Plugins.Properties.Resources.protoborderless;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // cmWeather
            // 
            this.cmWeather.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGoogleWeatherToolStripMenuItem,
            this.locationToolStripMenuItem});
            this.cmWeather.Name = "cmWeather";
            this.cmWeather.Size = new System.Drawing.Size(201, 48);
            this.cmWeather.Opening += new System.ComponentModel.CancelEventHandler(this.cmWeather_Opening);
            // 
            // openGoogleWeatherToolStripMenuItem
            // 
            this.openGoogleWeatherToolStripMenuItem.Name = "openGoogleWeatherToolStripMenuItem";
            this.openGoogleWeatherToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.openGoogleWeatherToolStripMenuItem.Text = "Open Google Weather...";
            this.openGoogleWeatherToolStripMenuItem.Click += new System.EventHandler(this.openGoogleWeatherToolStripMenuItem_Click);
            // 
            // locationToolStripMenuItem
            // 
            this.locationToolStripMenuItem.Enabled = false;
            this.locationToolStripMenuItem.Name = "locationToolStripMenuItem";
            this.locationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.locationToolStripMenuItem.Text = "Location: ";
            // 
            // WeatherLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.labLocation);
            this.Controls.Add(this.labTemp);
            this.Controls.Add(this.labCond);
            this.Controls.Add(this.labWind);
            this.Controls.Add(this.pbCurrent);
            this.Controls.Add(this.labHumidity);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.labKDate);
            this.Controls.Add(this.pictureBox1);
            this.Name = "WeatherLayout";
            this.Size = new System.Drawing.Size(362, 197);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmWeather.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbCurrent;
        internal System.Windows.Forms.Label labKDate;
        internal System.Windows.Forms.Label labLocation;
        internal System.Windows.Forms.Label labCond;
        internal System.Windows.Forms.Label labTemp;
        internal System.Windows.Forms.Label labWind;
        internal System.Windows.Forms.Label labHumidity;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem openGoogleWeatherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip cmWeather;
        private System.Windows.Forms.PictureBox pbLogo;

    }
}
