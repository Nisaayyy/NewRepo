using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.TransferLogs.Models
{
    public class TransferLogGetModel
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public string Action { get; set; } = default!;
        public int UserId { get; set; }
        public DateTime? ActionDate { get; set; }
    }
}
