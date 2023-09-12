using System.Drawing;
namespace Mawenzy.Plugins.Google_Plugs.Weather
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
            System.Windows.Forms.GroupBox groupTitle;
            Mawenzy.Properties.GlobalSettings globalSettings15 = new Mawenzy.Properties.GlobalSettings();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labRegion = new System.Windows.Forms.Label();
            this.tbRegion = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWeatherURL = new System.Windows.Forms.TextBox();
            groupTitle = new System.Windows.Forms.GroupBox();
            groupTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            groupTitle.Controls.Add(this.tableLayoutPanel1);
            groupTitle.Controls.Add(this.pictureBox1);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Google Weather";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.50211F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.49789F));
            this.tableLayoutPanel1.Controls.Add(this.labRegion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbRegion, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbWeatherURL, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 62);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labRegion
            // 
            this.labRegion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labRegion.AutoSize = true;
            this.labRegion.Location = new System.Drawing.Point(3, 9);
            this.labRegion.Name = "labRegion";
            this.labRegion.Size = new System.Drawing.Size(44, 13);
            this.labRegion.TabIndex = 0;
            this.labRegion.Text = "Region:";
            this.labRegion.Click += new System.EventHandler(this.labRegion_Click);
            // 
            // tbRegion
            // 
            this.tbRegion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            globalSettings15.CompressTextures = true;
            globalSettings15.MasterKey = "12345TheKindOfThingAnIdiotWouldHaveOnHisLuggage";
            globalSettings15.MotionBlur = false;
            globalSettings15.Region = "53092";
            globalSettings15.SettingsKey = "";
            globalSettings15.Stereo3DMode = "None";
            this.tbRegion.DataBindings.Add(new System.Windows.Forms.Binding("Text", globalSettings15, "Region", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbRegion.Location = new System.Drawing.Point(66, 5);
            this.tbRegion.Name = "tbRegion";
            this.tbRegion.Size = new System.Drawing.Size(195, 20);
            this.tbRegion.TabIndex = 1;
            this.tbRegion.Text = globalSettings15.Region;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Mawenzy.Plugins.Google_Plugs.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(304, 230);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 60);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Link URL:";
            this.label1.Click += new System.EventHandler(this.labRegion_Click);
            // 
            // tbWeatherURL
            // 
            this.tbWeatherURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWeatherURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.Google_Plugs.Properties.GoogleSettings.Default, "WeatherURL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbWeatherURL.Location = new System.Drawing.Point(66, 36);
            this.tbWeatherURL.Name = "tbWeatherURL";
            this.tbWeatherURL.Size = new System.Drawing.Size(405, 20);
            this.tbWeatherURL.TabIndex = 1;
            this.tbWeatherURL.Text = global::Mawenzy.Plugins.Google_Plugs.Properties.GoogleSettings.Default.WeatherURL;
            // 
            // GWConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "GWConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labRegion;
        private System.Windows.Forms.TextBox tbRegion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWeatherURL;
    }
}
