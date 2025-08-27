using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransfers.Models
{
    public class ProductTransferUpsertModel
    {
        public int Id { get; set; }
        public string Mesaj { get; set; } = "Başarılı";
    }
}
