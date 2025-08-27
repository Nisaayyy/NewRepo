using MediatR;
using StockTrackingSystem.Business.ProductTransfers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransfers.Requests
{
    public class ProductTransferDeleteRequest : IRequest<ProductTransferDeleteModel?>
    {
        public int Id { get; set; }
    }
}
