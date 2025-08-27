using StockTrackingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Data.EF.dbo
{
    [Table("ProductInventory", Schema = "dbo")]
    public class ProductInventory
    {
      
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
