using MediatR;
using StockTrackingSystem.Business.Seasons.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Seasons.Requests
{
    public class SeasonUpsertRequest : IRequest<SeasonUpsertModel>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sezon adı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Sezon adı en fazla 50 karakter olabilir.")]
        public string SeasonName { get; set; } = default!;
    }
}
