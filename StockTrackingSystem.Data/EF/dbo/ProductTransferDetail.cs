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
    [Table("ProductTransferDetail", Schema = "dbo")]
    public class ProductTransferDetail : BaseEntity
    {
        public int TransferId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}