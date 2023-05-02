using System.Text;
using XSystem.Security.Cryptography;

namespace UserMaintenance
{
	public partial class Belépés : Form
	{
		string valid = "X+zrZv/IbzjZUnhsbWlsecLbwjndTpG0ZynXOif7V+k=";
		public Belépés()
		{
			InitializeComponent();
			button1.BackColor = Color.FromArgb(255, 183, 3);
			this.BackColor = Color.FromArgb(33, 158, 188);
			this.Text = "Hitelesítés";
			label1.BackColor = Color.FromArgb(33, 158, 188);
			label1.BorderStyle = BorderStyle.None;
			;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Ellenoriz();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				Ellenoriz();
			}
		}

		private void Ellenoriz()
		{
			string jelszo = textBox1.Text;
			byte[] jelszoBytes = Encoding.UTF8.GetBytes(jelszo);
			SHA256Managed sha = new SHA256Managed();
			byte[] hash = sha.ComputeHash(jelszoBytes);
			string hashString = Convert.ToBase64String(hash);

			if (hashString == valid)
			{
				Alkalmazás alk = new Alkalmazás(checkBox1.Checked);
				alk.Show();
				Hide();
			}
			else
			{
				MessageBox.Show("Hibás jelszó!");
			}
		}
	}
}