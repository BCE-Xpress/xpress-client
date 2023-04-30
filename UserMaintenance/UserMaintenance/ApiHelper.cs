using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace UserMaintenance
{
    public static class ApiHelper
    {
        private static readonly string API_URL = "http://20.234.113.211:8087/";
        private static readonly string API_PATH = "DesktopModules/Hotcakes/API/rest/v1/";
        private static readonly string API_KEY = "?key=1-2512619e-41b7-4f9d-af71-663bdb72c425";
        private static readonly string REQUEST_TYPE_PRODUCT = "products";
        private static readonly string REQUEST_TYPE_PRODUCT_INVENTORY = "productinventory";
        public static async Task<Root> GetAllProducts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync($"{API_URL}{API_PATH}{REQUEST_TYPE_PRODUCT}{API_KEY}"))
                    {
						    Console.WriteLine("----------------------------------GET REQUEST PRODUCT---------------------------------");
						Console.WriteLine($"STATUS: {res.StatusCode} \n HEADERS: {res.Headers}");
						using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                        
                            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(data);
                       
                            return myDeserializedClass;
                        }

                    }
                }
			}
			catch (Exception err)
			{
				throw err;
			}
		}
		public static async Task<RootInventory> GetAllProductInventory()
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage res = await client.GetAsync($"{API_URL}{API_PATH}{REQUEST_TYPE_PRODUCT_INVENTORY}{API_KEY}"))
					{
						Console.WriteLine("-------------------------------GET REQUEST PRODUCTINVENTORY----------------------------------");
						Console.WriteLine($"STATUS: {res.StatusCode} \n HEADERS: {res.Headers}");
						using (HttpContent content = res.Content)
						{
							string data = await content.ReadAsStringAsync();
                        
							RootInventory myDeserializedClass2 = JsonConvert.DeserializeObject<RootInventory>(data);

							return myDeserializedClass2;
						}

					}
				}
			}
			catch (Exception err)
			{
				throw err;
			}
		}
		public static async Task UpdateProduct(string bvin, Product updatedProduct)
        {
			try
			{
				using (HttpClient client = new HttpClient())
				{
					using HttpResponseMessage respone = await client.PostAsJsonAsync($"{API_URL}{API_PATH}{REQUEST_TYPE_PRODUCT}/{bvin}{API_KEY}", updatedProduct);
					Console.WriteLine("----------------------------------POST REQUEST PRODUCT---------------------------------");
					Console.WriteLine($"STATUS: {respone.StatusCode} \n HEADERS: {respone.Headers} \n UPDATED PRODUCT BVIN: {bvin} \n UPDATED PRODUCT NAME: {updatedProduct.ProductName}");
				}
			}
			catch (Exception err)
			{
				throw err;
			}
        }
		public static async Task UpdateProductInventory(string bvin, ContentInventory updatedProductInventory)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					using HttpResponseMessage respone = await client.PostAsJsonAsync($"{API_URL}{API_PATH}{REQUEST_TYPE_PRODUCT_INVENTORY}/{bvin}{API_KEY}", updatedProductInventory);
					Console.WriteLine("-------------------------------POST REQUEST PRODUCTINVENTORY----------------------------------");
					Console.WriteLine($"STATUS: {respone.StatusCode} \n HEADERS: {respone.Headers} \n UPDATED PRODUCT BVIN: {bvin}");
				}
			}
			catch (Exception err)
			{
				throw err;
			}
			
		}
	}
}
