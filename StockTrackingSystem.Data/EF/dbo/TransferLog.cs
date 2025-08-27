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
    [Table("TransferLog", Schema = "dbo")]
    public class TransferLog : BaseEntity
    {
        public int TransferId { get; set; }
        public string? Action { get; set; }
        public int UserId { get; set; }
        public DateTime ActionDate { get; set; }

    }
}
