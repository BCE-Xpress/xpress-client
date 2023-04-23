namespace UserMaintenance
{
    public partial class belepes : Form
    {
        public belepes()
        {
            InitializeComponent();
            button1.BackColor = Color.FromArgb(255, 183, 3);
            this.BackColor = Color.FromArgb(33, 158, 188);
            label1.BackColor= Color.FromArgb(33, 158, 188);
            label1.BorderStyle=BorderStyle.None;
            ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jelszo = "202223";
            if (textBox1.Text==jelszo)
            {
                alkalmazas alk= new alkalmazas();
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