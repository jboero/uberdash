using System.Drawing;
namespace Mawenzy.Config
{
    partial class MawenzyConfig
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
            System.Windows.Forms.GroupBox groupTitle;
            this.gbInterface = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labErrors = new System.Windows.Forms.Label();
            this.cbErrMode = new System.Windows.Forms.ComboBox();
            this.numFPS = new System.Windows.Forms.NumericUpDown();
            this.gbMawenzy = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbAlerts = new System.Windows.Forms.CheckBox();
            this.cbShowNews = new System.Windows.Forms.CheckBox();
            this.linkLab = new System.Windows.Forms.LinkLabel();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnGC = new System.Windows.Forms.Button();
            groupTitle = new System.Windows.Forms.GroupBox();
            groupTitle.SuspendLayout();
            this.gbInterface.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFPS)).BeginInit();
            this.gbMawenzy.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.BackgroundImage = global::Mawenzy.Plugins.Properties.Resources.mw_blur;
            groupTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            groupTitle.Controls.Add(this.btnGC);
            groupTitle.Controls.Add(this.gbInterface);
            groupTitle.Controls.Add(this.gbMawenzy);
            groupTitle.Controls.Add(this.linkLab);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Uberdash General Settings";
            // 
            // gbInterface
            // 
            this.gbInterface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInterface.BackColor = System.Drawing.Color.Transparent;
            this.gbInterface.Controls.Add(this.tableLayoutPanel1);
            this.gbInterface.Location = new System.Drawing.Point(6, 51);
            this.gbInterface.Name = "gbInterface";
            this.gbInterface.Size = new System.Drawing.Size(474, 67);
            this.gbInterface.TabIndex = 5;
            this.gbInterface.TabStop = false;
            this.gbInterface.Text = "Interface";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labErrors, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbErrMode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numFPS, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 48);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Help;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max FPS:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label1, "The global maximum frame rate per second.  \r\nSet this lower to conserve your CPU " +
                    "if your \r\ncomputer seems slow with Uberdash.");
            // 
            // labErrors
            // 
            this.labErrors.AutoSize = true;
            this.labErrors.Cursor = System.Windows.Forms.Cursors.Help;
            this.labErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labErrors.Location = new System.Drawing.Point(3, 0);
            this.labErrors.Name = "labErrors";
            this.labErrors.Size = new System.Drawing.Size(106, 24);
            this.labErrors.TabIndex = 0;
            this.labErrors.Text = "Preferred error mode:";
            this.labErrors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.labErrors, "The global default error reporting mode.\r\nIt would be nice to use the dialog to r" +
                    "eport \r\nand check on issues known to developers.\r\nOther options are available if" +
                    " dialogs get annoying.");
            // 
            // cbErrMode
            // 
            this.cbErrMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbErrMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbErrMode.FormattingEnabled = true;
            this.cbErrMode.Items.AddRange(new object[] {
            "Balloon tip in tray.",
            "Dialog with bug reporting.",
            "System beep with log."});
            this.cbErrMode.Location = new System.Drawing.Point(115, 3);
            this.cbErrMode.Name = "cbErrMode";
            this.cbErrMode.Size = new System.Drawing.Size(350, 21);
            this.cbErrMode.TabIndex = 1;
            this.cbErrMode.SelectedIndexChanged += new System.EventHandler(this.cbErrMode_SelectedIndexChanged);
            // 
            // numFPS
            // 
            this.numFPS.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Mawenzy.Plugins.PluginSettings.Default, "FPS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numFPS.ForeColor = System.Drawing.Color.ForestGreen;
            this.numFPS.Location = new System.Drawing.Point(115, 27);
            this.numFPS.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFPS.Name = "numFPS";
            this.numFPS.Size = new System.Drawing.Size(101, 20);
            this.numFPS.TabIndex = 2;
            this.numFPS.Value = global::Mawenzy.Plugins.PluginSettings.Default.FPS;
            // 
            // gbMawenzy
            // 
            this.gbMawenzy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMawenzy.BackColor = System.Drawing.Color.Transparent;
            this.gbMawenzy.Controls.Add(this.tableLayoutPanel2);
            this.gbMawenzy.Location = new System.Drawing.Point(6, 124);
            this.gbMawenzy.Name = "gbMawenzy";
            this.gbMawenzy.Size = new System.Drawing.Size(474, 57);
            this.gbMawenzy.TabIndex = 4;
            this.gbMawenzy.TabStop = false;
            this.gbMawenzy.Text = "News";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cbAlerts, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbShowNews, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(468, 38);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cbAlerts
            // 
            this.cbAlerts.AutoSize = true;
            this.cbAlerts.Checked = global::Mawenzy.Plugins.PluginSettings.Default.ShowNewPlugins;
            this.cbAlerts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAlerts.Cursor = System.Windows.Forms.Cursors.Help;
            this.cbAlerts.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Mawenzy.Plugins.PluginSettings.Default, "ShowNewPlugins", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAlerts.Location = new System.Drawing.Point(237, 3);
            this.cbAlerts.Name = "cbAlerts";
            this.cbAlerts.Size = new System.Drawing.Size(228, 32);
            this.cbAlerts.TabIndex = 4;
            this.cbAlerts.Text = "Show important announcements from Mawenzy.";
            this.toolTip.SetToolTip(this.cbAlerts, "Check the Uberdash community for \r\nupdates or important information.\r\n");
            this.cbAlerts.UseVisualStyleBackColor = true;
            // 
            // cbShowNews
            // 
            this.cbShowNews.AutoSize = true;
            this.cbShowNews.Checked = global::Mawenzy.Plugins.PluginSettings.Default.ShowNewPlugins;
            this.cbShowNews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowNews.Cursor = System.Windows.Forms.Cursors.Help;
            this.cbShowNews.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Mawenzy.Plugins.PluginSettings.Default, "ShowNewPlugins", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbShowNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShowNews.Location = new System.Drawing.Point(3, 3);
            this.cbShowNews.Name = "cbShowNews";
            this.cbShowNews.Size = new System.Drawing.Size(228, 32);
            this.cbShowNews.TabIndex = 3;
            this.cbShowNews.Text = "Show new plugins on launch.";
            this.toolTip.SetToolTip(this.cbShowNews, "Search for newly released plugins \r\nthat may interest you on launch.");
            this.cbShowNews.UseVisualStyleBackColor = true;
            // 
            // linkLab
            // 
            this.linkLab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLab.AutoEllipsis = true;
            this.linkLab.BackColor = System.Drawing.Color.Transparent;
            this.linkLab.Location = new System.Drawing.Point(6, 16);
            this.linkLab.Name = "linkLab";
            this.linkLab.Size = new System.Drawing.Size(474, 32);
            this.linkLab.TabIndex = 2;
            this.linkLab.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLab_LinkClicked);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnGC
            // 
            this.btnGC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGC.Location = new System.Drawing.Point(177, 187);
            this.btnGC.Name = "btnGC";
            this.btnGC.Size = new System.Drawing.Size(132, 23);
            this.btnGC.TabIndex = 6;
            this.btnGC.Text = "Garbage Collect";
            this.btnGC.UseVisualStyleBackColor = true;
            this.btnGC.Click += new System.EventHandler(this.btnGC_Click);
            // 
            // MawenzyConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "MawenzyConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            this.gbInterface.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFPS)).EndInit();
            this.gbMawenzy.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.LinkLabel linkLab;
        private System.Windows.Forms.GroupBox gbMawenzy;
        private System.Windows.Forms.GroupBox gbInterface;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labErrors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox cbAlerts;
        private System.Windows.Forms.CheckBox cbShowNews;
        private System.Windows.Forms.ComboBox cbErrMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown numFPS;
        private System.Windows.Forms.Button btnGC;
    }
}
