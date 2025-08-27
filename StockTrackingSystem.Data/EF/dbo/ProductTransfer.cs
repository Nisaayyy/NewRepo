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
    [Table("ProductTransfer", Schema = "dbo")]
    public class ProductTransfer : BaseEntity
    {
     
        public int StoreIdFrom { get; set; }
        public int StoreIdTo { get; set; }
        public DateTime TransferDate { get; set; }
        public string? Status { get; set; }
        public int UserId { get; set; }       
        public ICollection<ProductTransferDetail> Details { get; set; } = new HashSet<ProductTransferDetail>();
        public ICollection<TransferLog> Logs { get; set; } = new HashSet<TransferLog>();
    }
}
