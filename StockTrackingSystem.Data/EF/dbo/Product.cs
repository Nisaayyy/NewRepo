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
    [Table("Product", Schema = "dbo")]
    public class Product : BaseEntity
    {
        public int? SeasonId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? SKU { get; set; }  
        public string? Size { get; set; }
        public string? Color { get; set; }
        public bool? Gender { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
