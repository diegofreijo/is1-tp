namespace CasinoOnline.AdminClient.GUI
{
    partial class HappyMoveCfgDlg
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
            this.m_ApplyButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.m_OKButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MesaCrapsComboBox = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ApplyButton
            // 
            this.m_ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ApplyButton.Location = new System.Drawing.Point(294, 75);
            this.m_ApplyButton.Name = "m_ApplyButton";
            this.m_ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.m_ApplyButton.TabIndex = 7;
            this.m_ApplyButton.Text = "&Apply";
            this.m_ApplyButton.UseVisualStyleBackColor = true;
            this.m_ApplyButton.Click += new System.EventHandler(this.m_ApplyButton_Click);
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_CancelButton.Location = new System.Drawing.Point(193, 75);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_CancelButton.TabIndex = 6;
            this.m_CancelButton.Text = "&Cancel";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            this.m_CancelButton.Click += new System.EventHandler(this.m_CancelButton_Click);
            // 
            // m_OKButton
            // 
            this.m_OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_OKButton.Location = new System.Drawing.Point(112, 75);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(75, 23);
            this.m_OKButton.TabIndex = 5;
            this.m_OKButton.Text = "&OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            this.m_OKButton.Click += new System.EventHandler(this.m_OKButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.MesaCrapsComboBox);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 49);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mesa de ocurrencia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id:";
            // 
            // MesaCrapsComboBox
            // 
            this.MesaCrapsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MesaCrapsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MesaCrapsComboBox.FormattingEnabled = true;
            this.MesaCrapsComboBox.Location = new System.Drawing.Point(181, 18);
            this.MesaCrapsComboBox.Name = "MesaCrapsComboBox";
            this.MesaCrapsComboBox.Size = new System.Drawing.Size(170, 21);
            this.MesaCrapsComboBox.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(84, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Mesa Craps:";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // HappyMoveCfgDlg
            // 
            this.AcceptButton = this.m_OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_CancelButton;
            this.ClientSize = new System.Drawing.Size(381, 110);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_ApplyButton);
            this.Controls.Add(this.m_CancelButton);
            this.Controls.Add(this.m_OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HappyMoveCfgDlg";
            this.Text = "CasinoOnline :: Modo Dirigido :: Jugada Feliz";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ApplyButton;
        private System.Windows.Forms.Button m_CancelButton;
        private System.Windows.Forms.Button m_OKButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox MesaCrapsComboBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
    }
}