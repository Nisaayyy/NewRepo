using MediatR;
using StockTrackingSystem.Business.ProductTransferDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransferDetails.Requests
{
    public class ProductTransferDetailDeleteRequest : IRequest<ProductTransferDetailDeleteModel?>
    {
        public int Id { get; set; }
    }
}
