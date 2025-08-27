using MediatR;
using StockTrackingSystem.Business.Categories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Categories.Requests
{
    public class CategoryUpsertRequest : IRequest<CategoryUpsertModel>
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        public string? CategoryName { get; set; }
    }
}
