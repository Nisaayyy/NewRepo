using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Stores.Models
{
    public class StoreGetModel
    {
        public int Id { get; set; }
        public string StoreName { get; set; } = default!;
        public string? Location { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
