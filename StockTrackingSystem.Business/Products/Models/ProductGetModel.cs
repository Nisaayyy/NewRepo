using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Products.Models
{
    public class ProductGetModel
    {
        public int Id { get; set; }
        public int? SeasonId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = default!;
        public string? SKU { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public bool? Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

