using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Categories.Models
{
    public class CategoryGetModel
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }   
        public DateTime? CreatedAt { get; set; }     
    }
}
