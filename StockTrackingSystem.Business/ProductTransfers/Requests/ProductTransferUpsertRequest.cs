using MediatR;
using StockTrackingSystem.Business.ProductTransfers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransfers.Requests
{
    public class ProductTransferUpsertRequest : IRequest<ProductTransferUpsertModel>
    {
        public int Id { get; set; }

        [Required] public int StoreIdFrom { get; set; }
        [Required] public int StoreIdTo { get; set; }

        public DateTime? TransferDate { get; set; }  

        [Required, MaxLength(50)]
        public string Status { get; set; } = default!;

        [Required] public int UserId { get; set; }
    }
}