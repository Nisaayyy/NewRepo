using MediatR;
using StockTrackingSystem.Business.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Products.Requests
{
    public class ProductDeleteRequest : IRequest<ProductDeleteModel?>
    {
        public int Id { get; set; }
    }
}
