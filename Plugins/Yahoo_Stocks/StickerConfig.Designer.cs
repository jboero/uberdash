using System.Drawing;
namespace Mawenzy.Feeds
{
    partial class StickerConfig
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
            System.Windows.Forms.Label lab;
            this.labButton = new System.Windows.Forms.Label();
            this.miConfig = new Mawenzy.UI.MouseInputConfigger();
            this.labDelay = new System.Windows.Forms.Label();
            this.tbDelay = new System.Windows.Forms.TrackBar();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.tbSymbols = new System.Windows.Forms.TextBox();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.helper = new System.Windows.Forms.HelpProvider();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            groupTitle = new System.Windows.Forms.GroupBox();
            lab = new System.Windows.Forms.Label();
            groupTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            groupTitle.Controls.Add(this.labButton);
            groupTitle.Controls.Add(this.miConfig);
            groupTitle.Controls.Add(this.labDelay);
            groupTitle.Controls.Add(this.tbDelay);
            groupTitle.Controls.Add(this.btnForeColor);
            groupTitle.Controls.Add(this.btnBackColor);
            groupTitle.Controls.Add(lab);
            groupTitle.Controls.Add(this.tbSymbols);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Stock Ticker";
            // 
            // labButton
            // 
            this.labButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.helper.SetHelpKeyword(this.labButton, "");
            this.helper.SetHelpString(this.labButton, "How often the selected stock symbols are updated from Yahoo.");
            this.labButton.Location = new System.Drawing.Point(3, 122);
            this.labButton.Name = "labButton";
            this.helper.SetShowHelp(this.labButton, true);
            this.labButton.Size = new System.Drawing.Size(89, 45);
            this.labButton.TabIndex = 14;
            this.labButton.Text = "Mouse input:";
            this.labButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // miConfig
            // 
            this.miConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.miConfig.Button = global::Mawenzy.Plugins.PluginSettings.Default.StickerMouseButton;
            this.miConfig.DataBindings.Add(new System.Windows.Forms.Binding("Button", global::Mawenzy.Plugins.PluginSettings.Default, "StickerMouseButton", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.miConfig.DataBindings.Add(new System.Windows.Forms.Binding("Modifiers", global::Mawenzy.Plugins.PluginSettings.Default, "StickerModifierKeys", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.miConfig.Location = new System.Drawing.Point(98, 119);
            this.miConfig.Modifiers = global::Mawenzy.Plugins.PluginSettings.Default.StickerModifierKeys;
            this.miConfig.Name = "miConfig";
            this.miConfig.Size = new System.Drawing.Size(231, 48);
            this.miConfig.TabIndex = 3;
            // 
            // labDelay
            // 
            this.labDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.helper.SetHelpKeyword(this.labDelay, "");
            this.helper.SetHelpString(this.labDelay, "How often the selected stock symbols are updated from Yahoo.");
            this.labDelay.Location = new System.Drawing.Point(3, 173);
            this.labDelay.Name = "labDelay";
            this.helper.SetShowHelp(this.labDelay, true);
            this.labDelay.Size = new System.Drawing.Size(89, 45);
            this.labDelay.TabIndex = 13;
            this.labDelay.Text = "Reload delay:";
            this.labDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbDelay
            // 
            this.tbDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDelay.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "MawenzyMarqueeSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDelay.Location = new System.Drawing.Point(98, 173);
            this.tbDelay.Maximum = 3600;
            this.tbDelay.Minimum = 5;
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(385, 45);
            this.tbDelay.TabIndex = 12;
            this.tbDelay.TickFrequency = 60;
            this.tbDelay.Value = global::Mawenzy.Plugins.PluginSettings.Default.MawenzyMarqueeSpeed;
            this.tbDelay.Scroll += new System.EventHandler(this.tbDelay_Scroll);
            // 
            // btnForeColor
            // 
            this.btnForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForeColor.BackColor = global::Mawenzy.Plugins.PluginSettings.Default.StickerBottomColor;
            this.btnForeColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Mawenzy.Plugins.PluginSettings.Default, "StickerBottomColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnForeColor.Location = new System.Drawing.Point(3, 260);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(480, 30);
            this.btnForeColor.TabIndex = 11;
            this.btnForeColor.Text = "Bottom Color";
            this.btnForeColor.UseVisualStyleBackColor = false;
            this.btnForeColor.Click += new System.EventHandler(this.ColorChange);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackColor.BackColor = global::Mawenzy.Plugins.PluginSettings.Default.StickerBackColor;
            this.btnBackColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Mawenzy.Plugins.PluginSettings.Default, "StickerBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnBackColor.Location = new System.Drawing.Point(3, 224);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(480, 30);
            this.btnBackColor.TabIndex = 3;
            this.btnBackColor.Text = "Top Color";
            this.btnBackColor.UseVisualStyleBackColor = false;
            this.btnBackColor.Click += new System.EventHandler(this.ColorChange);
            // 
            // lab
            // 
            lab.AutoSize = true;
            lab.Location = new System.Drawing.Point(6, 22);
            lab.Name = "lab";
            lab.Size = new System.Drawing.Size(150, 13);
            lab.TabIndex = 10;
            lab.Text = "Symbols separated by comma:";
            // 
            // tbSymbols
            // 
            this.tbSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSymbols.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Mawenzy.Plugins.PluginSettings.Default, "StickerSymbols", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbSymbols.Location = new System.Drawing.Point(3, 38);
            this.tbSymbols.Multiline = true;
            this.tbSymbols.Name = "tbSymbols";
            this.tbSymbols.Size = new System.Drawing.Size(480, 75);
            this.tbSymbols.TabIndex = 9;
            this.tbSymbols.Text = global::Mawenzy.Plugins.PluginSettings.Default.StickerSymbols;
            // 
            // colorPicker
            // 
            this.colorPicker.Color = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // StickerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "StickerConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            groupTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelay)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.TextBox tbSymbols;
        private System.Windows.Forms.HelpProvider helper;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.TrackBar tbDelay;
        private System.Windows.Forms.Label labDelay;
        private Mawenzy.UI.MouseInputConfigger miConfig;
        private System.Windows.Forms.Label labButton;
    }
}
