using MediatR;
using StockTrackingSystem.Business.Stores.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Stores.Requests
{
    public class StoreUpsertRequest : IRequest<StoreUpsertModel>
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string StoreName { get; set; } = default!;

        public string? Location { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
