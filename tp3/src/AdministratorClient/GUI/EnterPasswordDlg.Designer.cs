namespace CasinoOnline.AdminClient.GUI
{
    partial class EnterPasswordDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterPasswordDlg));
            this.m_OKButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_OKButton
            // 
            this.m_OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_OKButton.Location = new System.Drawing.Point(102, 51);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(75, 23);
            this.m_OKButton.TabIndex = 0;
            this.m_OKButton.Text = "&OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            this.m_OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_CancelButton.Location = new System.Drawing.Point(183, 51);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_CancelButton.TabIndex = 1;
            this.m_CancelButton.Text = "&Cancel";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Por favor, ingrese la clave de administrador:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 25);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '●';
            this.PasswordTextBox.Size = new System.Drawing.Size(337, 20);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // EnterPasswordDlg
            // 
            this.AcceptButton = this.m_OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_CancelButton;
            this.ClientSize = new System.Drawing.Size(361, 81);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_CancelButton);
            this.Controls.Add(this.m_OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EnterPasswordDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CasinoOnline :: Verificación de identidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_OKButton;
        private System.Windows.Forms.Button m_CancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordTextBox;
    }
}