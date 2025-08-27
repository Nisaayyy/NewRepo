using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.TransferLogs.Models;
using StockTrackingSystem.Business.TransferLogs.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.TransferLogs.Handlers
{
    public class TransferLogGetHandler : IRequestHandler<TransferLogGetRequest, TransferLogGetModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public TransferLogGetHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<TransferLogGetModel?> Handle(TransferLogGetRequest r, CancellationToken ct)
        {
            var e = await _db.TransferLogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == r.Id, ct);
            if (e == null) return null;

            return new TransferLogGetModel
            {
                Id = e.Id,
                TransferId = e.TransferId,
                Action = e.Action,
                UserId = e.UserId,
                ActionDate = e.ActionDate
            };
        }
    }
}
