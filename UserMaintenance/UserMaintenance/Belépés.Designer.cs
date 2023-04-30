namespace UserMaintenance
{
	partial class Belépés
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Belépés));
			label1 = new Label();
			label2 = new Label();
			textBox1 = new TextBox();
			button1 = new Button();
			pictureBox1 = new PictureBox();
			checkBox1 = new CheckBox();
			label3 = new Label();
			label4 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = SystemColors.MenuBar;
			label1.BorderStyle = BorderStyle.Fixed3D;
			label1.FlatStyle = FlatStyle.Flat;
			label1.Font = new Font("Lucida Handwriting", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(55, 92);
			label1.Name = "label1";
			label1.Size = new Size(290, 39);
			label1.TabIndex = 0;
			label1.Text = "Xpress Company";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(92, 177);
			label2.Name = "label2";
			label2.Size = new Size(67, 28);
			label2.TabIndex = 1;
			label2.Text = "Jelszó:";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(177, 182);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(136, 23);
			textBox1.TabIndex = 2;
			textBox1.UseSystemPasswordChar = true;
			textBox1.KeyPress += textBox1_KeyPress;
			// 
			// button1
			// 
			button1.BackgroundImageLayout = ImageLayout.None;
			button1.FlatStyle = FlatStyle.Popup;
			button1.Location = new Point(142, 277);
			button1.Name = "button1";
			button1.Size = new Size(117, 32);
			button1.TabIndex = 3;
			button1.Text = "Belépés";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.Anchor = AnchorStyles.Top;
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(124, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(161, 77);
			pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 4;
			pictureBox1.TabStop = false;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = CheckState.Checked;
			checkBox1.Location = new Point(177, 211);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(114, 19);
			checkBox1.TabIndex = 5;
			checkBox1.Text = "Konzol mutatása";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			label3.Location = new Point(92, 257);
			label3.Name = "label3";
			label3.Size = new Size(215, 17);
			label3.TabIndex = 6;
			label3.Text = "BCE VPN szükséges a használathoz";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(92, 205);
			label4.Name = "label4";
			label4.Size = new Size(49, 15);
			label4.TabIndex = 7;
			label4.Text = "Jelszó: 0";
			// 
			// Belépés
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(388, 321);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(checkBox1);
			Controls.Add(pictureBox1);
			Controls.Add(button1);
			Controls.Add(textBox1);
			Controls.Add(label2);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Name = "Belépés";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private TextBox textBox1;
		private Button button1;
		private PictureBox pictureBox1;
		public CheckBox checkBox1;
		private Label label3;
		private Label label4;
	}
}