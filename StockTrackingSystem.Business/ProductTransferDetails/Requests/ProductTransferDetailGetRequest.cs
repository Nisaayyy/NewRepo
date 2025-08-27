using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.ProductTransferDetails.Models;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransferDetails.Requests
{
    public class ProductTransferDetailGetRequest : IRequest<ProductTransferDetailGetModel?>
    {
        public int Id { get; set; }
    }
}