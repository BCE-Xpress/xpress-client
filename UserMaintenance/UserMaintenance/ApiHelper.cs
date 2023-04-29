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
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync($"{API_URL}{API_PATH}{REQUEST_TYPE_PRODUCT}{API_KEY}"))
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine(res);
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(data);
                       
                        return myDeserializedClass;
                    }

                }
            }
        }
		public static async Task<RootInventory> GetAllProductInventory()
		{
			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage res = await client.GetAsync($"{API_URL}{API_PATH}{REQUEST_TYPE_PRODUCT_INVENTORY}{API_KEY}"))
				{
					Console.WriteLine("------------------------------------------------------------------------");
					Console.WriteLine(res);
					using (HttpContent content = res.Content)
					{
						string data = await content.ReadAsStringAsync();
                        
						RootInventory myDeserializedClass2 = JsonConvert.DeserializeObject<RootInventory>(data);

						return myDeserializedClass2;
					}

				}
			}
		}
		public static async Task<string> UpdateProduct()
        {
            using (HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage res = await client.PutAsJsonAsync($"{API_URL}{API_PATH}{REQUEST_TYPE_PRODUCT}{API_KEY}",""))
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine(res);
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        
                        return data;
                    }
                }
            }
        }
    }
}
