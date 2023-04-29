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
        Root root;
		RootInventory rootInventory;


        private async void alkalmazas_Load(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            Console.WriteLine(localDate);
            Console.WriteLine("XPRESS CLIENT STARTED");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("LOADING DATA FROM HOTCAKES API...");
            
            root = await ApiHelper.GetAllProducts();
            rootInventory = await ApiHelper.GetAllProductInventory();
            
            if (root.Content == null)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                foreach (var item in root.Errors)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("HIBA TÖRTÉNT AZ ADATTAL.");
                return;
            }


            foreach (var product in root.Content.Products)
            {
                listBox1.Items.Add(product.ProductName);
            }

            //foreach (var item in rootInventory.ContentInventory)
            //{
            //    Console.WriteLine(item.Bvin);
            //}
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

			
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            var kurzusok = from x in root.Content.Products
                           where x.ProductName.Contains(textBox1.Text)
                           select x;
            listBox1.DataSource = kurzusok.ToList();
            listBox1.DisplayMember = "ProductName";
        }
        //private Products CreateProductObject()
        //{
        //    return;

        //}
    }
}
