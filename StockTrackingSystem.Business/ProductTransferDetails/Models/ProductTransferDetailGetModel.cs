using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransferDetails.Models
{
    public class ProductTransferDetailGetModel
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
