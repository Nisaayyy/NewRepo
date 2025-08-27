using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductInventory.Models
{
    public class ProductInventoryGetModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}


