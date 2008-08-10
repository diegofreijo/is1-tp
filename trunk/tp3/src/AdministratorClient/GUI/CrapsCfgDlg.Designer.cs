namespace CasinoOnline.AdminClient.GUI
{
    partial class CrapsCfgDlg
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dado2ComboBox = new System.Windows.Forms.ComboBox();
            this.Dado1ComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_ControlarResultadoCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_NoFelizRadioButton = new System.Windows.Forms.RadioButton();
            this.m_NoTodosPonenRadioButton = new System.Windows.Forms.RadioButton();
            this.m_TodosPonenRadioButton = new System.Windows.Forms.RadioButton();
            this.m_NormalRadioButton = new System.Windows.Forms.RadioButton();
            this.m_ControlarTipoJugadaCheckBox = new System.Windows.Forms.CheckBox();
            this.m_OKButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.m_ApplyButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.m_ControlarResultadoCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado dados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Dado2ComboBox);
            this.groupBox2.Controls.Add(this.Dado1ComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(40, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 84);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // Dado2ComboBox
            // 
            this.Dado2ComboBox.FormattingEnabled = true;
            this.Dado2ComboBox.Location = new System.Drawing.Point(156, 41);
            this.Dado2ComboBox.Name = "Dado2ComboBox";
            this.Dado2ComboBox.Size = new System.Drawing.Size(121, 21);
            this.Dado2ComboBox.TabIndex = 4;
            // 
            // Dado1ComboBox
            // 
            this.Dado1ComboBox.FormattingEnabled = true;
            this.Dado1ComboBox.Location = new System.Drawing.Point(13, 41);
            this.Dado1ComboBox.Name = "Dado1ComboBox";
            this.Dado1ComboBox.Size = new System.Drawing.Size(121, 21);
            this.Dado1ComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dado 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dado 1";
            // 
            // m_ControlarResultadoCheckBox
            // 
            this.m_ControlarResultadoCheckBox.AutoSize = true;
            this.m_ControlarResultadoCheckBox.Location = new System.Drawing.Point(6, 19);
            this.m_ControlarResultadoCheckBox.Name = "m_ControlarResultadoCheckBox";
            this.m_ControlarResultadoCheckBox.Size = new System.Drawing.Size(68, 17);
            this.m_ControlarResultadoCheckBox.TabIndex = 0;
            this.m_ControlarResultadoCheckBox.Text = "Controlar";
            this.m_ControlarResultadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_NoFelizRadioButton);
            this.groupBox3.Controls.Add(this.m_NoTodosPonenRadioButton);
            this.groupBox3.Controls.Add(this.m_TodosPonenRadioButton);
            this.groupBox3.Controls.Add(this.m_NormalRadioButton);
            this.groupBox3.Controls.Add(this.m_ControlarTipoJugadaCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 86);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de jugada";
            // 
            // m_NoFelizRadioButton
            // 
            this.m_NoFelizRadioButton.AutoSize = true;
            this.m_NoFelizRadioButton.Location = new System.Drawing.Point(293, 51);
            this.m_NoFelizRadioButton.Name = "m_NoFelizRadioButton";
            this.m_NoFelizRadioButton.Size = new System.Drawing.Size(63, 17);
            this.m_NoFelizRadioButton.TabIndex = 4;
            this.m_NoFelizRadioButton.TabStop = true;
            this.m_NoFelizRadioButton.Text = "No Feliz";
            this.m_NoFelizRadioButton.UseVisualStyleBackColor = true;
            // 
            // m_NoTodosPonenRadioButton
            // 
            this.m_NoTodosPonenRadioButton.AutoSize = true;
            this.m_NoTodosPonenRadioButton.Location = new System.Drawing.Point(179, 51);
            this.m_NoTodosPonenRadioButton.Name = "m_NoTodosPonenRadioButton";
            this.m_NoTodosPonenRadioButton.Size = new System.Drawing.Size(106, 17);
            this.m_NoTodosPonenRadioButton.TabIndex = 3;
            this.m_NoTodosPonenRadioButton.TabStop = true;
            this.m_NoTodosPonenRadioButton.Text = "No Todos Ponen";
            this.m_NoTodosPonenRadioButton.UseVisualStyleBackColor = true;
            // 
            // m_TodosPonenRadioButton
            // 
            this.m_TodosPonenRadioButton.AutoSize = true;
            this.m_TodosPonenRadioButton.Location = new System.Drawing.Point(82, 51);
            this.m_TodosPonenRadioButton.Name = "m_TodosPonenRadioButton";
            this.m_TodosPonenRadioButton.Size = new System.Drawing.Size(89, 17);
            this.m_TodosPonenRadioButton.TabIndex = 2;
            this.m_TodosPonenRadioButton.TabStop = true;
            this.m_TodosPonenRadioButton.Text = "Todos Ponen";
            this.m_TodosPonenRadioButton.UseVisualStyleBackColor = true;
            // 
            // m_NormalRadioButton
            // 
            this.m_NormalRadioButton.AutoSize = true;
            this.m_NormalRadioButton.Checked = true;
            this.m_NormalRadioButton.Location = new System.Drawing.Point(16, 51);
            this.m_NormalRadioButton.Name = "m_NormalRadioButton";
            this.m_NormalRadioButton.Size = new System.Drawing.Size(58, 17);
            this.m_NormalRadioButton.TabIndex = 1;
            this.m_NormalRadioButton.TabStop = true;
            this.m_NormalRadioButton.Text = "Normal";
            this.m_NormalRadioButton.UseVisualStyleBackColor = true;
            // 
            // m_ControlarTipoJugadaCheckBox
            // 
            this.m_ControlarTipoJugadaCheckBox.AutoSize = true;
            this.m_ControlarTipoJugadaCheckBox.Location = new System.Drawing.Point(6, 19);
            this.m_ControlarTipoJugadaCheckBox.Name = "m_ControlarTipoJugadaCheckBox";
            this.m_ControlarTipoJugadaCheckBox.Size = new System.Drawing.Size(68, 17);
            this.m_ControlarTipoJugadaCheckBox.TabIndex = 0;
            this.m_ControlarTipoJugadaCheckBox.Text = "Controlar";
            this.m_ControlarTipoJugadaCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_OKButton
            // 
            this.m_OKButton.Location = new System.Drawing.Point(120, 263);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(75, 23);
            this.m_OKButton.TabIndex = 2;
            this.m_OKButton.Text = "&OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            this.m_OKButton.Click += new System.EventHandler(this.m_OKButton_Click);
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.Location = new System.Drawing.Point(201, 263);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_CancelButton.TabIndex = 3;
            this.m_CancelButton.Text = "&Cancel";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            // 
            // m_ApplyButton
            // 
            this.m_ApplyButton.Location = new System.Drawing.Point(310, 263);
            this.m_ApplyButton.Name = "m_ApplyButton";
            this.m_ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.m_ApplyButton.TabIndex = 4;
            this.m_ApplyButton.Text = "&Apply";
            this.m_ApplyButton.UseVisualStyleBackColor = true;
            this.m_ApplyButton.Click += new System.EventHandler(this.m_ApplyButton_Click);
            // 
            // CrapsCfgDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 298);
            this.Controls.Add(this.m_ApplyButton);
            this.Controls.Add(this.m_CancelButton);
            this.Controls.Add(this.m_OKButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CrapsCfgDlg";
            this.Text = "CasinoOnline :: Modo Dirigido :: Craps";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox m_ControlarResultadoCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox Dado2ComboBox;
        private System.Windows.Forms.ComboBox Dado1ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton m_NoFelizRadioButton;
        private System.Windows.Forms.RadioButton m_NoTodosPonenRadioButton;
        private System.Windows.Forms.RadioButton m_TodosPonenRadioButton;
        private System.Windows.Forms.RadioButton m_NormalRadioButton;
        private System.Windows.Forms.CheckBox m_ControlarTipoJugadaCheckBox;
        private System.Windows.Forms.Button m_OKButton;
        private System.Windows.Forms.Button m_CancelButton;
        private System.Windows.Forms.Button m_ApplyButton;
    }
}