using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace UserMaintenance
{
    public partial class Alkalmazás : Form
    {

        public Alkalmazás()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(33, 158, 188);
            button1.BackColor = Color.FromArgb(255, 183, 3);
            button2.BackColor = Color.FromArgb(255, 183, 3);
            this.Text = "Alkalmazás";
            AllocConsole();

        }



        private async void alkalmazas_Load(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            Console.WriteLine(localDate);
            Console.WriteLine("XPRESS CLIENT STARTED");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("LOADING DATA FROM HOTCAKES API...");

            var response = await ApiHelper.GetAllProducts();

            if (response == null)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("HIBA TÖRTÉNT AZ API KÉRÉS KÖZBEN");
                return;
            }
            foreach (Product product in response.Content.Products)
            {
                listBox1.Items.Add(product.ProductName);
            }
        }

        private void alkalmazas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[0-9]");
            if (!regex.IsMatch(textBox5.Text))
            {
                if (textBox5.Text != string.Empty)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox5, "Csak számot lehet megadni!");
                }
            }
        }

        private void textBox5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox5, string.Empty);
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[0-9]");
            if (!regex.IsMatch(textBox6.Text))
            {
                if (textBox6.Text != string.Empty)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox6, "Csak számot lehet megadni!");
                }
            }
        }

        private void textBox6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox6, string.Empty);
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private async void button1_Click(object sender, EventArgs e)
        {
            
            var response = await ApiHelper.UpdateProduct();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        //private Products CreateProductObject()
        //{
        //    return;

        //}
    }
}
