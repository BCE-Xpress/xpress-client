namespace UserMaintenance
{
    public partial class Bel�p�s : Form
    {
        string jelszo = "202223";
        public Bel�p�s()
        {
            InitializeComponent();
            button1.BackColor = Color.FromArgb(255, 183, 3);
            this.BackColor = Color.FromArgb(33, 158, 188);
            this.Text = "Hiteles�t�s";
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
                Alkalmaz�s alk= new Alkalmaz�s();
                alk.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Hib�s jelsz�!");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text == jelszo)
                {
                    Alkalmaz�s alk = new Alkalmaz�s();
                    alk.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Hib�s jelsz�!");
                }
            }
        }
    }
}