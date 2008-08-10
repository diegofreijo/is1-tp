namespace CasinoOnline.AdminClient.GUI
{
    partial class PanelAdministrador
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
            this.ControlJugadaFelizButton = new System.Windows.Forms.Button();
            this.ControlCrapsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.QueryDetallesMovimientosButton = new System.Windows.Forms.Button();
            this.QueryRankingDeJugadoresButton = new System.Windows.Forms.Button();
            this.QueryEstadoActualButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_ExitButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ControlJugadaFelizButton);
            this.groupBox1.Controls.Add(this.ControlCrapsButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modo dirigido";
            // 
            // ControlJugadaFelizButton
            // 
            this.ControlJugadaFelizButton.Location = new System.Drawing.Point(185, 58);
            this.ControlJugadaFelizButton.Name = "ControlJugadaFelizButton";
            this.ControlJugadaFelizButton.Size = new System.Drawing.Size(75, 23);
            this.ControlJugadaFelizButton.TabIndex = 3;
            this.ControlJugadaFelizButton.Text = "Show";
            this.ControlJugadaFelizButton.UseVisualStyleBackColor = true;
            this.ControlJugadaFelizButton.Click += new System.EventHandler(this.ControlJugadaFelizButton_Click);
            // 
            // ControlCrapsButton
            // 
            this.ControlCrapsButton.Location = new System.Drawing.Point(185, 26);
            this.ControlCrapsButton.Name = "ControlCrapsButton";
            this.ControlCrapsButton.Size = new System.Drawing.Size(75, 23);
            this.ControlCrapsButton.TabIndex = 2;
            this.ControlCrapsButton.Text = "Show";
            this.ControlCrapsButton.UseVisualStyleBackColor = true;
            this.ControlCrapsButton.Click += new System.EventHandler(this.ControlCrapsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Módulo de control de jugada feliz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Módulo de control de Craps";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.QueryDetallesMovimientosButton);
            this.groupBox2.Controls.Add(this.QueryRankingDeJugadoresButton);
            this.groupBox2.Controls.Add(this.QueryEstadoActualButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 114);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reportes";
            // 
            // QueryDetallesMovimientosButton
            // 
            this.QueryDetallesMovimientosButton.Location = new System.Drawing.Point(185, 78);
            this.QueryDetallesMovimientosButton.Name = "QueryDetallesMovimientosButton";
            this.QueryDetallesMovimientosButton.Size = new System.Drawing.Size(75, 23);
            this.QueryDetallesMovimientosButton.TabIndex = 5;
            this.QueryDetallesMovimientosButton.Text = "Query";
            this.QueryDetallesMovimientosButton.UseVisualStyleBackColor = true;
            this.QueryDetallesMovimientosButton.Click += new System.EventHandler(this.QueryDetallesMovimientosButton_Click);
            // 
            // QueryRankingDeJugadoresButton
            // 
            this.QueryRankingDeJugadoresButton.Location = new System.Drawing.Point(185, 50);
            this.QueryRankingDeJugadoresButton.Name = "QueryRankingDeJugadoresButton";
            this.QueryRankingDeJugadoresButton.Size = new System.Drawing.Size(75, 23);
            this.QueryRankingDeJugadoresButton.TabIndex = 4;
            this.QueryRankingDeJugadoresButton.Text = "Query";
            this.QueryRankingDeJugadoresButton.UseVisualStyleBackColor = true;
            this.QueryRankingDeJugadoresButton.Click += new System.EventHandler(this.QueryRankingDeJugadoresButton_Click);
            // 
            // QueryEstadoActualButton
            // 
            this.QueryEstadoActualButton.Location = new System.Drawing.Point(185, 22);
            this.QueryEstadoActualButton.Name = "QueryEstadoActualButton";
            this.QueryEstadoActualButton.Size = new System.Drawing.Size(75, 23);
            this.QueryEstadoActualButton.TabIndex = 3;
            this.QueryEstadoActualButton.Text = "Query";
            this.QueryEstadoActualButton.UseVisualStyleBackColor = true;
            this.QueryEstadoActualButton.Click += new System.EventHandler(this.QueryEstadoActualButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Detalle movimientos por jugador";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ranking de jugadores";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Estado actual";
            // 
            // m_ExitButton
            // 
            this.m_ExitButton.Location = new System.Drawing.Point(105, 235);
            this.m_ExitButton.Name = "m_ExitButton";
            this.m_ExitButton.Size = new System.Drawing.Size(75, 23);
            this.m_ExitButton.TabIndex = 2;
            this.m_ExitButton.Text = "E&xit";
            this.m_ExitButton.UseVisualStyleBackColor = true;
            this.m_ExitButton.Click += new System.EventHandler(this.m_ExitButton_Click);
            // 
            // PanelAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 262);
            this.Controls.Add(this.m_ExitButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PanelAdministrador";
            this.Text = "Panel de Administrador";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ControlJugadaFelizButton;
        private System.Windows.Forms.Button ControlCrapsButton;
        private System.Windows.Forms.Button QueryDetallesMovimientosButton;
        private System.Windows.Forms.Button QueryRankingDeJugadoresButton;
        private System.Windows.Forms.Button QueryEstadoActualButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_ExitButton;
    }
}

