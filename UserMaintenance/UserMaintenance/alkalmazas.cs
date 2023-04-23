using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMaintenance
{
    public partial class alkalmazas : Form
    {
        public alkalmazas()
        {
            InitializeComponent();
            panel1.BackColor= Color.FromArgb(33, 158, 188);
            button1.BackColor = Color.FromArgb(255, 183, 3);
            button2.BackColor = Color.FromArgb(255, 183, 3);
           

        }

        private void alkalmazas_Load(object sender, EventArgs e)
        {

        }

        private void alkalmazas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
