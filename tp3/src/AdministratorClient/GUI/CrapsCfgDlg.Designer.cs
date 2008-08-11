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
            this.m_EstablecerResultadoCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_NoFelizRadioButton = new System.Windows.Forms.RadioButton();
            this.m_NoTodosPonenRadioButton = new System.Windows.Forms.RadioButton();
            this.m_TodosPonenRadioButton = new System.Windows.Forms.RadioButton();
            this.m_NormalRadioButton = new System.Windows.Forms.RadioButton();
            this.m_EstablecerTipoJugadaCheckBox = new System.Windows.Forms.CheckBox();
            this.m_OKButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.m_ApplyButton = new System.Windows.Forms.Button();
            this.m_AzarResultRadioButton = new System.Windows.Forms.RadioButton();
            this.m_ControlResultRadioButton = new System.Windows.Forms.RadioButton();
            this.m_AzarRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_ControlResultRadioButton);
            this.groupBox1.Controls.Add(this.m_AzarResultRadioButton);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.m_EstablecerResultadoCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 142);
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
            this.groupBox2.Location = new System.Drawing.Point(28, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 70);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // Dado2ComboBox
            // 
            this.Dado2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dado2ComboBox.FormattingEnabled = true;
            this.Dado2ComboBox.Location = new System.Drawing.Point(155, 35);
            this.Dado2ComboBox.Name = "Dado2ComboBox";
            this.Dado2ComboBox.Size = new System.Drawing.Size(121, 21);
            this.Dado2ComboBox.TabIndex = 4;
            // 
            // Dado1ComboBox
            // 
            this.Dado1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dado1ComboBox.FormattingEnabled = true;
            this.Dado1ComboBox.Location = new System.Drawing.Point(12, 35);
            this.Dado1ComboBox.Name = "Dado1ComboBox";
            this.Dado1ComboBox.Size = new System.Drawing.Size(121, 21);
            this.Dado1ComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dado 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dado 1";
            // 
            // m_EstablecerResultadoCheckBox
            // 
            this.m_EstablecerResultadoCheckBox.AutoSize = true;
            this.m_EstablecerResultadoCheckBox.Location = new System.Drawing.Point(6, 19);
            this.m_EstablecerResultadoCheckBox.Name = "m_EstablecerResultadoCheckBox";
            this.m_EstablecerResultadoCheckBox.Size = new System.Drawing.Size(76, 17);
            this.m_EstablecerResultadoCheckBox.TabIndex = 0;
            this.m_EstablecerResultadoCheckBox.Text = "Establecer";
            this.m_EstablecerResultadoCheckBox.UseVisualStyleBackColor = true;
            this.m_EstablecerResultadoCheckBox.CheckedChanged += new System.EventHandler(this.m_ControlarResultadoCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.m_AzarRadioButton);
            this.groupBox3.Controls.Add(this.m_NoFelizRadioButton);
            this.groupBox3.Controls.Add(this.m_NoTodosPonenRadioButton);
            this.groupBox3.Controls.Add(this.m_TodosPonenRadioButton);
            this.groupBox3.Controls.Add(this.m_NormalRadioButton);
            this.groupBox3.Controls.Add(this.m_EstablecerTipoJugadaCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 86);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de jugada";
            // 
            // m_NoFelizRadioButton
            // 
            this.m_NoFelizRadioButton.AutoSize = true;
            this.m_NoFelizRadioButton.Location = new System.Drawing.Point(354, 51);
            this.m_NoFelizRadioButton.Name = "m_NoFelizRadioButton";
            this.m_NoFelizRadioButton.Size = new System.Drawing.Size(63, 17);
            this.m_NoFelizRadioButton.TabIndex = 4;
            this.m_NoFelizRadioButton.Text = "No Feliz";
            this.m_NoFelizRadioButton.UseVisualStyleBackColor = true;
            // 
            // m_NoTodosPonenRadioButton
            // 
            this.m_NoTodosPonenRadioButton.AutoSize = true;
            this.m_NoTodosPonenRadioButton.Location = new System.Drawing.Point(239, 51);
            this.m_NoTodosPonenRadioButton.Name = "m_NoTodosPonenRadioButton";
            this.m_NoTodosPonenRadioButton.Size = new System.Drawing.Size(106, 17);
            this.m_NoTodosPonenRadioButton.TabIndex = 3;
            this.m_NoTodosPonenRadioButton.Text = "No Todos Ponen";
            this.m_NoTodosPonenRadioButton.UseVisualStyleBackColor = true;
            // 
            // m_TodosPonenRadioButton
            // 
            this.m_TodosPonenRadioButton.AutoSize = true;
            this.m_TodosPonenRadioButton.Location = new System.Drawing.Point(141, 51);
            this.m_TodosPonenRadioButton.Name = "m_TodosPonenRadioButton";
            this.m_TodosPonenRadioButton.Size = new System.Drawing.Size(89, 17);
            this.m_TodosPonenRadioButton.TabIndex = 2;
            this.m_TodosPonenRadioButton.Text = "Todos Ponen";
            this.m_TodosPonenRadioButton.UseVisualStyleBackColor = true;
            // 
            // m_NormalRadioButton
            // 
            this.m_NormalRadioButton.AutoSize = true;
            this.m_NormalRadioButton.Location = new System.Drawing.Point(74, 51);
            this.m_NormalRadioButton.Name = "m_NormalRadioButton";
            this.m_NormalRadioButton.Size = new System.Drawing.Size(58, 17);
            this.m_NormalRadioButton.TabIndex = 1;
            this.m_NormalRadioButton.Text = "Normal";
            this.m_NormalRadioButton.UseVisualStyleBackColor = true;
            // 
            // m_EstablecerTipoJugadaCheckBox
            // 
            this.m_EstablecerTipoJugadaCheckBox.AutoSize = true;
            this.m_EstablecerTipoJugadaCheckBox.Location = new System.Drawing.Point(6, 19);
            this.m_EstablecerTipoJugadaCheckBox.Name = "m_EstablecerTipoJugadaCheckBox";
            this.m_EstablecerTipoJugadaCheckBox.Size = new System.Drawing.Size(76, 17);
            this.m_EstablecerTipoJugadaCheckBox.TabIndex = 0;
            this.m_EstablecerTipoJugadaCheckBox.Text = "Establecer";
            this.m_EstablecerTipoJugadaCheckBox.UseVisualStyleBackColor = true;
            this.m_EstablecerTipoJugadaCheckBox.CheckedChanged += new System.EventHandler(this.m_ControlarTipoJugadaCheckBox_CheckedChanged);
            // 
            // m_OKButton
            // 
            this.m_OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_OKButton.Location = new System.Drawing.Point(108, 263);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(75, 23);
            this.m_OKButton.TabIndex = 2;
            this.m_OKButton.Text = "&OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            this.m_OKButton.Click += new System.EventHandler(this.m_OKButton_Click);
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_CancelButton.Location = new System.Drawing.Point(189, 263);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_CancelButton.TabIndex = 3;
            this.m_CancelButton.Text = "&Cancel";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            this.m_CancelButton.Click += new System.EventHandler(this.m_CancelButton_Click);
            // 
            // m_ApplyButton
            // 
            this.m_ApplyButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.m_ApplyButton.Location = new System.Drawing.Point(285, 263);
            this.m_ApplyButton.Name = "m_ApplyButton";
            this.m_ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.m_ApplyButton.TabIndex = 4;
            this.m_ApplyButton.Text = "&Apply";
            this.m_ApplyButton.UseVisualStyleBackColor = true;
            this.m_ApplyButton.Click += new System.EventHandler(this.m_ApplyButton_Click);
            // 
            // m_AzarResultRadioButton
            // 
            this.m_AzarResultRadioButton.AutoSize = true;
            this.m_AzarResultRadioButton.Location = new System.Drawing.Point(199, 19);
            this.m_AzarResultRadioButton.Name = "m_AzarResultRadioButton";
            this.m_AzarResultRadioButton.Size = new System.Drawing.Size(46, 17);
            this.m_AzarResultRadioButton.TabIndex = 6;
            this.m_AzarResultRadioButton.Text = "Azar";
            this.m_AzarResultRadioButton.UseVisualStyleBackColor = true;
            this.m_AzarResultRadioButton.CheckedChanged += new System.EventHandler(this.m_AzarResultRadioButton_CheckedChanged);
            // 
            // m_ControlResultRadioButton
            // 
            this.m_ControlResultRadioButton.AutoSize = true;
            this.m_ControlResultRadioButton.Checked = true;
            this.m_ControlResultRadioButton.Location = new System.Drawing.Point(253, 19);
            this.m_ControlResultRadioButton.Name = "m_ControlResultRadioButton";
            this.m_ControlResultRadioButton.Size = new System.Drawing.Size(67, 17);
            this.m_ControlResultRadioButton.TabIndex = 7;
            this.m_ControlResultRadioButton.TabStop = true;
            this.m_ControlResultRadioButton.Text = "Controlar";
            this.m_ControlResultRadioButton.UseVisualStyleBackColor = true;
            this.m_ControlResultRadioButton.CheckedChanged += new System.EventHandler(this.m_ControlResultRadioButton_CheckedChanged);
            // 
            // m_AzarRadioButton
            // 
            this.m_AzarRadioButton.AutoSize = true;
            this.m_AzarRadioButton.Checked = true;
            this.m_AzarRadioButton.Location = new System.Drawing.Point(19, 51);
            this.m_AzarRadioButton.Name = "m_AzarRadioButton";
            this.m_AzarRadioButton.Size = new System.Drawing.Size(46, 17);
            this.m_AzarRadioButton.TabIndex = 5;
            this.m_AzarRadioButton.TabStop = true;
            this.m_AzarRadioButton.Text = "Azar";
            this.m_AzarRadioButton.UseVisualStyleBackColor = true;
            // 
            // CrapsCfgDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 298);
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
        private System.Windows.Forms.CheckBox m_EstablecerResultadoCheckBox;
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
        private System.Windows.Forms.CheckBox m_EstablecerTipoJugadaCheckBox;
        private System.Windows.Forms.Button m_OKButton;
        private System.Windows.Forms.Button m_CancelButton;
        private System.Windows.Forms.Button m_ApplyButton;
        private System.Windows.Forms.RadioButton m_ControlResultRadioButton;
        private System.Windows.Forms.RadioButton m_AzarResultRadioButton;
        private System.Windows.Forms.RadioButton m_AzarRadioButton;
    }
}