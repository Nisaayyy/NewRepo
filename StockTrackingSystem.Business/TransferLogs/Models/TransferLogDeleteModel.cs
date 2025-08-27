using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.TransferLogs.Models
{
    public class TransferLogDeleteModel
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
