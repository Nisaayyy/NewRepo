using MediatR;
using StockTrackingSystem.Business.ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductInventory.Requests
{
    public class ProductInventoryDeleteRequest : IRequest<ProductInventoryDeleteModel>
    {
        public int Id { get; set; }
    }
}
