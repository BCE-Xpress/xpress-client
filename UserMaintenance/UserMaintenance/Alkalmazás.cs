using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace UserMaintenance
{
    public partial class Alkalmazás : Form
    {
        
        public Alkalmazás()
        {
            InitializeComponent();
            panel1.BackColor= Color.FromArgb(33, 158, 188);
            button1.BackColor = Color.FromArgb(255, 183, 3);
            button2.BackColor = Color.FromArgb(255, 183, 3);
            this.Text = "Alkalmazás";
            string API_URL = "http://20.234.113.211:8087/DesktopModules/Hotcakes/API/rest/v1/";
            string API_KEY = "1-2512619e-41b7-4f9d-af71-663bdb72c425";
            string PRODUCTS = "products";
            string STOCK = "ProductInventory";
        }
 

        private void alkalmazas_Load(object sender, EventArgs e)
        {
            
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
                if (textBox5.Text!=string.Empty)
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

    }
}
