using System.Drawing;
namespace Mawenzy.Backgrounds
{
    partial class SlideShowConfig
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
            System.Windows.Forms.Label labDuration;
            System.Windows.Forms.GroupBox groupTitle;
            System.Windows.Forms.Label labMode;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackDuration = new System.Windows.Forms.TrackBar();
            this.numSpeed = new System.Windows.Forms.TrackBar();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.checkCompressImages = new System.Windows.Forms.CheckBox();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            labDuration = new System.Windows.Forms.Label();
            groupTitle = new System.Windows.Forms.GroupBox();
            labMode = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // labDuration
            // 
            labDuration.AutoSize = true;
            labDuration.Location = new System.Drawing.Point(6, 60);
            labDuration.Name = "labDuration";
            labDuration.Size = new System.Drawing.Size(107, 13);
            labDuration.TabIndex = 1;
            labDuration.Text = "Duration (in seconds)";
            // 
            // groupTitle
            // 
            groupTitle.Controls.Add(this.comboBox1);
            groupTitle.Controls.Add(labMode);
            groupTitle.Controls.Add(this.trackDuration);
            groupTitle.Controls.Add(label2);
            groupTitle.Controls.Add(this.numSpeed);
            groupTitle.Controls.Add(this.btnBrowse);
            groupTitle.Controls.Add(this.txtPath);
            groupTitle.Controls.Add(label1);
            groupTitle.Controls.Add(labDuration);
            groupTitle.Controls.Add(this.numDuration);
            groupTitle.Controls.Add(this.checkCompressImages);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Slideshow Background";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.PluginSettings.Default, "SlideShow_rotationMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sequential",
            "Random"});
            this.comboBox1.Location = new System.Drawing.Point(119, 158);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = global::Mawenzy.Plugins.PluginSettings.Default.SlideShow_rotationMode;
            // 
            // labMode
            // 
            labMode.AutoSize = true;
            labMode.Location = new System.Drawing.Point(6, 161);
            labMode.Name = "labMode";
            labMode.Size = new System.Drawing.Size(50, 13);
            labMode.TabIndex = 9;
            labMode.Text = "Rotation:";
            // 
            // trackDuration
            // 
            this.trackDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackDuration.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "SlideShowDuration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackDuration.Location = new System.Drawing.Point(219, 59);
            this.trackDuration.Maximum = 600;
            this.trackDuration.Minimum = 3;
            this.trackDuration.Name = "trackDuration";
            this.trackDuration.Size = new System.Drawing.Size(261, 45);
            this.trackDuration.TabIndex = 7;
            this.trackDuration.TickFrequency = 60;
            this.trackDuration.Value = global::Mawenzy.Plugins.PluginSettings.Default.SlideShowDuration;
            this.trackDuration.ValueChanged += new System.EventHandler(this.trackDuration_ValueChanged);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 121);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 13);
            label2.TabIndex = 6;
            label2.Text = "Fade Speed (%)";
            // 
            // numSpeed
            // 
            this.numSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "SlideShowSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numSpeed.Location = new System.Drawing.Point(119, 110);
            this.numSpeed.Maximum = 1000;
            this.numSpeed.Minimum = 1;
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(361, 45);
            this.numSpeed.TabIndex = 5;
            this.numSpeed.TickFrequency = 100;
            this.numSpeed.Value = global::Mawenzy.Plugins.PluginSettings.Default.SlideShowSpeed;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(405, 30);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.PluginSettings.Default, "SlideShowPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPath.Location = new System.Drawing.Point(9, 32);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(390, 20);
            this.txtPath.TabIndex = 3;
            this.txtPath.Text = global::Mawenzy.Plugins.PluginSettings.Default.SlideShowPath;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(154, 13);
            label1.TabIndex = 1;
            label1.Text = "Display pictures from the folder:";
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(119, 58);
            this.numDuration.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(94, 20);
            this.numDuration.TabIndex = 0;
            this.numDuration.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numDuration.ValueChanged += new System.EventHandler(this.numDuration_ValueChanged);
            // 
            // checkCompressImages
            // 
            this.checkCompressImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkCompressImages.AutoSize = true;
            this.checkCompressImages.Checked = global::Mawenzy.Plugins.PluginSettings.Default.SlideShowCompress;
            this.checkCompressImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCompressImages.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Mawenzy.Plugins.PluginSettings.Default, "SlideShowCompress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkCompressImages.Location = new System.Drawing.Point(6, 273);
            this.checkCompressImages.Name = "checkCompressImages";
            this.checkCompressImages.Size = new System.Drawing.Size(109, 17);
            this.checkCompressImages.TabIndex = 0;
            this.checkCompressImages.Text = "Compress Images";
            // 
            // SlideShowConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "SlideShowConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            groupTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.TrackBar numSpeed;
        private System.Windows.Forms.TrackBar trackDuration;
        private System.Windows.Forms.CheckBox checkCompressImages;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
