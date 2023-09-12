namespace Mawenzy.Plugins.Google_Plugs.Calendar
{
    partial class EventForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCalendar = new System.Windows.Forms.ComboBox();
            this.labCalendar = new System.Windows.Forms.Label();
            this.tlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labText = new System.Windows.Forms.Label();
            this.tbQuickText = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCalendar
            // 
            this.cbCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCalendar.FormattingEnabled = true;
            this.cbCalendar.Location = new System.Drawing.Point(94, 4);
            this.cbCalendar.Name = "cbCalendar";
            this.cbCalendar.Size = new System.Drawing.Size(185, 21);
            this.cbCalendar.TabIndex = 1;
            this.cbCalendar.Text = "Personal";
            // 
            // labCalendar
            // 
            this.labCalendar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labCalendar.AutoSize = true;
            this.labCalendar.Location = new System.Drawing.Point(3, 8);
            this.labCalendar.Name = "labCalendar";
            this.labCalendar.Size = new System.Drawing.Size(52, 13);
            this.labCalendar.TabIndex = 1;
            this.labCalendar.Text = "Calendar:";
            // 
            // tlPanel
            // 
            this.tlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlPanel.ColumnCount = 2;
            this.tlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.60073F));
            this.tlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.39927F));
            this.tlPanel.Controls.Add(this.labText, 0, 1);
            this.tlPanel.Controls.Add(this.labCalendar, 0, 0);
            this.tlPanel.Controls.Add(this.cbCalendar, 1, 0);
            this.tlPanel.Controls.Add(this.tbQuickText, 1, 1);
            this.tlPanel.Location = new System.Drawing.Point(12, 12);
            this.tlPanel.Name = "tlPanel";
            this.tlPanel.RowCount = 2;
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.Size = new System.Drawing.Size(282, 58);
            this.tlPanel.TabIndex = 2;
            // 
            // labText
            // 
            this.labText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labText.AutoSize = true;
            this.labText.Location = new System.Drawing.Point(3, 37);
            this.labText.Name = "labText";
            this.labText.Size = new System.Drawing.Size(79, 13);
            this.labText.TabIndex = 2;
            this.labText.Text = "Quick add text:";
            // 
            // tbQuickText
            // 
            this.tbQuickText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuickText.Location = new System.Drawing.Point(94, 33);
            this.tbQuickText.Name = "tbQuickText";
            this.tbQuickText.Size = new System.Drawing.Size(185, 20);
            this.tbQuickText.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(219, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(138, 76);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // EventForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(306, 111);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EventForm";
            this.Text = "Add Event";
            this.tlPanel.ResumeLayout(false);
            this.tlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCalendar;
        private System.Windows.Forms.Label labCalendar;
        private System.Windows.Forms.TableLayoutPanel tlPanel;
        private System.Windows.Forms.Label labText;
        private System.Windows.Forms.TextBox tbQuickText;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}