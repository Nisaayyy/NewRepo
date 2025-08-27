using MediatR;
using StockTrackingSystem.Business.ProductTransferDetails.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransferDetails.Requests
{
    public class ProductTransferDetailUpsertRequest : IRequest<ProductTransferDetailUpsertModel>
    {
        public int Id { get; set; }               
        [Required] public int TransferId { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int Quantity { get; set; }
    }
}