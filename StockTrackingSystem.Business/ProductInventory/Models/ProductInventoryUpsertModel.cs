using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductInventory.Models
{
    public class ProductInventoryUpsertModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }

        public string Operation { get; set; } = ""; 
        public DateTime AffectedAt { get; set; }
    }
}
