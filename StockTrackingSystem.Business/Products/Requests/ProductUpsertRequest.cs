using MediatR;
using StockTrackingSystem.Business.Products.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Products.Requests
{
    public class ProductUpsertRequest : IRequest<ProductUpsertModel>
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Sezon zorunludur.")]
        public int SeasonId { get; set; }

        [Required(ErrorMessage = "Kategori zorunludur.")]
        public int CategoryId { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]
        public string ProductName { get; set; } = default!;

        [MaxLength(50)]
        public string? SKU { get; set; }

        [MaxLength(5)]
        public string? Size { get; set; }

        [MaxLength(50)]
        public string? Color { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
