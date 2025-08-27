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
    [Table("Store", Schema = "dbo")]
    public class Store : BaseEntity
    {     
        public string? StoreName { get; set; }    
        public string? Location { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<ProductInventory> Inventories { get; set; } = new HashSet<ProductInventory>();
        public ICollection<ProductTransfer> OutgoingTransfers { get; set; } = new HashSet<ProductTransfer>();
        public ICollection<ProductTransfer> IncomingTransfers { get; set; } = new HashSet<ProductTransfer>();
    }
}