using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using XAct;
using Timer = System.Windows.Forms.Timer;

namespace UserMaintenance
{
	public partial class Alkalmazás : Form
	{
		Timer timer;
		public Alkalmazás()
		{
			InitializeComponent();
			panel1.BackColor = Color.FromArgb(33, 158, 188);
			button1.BackColor = Color.FromArgb(255, 183, 3);
			label9.BackColor = Color.FromArgb(255, 183, 3);
			this.Text = "Alkalmazás";
			AllocConsole();


		}
		Root root;
		RootInventory rootInventory;
		string Bvin;

		private async void alkalmazas_Load(object sender, EventArgs e)
		{
			DateTime localDate = DateTime.Now;
			Console.WriteLine(localDate);
			Console.WriteLine("XPRESS CLIENT STARTED");
			Console.WriteLine("------------------------------------------------------------------------");
			Console.WriteLine("LOADING DATA FROM HOTCAKES API...");
			label10.Text = "Adatok lekérére...";
			label10.ForeColor = Color.Blue;
			try
			{
				root = await ApiHelper.GetAllProducts();
				rootInventory = await ApiHelper.GetAllProductInventory();

			}
			catch (Exception err)
			{
				Console.WriteLine("------------------------------------------------------------------------");
				Console.WriteLine(err);
				label10.Text = "Hiba történt az adatok lekérése közben :(";
				label10.ForeColor = Color.Red;
				return;
			}

			if (root == null || rootInventory == null)
			{
				Console.WriteLine("------------------------------------------------------------------------");
				foreach (var item in root.Errors)
				{
					Console.WriteLine(item);
				}
				foreach (var item in rootInventory.ErrorsInventory)
				{
					Console.WriteLine(item);
				}
				Console.WriteLine("HIBA TÖRTÉNT AZ ADATTAL.");
				return;
			}

			label10.Text = "Adatok lekérése sikeres :)";
			label10.ForeColor = Color.Green;

			Szűrés();

			//foreach (var product in root.Content.Products)
			//{
			//    Console.WriteLine(product.ProductName);
			//}

			//foreach (var product in rootInventory.Content)
			//{
			//    Console.WriteLine(product.Bvin);
			//}
		}


		private async void button1_Click(object sender, EventArgs e)
		{
			timer = new Timer();
			timer.Interval = 3000;
			timer.Tick += Timer_Tick;
			DialogResult result = MessageBox.Show("Biztosan módosítod az adatokat?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				for (int i = 0; i < (root.Content.Products).Count; i++)
				{
					try
					{
						if (root.Content.Products[i].Bvin == Bvin)
						{
							root.Content.Products[i].ProductName = textBox7.Text;
							root.Content.Products[i].IsAvailableForSale = checkBox2.Checked;
							root.Content.Products[i].SitePrice = textBox6.Text + ".00000";
							textBox4.Text = textBox7.Text;
							textBox3.Text = textBox6.Text;
							checkBox1.Checked = checkBox2.Checked;
						}
						if (rootInventory.Content[i].ProductBvin == Bvin)
						{

							rootInventory.Content[i].QuantityOnHand = int.Parse(textBox5.Text) + rootInventory.Content[i].QuantityReserved;
							textBox2.Text = textBox5.Text;
						}
						label9.Visible = true;
						timer.Start();


						/////////////
						//API hívás//
						/////////////



					}
					catch (Exception)
					{

						throw;
					}
				}
			}

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

			Szűrés();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Product termek = (Product)listBox1.SelectedItem;
			var keresproduct = from x in root.Content.Products
							   where x.ProductName == termek.ProductName
							   select new Product
							   {
								   Bvin = x.Bvin,
								   ProductName = x.ProductName,
								   SitePrice = x.SitePrice,
								   IsAvailableForSale = x.IsAvailableForSale
							   };

			var valasztottproduct = keresproduct.First();
			Bvin = valasztottproduct.Bvin;
			var keresinventory = from x in rootInventory.Content
								 where x.ProductBvin == valasztottproduct.Bvin
								 select x;
			var valasztottinventory = keresinventory.First();




			textBox4.Text = valasztottproduct.ProductName;
			textBox7.Text = valasztottproduct.ProductName;
			checkBox1.Checked = valasztottproduct.IsAvailableForSale;
			checkBox2.Checked = valasztottproduct.IsAvailableForSale;
			textBox3.Text = (valasztottproduct.SitePrice).Substring(0, (valasztottproduct.SitePrice).IndexOf("."));
			textBox6.Text = (valasztottproduct.SitePrice).Substring(0, (valasztottproduct.SitePrice).IndexOf("."));
			textBox5.Text = (valasztottinventory.QuantityOnHand - valasztottinventory.QuantityReserved).ToString();
			textBox2.Text = (valasztottinventory.QuantityOnHand - valasztottinventory.QuantityReserved).ToString();

		}
		private void Szűrés()
		{
			var kurzusok = from x in root.Content.Products
						   where x.ProductName.ToLower().Contains(textBox1.Text)
						   select x;
			listBox1.DataSource = kurzusok.ToList();
			listBox1.DisplayMember = "ProductName";
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			label9.Visible = false;
			timer.Stop();
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

		//private Products CreateProductObject()
		//{
		//    return;

		//}
	}
}
