namespace UserMaintenance
{
    public partial class Belépés : Form
    {
        string jelszo = "202223";
        public Belépés()
        {
            InitializeComponent();
            button1.BackColor = Color.FromArgb(255, 183, 3);
            this.BackColor = Color.FromArgb(33, 158, 188);
            this.Text = "Hitelesítés";
            label1.BackColor= Color.FromArgb(33, 158, 188);
            label1.BorderStyle=BorderStyle.None;
            ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text==jelszo)
            {
                Alkalmazás alk= new Alkalmazás();
                alk.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Hibás jelszó!");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text == jelszo)
                {
                    Alkalmazás alk = new Alkalmazás();
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
}