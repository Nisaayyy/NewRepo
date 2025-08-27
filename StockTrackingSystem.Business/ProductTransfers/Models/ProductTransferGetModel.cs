using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransfers.Models
{
    public class ProductTransferGetModel
    {
        public int Id { get; set; }
        public int StoreIdFrom { get; set; }
        public int StoreIdTo { get; set; }
        public DateTime TransferDate { get; set; }
        public string? Status { get; set; } = default!;
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

