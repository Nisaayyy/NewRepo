using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Categories.Models
{
    public class CategoryDeleteModel
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}

