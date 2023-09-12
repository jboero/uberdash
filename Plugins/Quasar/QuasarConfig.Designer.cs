using System.Drawing;
namespace Mawenzy.Toys
{
    partial class QuasarConfig
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
            this.cbSmooth = new System.Windows.Forms.CheckBox();
            this.lab = new System.Windows.Forms.Label();
            this.tbDetail = new System.Windows.Forms.TrackBar();
            this.labQuant = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TrackBar();
            groupTitle = new System.Windows.Forms.GroupBox();
            groupTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            groupTitle.Controls.Add(this.labQuant);
            groupTitle.Controls.Add(this.tbQuantity);
            groupTitle.Controls.Add(this.cbSmooth);
            groupTitle.Controls.Add(this.lab);
            groupTitle.Controls.Add(this.tbDetail);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Quasar Settings";
            // 
            // cbSmooth
            // 
            this.cbSmooth.AutoSize = true;
            this.cbSmooth.Checked = global::Mawenzy.Plugins.PluginSettings.Default.QuasarPointSmooth;
            this.cbSmooth.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Mawenzy.Plugins.PluginSettings.Default, "QuasarPointSmooth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbSmooth.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSmooth.Location = new System.Drawing.Point(3, 16);
            this.cbSmooth.Name = "cbSmooth";
            this.cbSmooth.Size = new System.Drawing.Size(480, 17);
            this.cbSmooth.TabIndex = 3;
            this.cbSmooth.Text = "Use Point Smooth";
            this.cbSmooth.UseVisualStyleBackColor = true;
            // 
            // lab
            // 
            this.lab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lab.Location = new System.Drawing.Point(3, 235);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(480, 13);
            this.lab.TabIndex = 1;
            this.lab.Text = "Detail";
            this.lab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDetail
            // 
            this.tbDetail.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "QuasarDetail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbDetail.Location = new System.Drawing.Point(3, 248);
            this.tbDetail.Maximum = 30;
            this.tbDetail.Minimum = 4;
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.Size = new System.Drawing.Size(480, 45);
            this.tbDetail.TabIndex = 0;
            this.tbDetail.Value = global::Mawenzy.Plugins.PluginSettings.Default.QuasarDetail;
            // 
            // labQuant
            // 
            this.labQuant.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labQuant.Location = new System.Drawing.Point(3, 177);
            this.labQuant.Name = "labQuant";
            this.labQuant.Size = new System.Drawing.Size(480, 13);
            this.labQuant.TabIndex = 5;
            this.labQuant.Text = "Quasar quantity";
            this.labQuant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbQuantity
            // 
            this.tbQuantity.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "QuasarCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbQuantity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbQuantity.Location = new System.Drawing.Point(3, 190);
            this.tbQuantity.Minimum = 1;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(480, 45);
            this.tbQuantity.TabIndex = 4;
            this.tbQuantity.Value = global::Mawenzy.Plugins.PluginSettings.Default.QuasarCount;
            // 
            // QuasarConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "QuasarConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            groupTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuantity)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TrackBar tbDetail;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.CheckBox cbSmooth;
        private System.Windows.Forms.Label labQuant;
        private System.Windows.Forms.TrackBar tbQuantity;

    }
}
