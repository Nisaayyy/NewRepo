using MediatR;
using StockTrackingSystem.Business.TransferLogs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.TransferLogs.Requests
{
    public class TransferLogUpsertRequest : IRequest<TransferLogUpsertModel>
    {
        public int Id { get; set; }

        [Required] public int TransferId { get; set; }
        [Required, MaxLength(100)] public string Action { get; set; } = default!;
        [Required] public int UserId { get; set; }
        public DateTime? ActionDate { get; set; }
    }
}
