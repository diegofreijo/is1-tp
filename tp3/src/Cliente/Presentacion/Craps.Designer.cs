namespace Cliente.Presentacion
{
	partial class Craps
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
			this.but5 = new System.Windows.Forms.Button();
			this.but10 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.butAGanar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// but5
			// 
			this.but5.Location = new System.Drawing.Point(59, 270);
			this.but5.Name = "but5";
			this.but5.Size = new System.Drawing.Size(42, 23);
			this.but5.TabIndex = 0;
			this.but5.Text = "$5";
			this.but5.UseVisualStyleBackColor = true;
			// 
			// but10
			// 
			this.but10.Location = new System.Drawing.Point(107, 270);
			this.but10.Name = "but10";
			this.but10.Size = new System.Drawing.Size(42, 23);
			this.but10.TabIndex = 1;
			this.but10.Text = "$10";
			this.but10.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(155, 270);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(42, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "$20";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// butAGanar
			// 
			this.butAGanar.Location = new System.Drawing.Point(236, 76);
			this.butAGanar.Name = "butAGanar";
			this.butAGanar.Size = new System.Drawing.Size(75, 23);
			this.butAGanar.TabIndex = 3;
			this.butAGanar.Text = "AGanar";
			this.butAGanar.UseVisualStyleBackColor = true;
			// 
			// Craps
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(786, 376);
			this.Controls.Add(this.butAGanar);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.but10);
			this.Controls.Add(this.but5);
			this.Name = "Craps";
			this.Text = "Craps";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button but5;
		private System.Windows.Forms.Button but10;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button butAGanar;
	}
}