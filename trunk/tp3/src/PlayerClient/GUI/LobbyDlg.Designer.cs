namespace CasinoOnline.PlayerClient.GUI
{
    partial class LobbyDlg
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
            this.m_logoutButton = new System.Windows.Forms.Button();
            this.PlayCrapsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_logoutButton
            // 
            this.m_logoutButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_logoutButton.Location = new System.Drawing.Point(128, 91);
            this.m_logoutButton.Name = "m_logoutButton";
            this.m_logoutButton.Size = new System.Drawing.Size(75, 23);
            this.m_logoutButton.TabIndex = 0;
            this.m_logoutButton.Text = "&Logout";
            this.m_logoutButton.UseVisualStyleBackColor = true;
            this.m_logoutButton.Click += new System.EventHandler(this.m_logoutButton_Click);
            // 
            // PlayCrapsButton
            // 
            this.PlayCrapsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayCrapsButton.Font = new System.Drawing.Font("Snap ITC", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayCrapsButton.Location = new System.Drawing.Point(12, 12);
            this.PlayCrapsButton.Name = "PlayCrapsButton";
            this.PlayCrapsButton.Size = new System.Drawing.Size(307, 66);
            this.PlayCrapsButton.TabIndex = 1;
            this.PlayCrapsButton.Tag = "";
            this.PlayCrapsButton.Text = "Play Craps!";
            this.PlayCrapsButton.UseVisualStyleBackColor = true;
            this.PlayCrapsButton.Click += new System.EventHandler(this.PlayCrapsButton_Click);
            // 
            // LobbyDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 126);
            this.ControlBox = false;
            this.Controls.Add(this.PlayCrapsButton);
            this.Controls.Add(this.m_logoutButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(339, 160);
            this.Name = "LobbyDlg";
            this.Text = "CasinoOnline :: Lobby";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_logoutButton;
        private System.Windows.Forms.Button PlayCrapsButton;
    }
}