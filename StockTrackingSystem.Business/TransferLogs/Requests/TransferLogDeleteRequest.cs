using MediatR;
using StockTrackingSystem.Business.TransferLogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.TransferLogs.Requests
{
    public class TransferLogDeleteRequest : IRequest<TransferLogDeleteModel?>
    {
        public int Id { get; set; }
    }
}