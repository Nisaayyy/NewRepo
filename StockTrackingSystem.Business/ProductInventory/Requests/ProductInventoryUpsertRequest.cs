using MediatR;
using StockTrackingSystem.Business.ProductInventory.Models;
using StockTrackingSystem.Business.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductInventory.Requests
{
    public class ProductInventoryUpsertRequest : IRequest<ProductInventoryUpsertModel>
    {
        public int? Id { get; set; } 
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
