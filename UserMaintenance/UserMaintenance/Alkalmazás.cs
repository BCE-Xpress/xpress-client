﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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
            Console.WriteLine(response.Substring(0,1531));

            if (response == "")
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("HIBA TÖRTÉNT AZ API KÉRÉS KÖZBEN");
                return;
            }
            listBox1.Text = response;
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
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

    }
}
