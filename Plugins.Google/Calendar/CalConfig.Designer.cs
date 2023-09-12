using Mawenzy.Plugins.Google_Plugs.Properties;
namespace Mawenzy.Plugins.Google_Plugs.Calendar
{
    partial class CalConfig
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labGID = new System.Windows.Forms.Label();
            this.labGPW = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbPW = new Mawenzy.UI.EncryptedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPresentation = new System.Windows.Forms.ComboBox();
            this.labMarqueeSpeed = new System.Windows.Forms.Label();
            this.tbMarqueeSpeed = new System.Windows.Forms.TrackBar();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            groupTitle = new System.Windows.Forms.GroupBox();
            groupTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMarqueeSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTitle
            // 
            groupTitle.Controls.Add(this.tableLayoutPanel1);
            groupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTitle.Location = new System.Drawing.Point(0, 0);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(486, 296);
            groupTitle.TabIndex = 2;
            groupTitle.TabStop = false;
            groupTitle.Text = "Google Calendar";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.labGID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labGPW, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbPW, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbPresentation, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labMarqueeSpeed, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbMarqueeSpeed, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 131);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labGID
            // 
            this.labGID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labGID.AutoSize = true;
            this.labGID.Location = new System.Drawing.Point(3, 6);
            this.labGID.Name = "labGID";
            this.labGID.Size = new System.Drawing.Size(58, 13);
            this.labGID.TabIndex = 0;
            this.labGID.Text = "Google ID:";
            // 
            // labGPW
            // 
            this.labGPW.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labGPW.AutoSize = true;
            this.labGPW.Location = new System.Drawing.Point(3, 32);
            this.labGPW.Name = "labGPW";
            this.labGPW.Size = new System.Drawing.Size(93, 13);
            this.labGPW.TabIndex = 0;
            this.labGPW.Text = "Google Password:";

            this.tbID.DataBindings.Add(new System.Windows.Forms.Binding("Text", GoogleSettings.Default, "GoogleID", true));
            this.tbID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbID.Location = new System.Drawing.Point(121, 3);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(350, 20);
            this.tbID.TabIndex = 1;
            this.tbID.Text = GoogleSettings.Default.GoogleID;
            // 
            // tbPW
            // 
            this.tbPW.DataBindings.Add(new System.Windows.Forms.Binding("Text", GoogleSettings.Default, "GooglePW", true));
            this.tbPW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPW.Location = new System.Drawing.Point(121, 29);
            this.tbPW.Name = "tbPW";
            this.tbPW.PasswordChar = '*';
            this.tbPW.Size = new System.Drawing.Size(350, 20);
            this.tbPW.TabIndex = 2;
            this.tbPW.Text = GoogleSettings.Default.GooglePW;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Presentation:";
            // 
            // cbPresentation
            // 
            this.cbPresentation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbPresentation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPresentation.DataBindings.Add(new System.Windows.Forms.Binding("Text", GoogleSettings.Default, "CalendarStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbPresentation.Items.AddRange(new object[] {
            "Flat Opaque",
            "Flat Translucent",
            "Chronic Helix"});
            this.cbPresentation.Location = new System.Drawing.Point(121, 55);
            this.cbPresentation.Name = "cbPresentation";
            this.cbPresentation.Size = new System.Drawing.Size(184, 21);
            this.cbPresentation.TabIndex = 3;
            this.cbPresentation.Text = GoogleSettings.Default.CalendarStyle;
            // 
            // labMarqueeSpeed
            // 
            this.labMarqueeSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labMarqueeSpeed.AutoSize = true;
            this.labMarqueeSpeed.Location = new System.Drawing.Point(3, 98);
            this.labMarqueeSpeed.Name = "labMarqueeSpeed";
            this.labMarqueeSpeed.Size = new System.Drawing.Size(84, 13);
            this.labMarqueeSpeed.TabIndex = 0;
            this.labMarqueeSpeed.Text = "Refresh interval:";
            // 
            // tbMarqueeSpeed
            // 
            this.tbMarqueeSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Value", GoogleSettings.Default, "SwapInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbMarqueeSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMarqueeSpeed.Location = new System.Drawing.Point(121, 82);
            this.tbMarqueeSpeed.Maximum = 1000000;
            this.tbMarqueeSpeed.Minimum = 5000;
            this.tbMarqueeSpeed.Name = "tbMarqueeSpeed";
            this.tbMarqueeSpeed.Size = new System.Drawing.Size(350, 46);
            this.tbMarqueeSpeed.TabIndex = 4;
            this.tbMarqueeSpeed.TickFrequency = 100000;
            this.tbMarqueeSpeed.Value = GoogleSettings.Default.SwapInterval;
            this.tbMarqueeSpeed.Scroll += new System.EventHandler(this.tbMarqueeSpeed_Scroll);
            // 
            // CalConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupTitle);
            this.Name = "CalConfig";
            this.Size = new System.Drawing.Size(486, 296);
            groupTitle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMarqueeSpeed)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labGID;
        private System.Windows.Forms.Label labGPW;
        private System.Windows.Forms.TextBox tbID;
        private Mawenzy.UI.EncryptedTextBox tbPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPresentation;
        private System.Windows.Forms.Label labMarqueeSpeed;
        private System.Windows.Forms.TrackBar tbMarqueeSpeed;
    }
}
