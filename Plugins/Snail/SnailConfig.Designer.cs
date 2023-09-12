using System.Drawing;
using Mawenzy.Plugins;
namespace Mawenzy.Toys
{
    partial class SnailConfig
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label labBlur;
            System.Windows.Forms.Label labMax;
            this.tbBlur = new System.Windows.Forms.TrackBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkRotate = new System.Windows.Forms.CheckBox();
            this.numMaxPics = new System.Windows.Forms.NumericUpDown();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            groupTitle = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            labBlur = new System.Windows.Forms.Label();
            labMax = new System.Windows.Forms.Label();
            groupTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPics)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            groupTitle.Controls.Add(this.tbBlur);
            groupTitle.Controls.Add(this.comboBox1);
            groupTitle.Controls.Add(this.checkRotate);
            groupTitle.Controls.Add(label1);
            groupTitle.Controls.Add(labBlur);
            groupTitle.Controls.Add(labMax);
            groupTitle.Controls.Add(this.numMaxPics);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Picture Snail";
            // 
            // tbBlur
            // 
            this.tbBlur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBlur.DataBindings.Add(new System.Windows.Forms.Binding("Value", PluginSettings.Default, "SnailBlurQuality", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbBlur.Location = new System.Drawing.Point(3, 222);
            this.tbBlur.Maximum = 18;
            this.tbBlur.Minimum = 1;
            this.tbBlur.Name = "tbBlur";
            this.tbBlur.Size = new System.Drawing.Size(477, 45);
            this.tbBlur.TabIndex = 6;
            this.tbBlur.Value = PluginSettings.Default.SnailBlurQuality;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.PluginSettings.Default, "Snail3DMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Red/Blue",
            "Cross-eyed Stereograph"});
            this.comboBox1.Location = new System.Drawing.Point(285, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = global::Mawenzy.Plugins.PluginSettings.Default.Snail3DMode;
            // 
            // checkRotate
            // 
            this.checkRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkRotate.AutoSize = true;
            this.checkRotate.Checked = PluginSettings.Default.SnailRotateOnMouseWheel;
            this.checkRotate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRotate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", PluginSettings.Default, "SnailRotateOnMouseWheel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkRotate.Location = new System.Drawing.Point(9, 273);
            this.checkRotate.Name = "checkRotate";
            this.checkRotate.Size = new System.Drawing.Size(142, 17);
            this.checkRotate.TabIndex = 5;
            this.checkRotate.Text = "Rotate on Mouse Wheel";
            this.checkRotate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(186, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 13);
            label1.TabIndex = 4;
            label1.Text = "Stereographic 3D:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labBlur
            // 
            labBlur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            labBlur.AutoSize = true;
            labBlur.BackColor = System.Drawing.Color.Transparent;
            labBlur.Location = new System.Drawing.Point(6, 206);
            labBlur.Name = "labBlur";
            labBlur.Size = new System.Drawing.Size(63, 13);
            labBlur.TabIndex = 4;
            labBlur.Text = "Blur Quality:";
            labBlur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labMax
            // 
            labMax.AutoSize = true;
            labMax.BackColor = System.Drawing.Color.Transparent;
            labMax.Location = new System.Drawing.Point(6, 16);
            labMax.Name = "labMax";
            labMax.Size = new System.Drawing.Size(92, 13);
            labMax.TabIndex = 4;
            labMax.Text = "Maximum Pictures";
            labMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numMaxPics
            // 
            this.numMaxPics.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "SnailMaxPics", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMaxPics.Location = new System.Drawing.Point(104, 14);
            this.numMaxPics.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numMaxPics.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxPics.Name = "numMaxPics";
            this.numMaxPics.Size = new System.Drawing.Size(76, 20);
            this.numMaxPics.TabIndex = 3;
            this.numMaxPics.Value = global::Mawenzy.Plugins.PluginSettings.Default.SnailMaxPics;
            // 
            // SnailConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "SnailConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            groupTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPics)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.NumericUpDown numMaxPics;
        private System.Windows.Forms.CheckBox checkRotate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar tbBlur;
    }
}
