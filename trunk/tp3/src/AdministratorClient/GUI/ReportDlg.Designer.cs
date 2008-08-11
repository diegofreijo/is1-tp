namespace CasinoOnline.AdminClient.GUI
{
    partial class ReportDlg
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
            this.m_OKButton = new System.Windows.Forms.Button();
            this.ReporteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // m_OKButton
            // 
            this.m_OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_OKButton.Location = new System.Drawing.Point(257, 424);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(75, 23);
            this.m_OKButton.TabIndex = 0;
            this.m_OKButton.Text = "&OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            this.m_OKButton.Click += new System.EventHandler(this.m_OKButton_Click);
            // 
            // ReporteRichTextBox
            // 
            this.ReporteRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ReporteRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.ReporteRichTextBox.Name = "ReporteRichTextBox";
            this.ReporteRichTextBox.ReadOnly = true;
            this.ReporteRichTextBox.Size = new System.Drawing.Size(565, 406);
            this.ReporteRichTextBox.TabIndex = 1;
            this.ReporteRichTextBox.Text = "";
            // 
            // ReportDlg
            // 
            this.AcceptButton = this.m_OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_OKButton;
            this.ClientSize = new System.Drawing.Size(589, 459);
            this.Controls.Add(this.ReporteRichTextBox);
            this.Controls.Add(this.m_OKButton);
            this.Name = "ReportDlg";
            this.Text = "CasinoOnline :: Reporte";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_OKButton;
        private System.Windows.Forms.RichTextBox ReporteRichTextBox;
    }
}