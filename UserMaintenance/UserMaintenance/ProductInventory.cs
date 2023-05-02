using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMaintenance
{
	
	public class ContentInventory
	{
		public string Bvin { get; set; }
		public DateTime LastUpdated { get; set; }
		public string ProductBvin { get; set; }
		public string VariantId { get; set; }
		public int QuantityOnHand { get; set; }
		public int QuantityReserved { get; set; }
		public int LowStockPoint { get; set; }
		public int OutOfStockPoint { get; set; }
	}

	public class RootInventory
	{
		public List<ContentInventory> Content { get; set; }
		public List<object> ErrorsInventory { get; set; }
	}


	
}
