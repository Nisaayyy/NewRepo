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
    public class TransferLogDeleteHandler : IRequestHandler<TransferLogDeleteRequest, TransferLogDeleteModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public TransferLogDeleteHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<TransferLogDeleteModel?> Handle(TransferLogDeleteRequest request, CancellationToken ct)
        {
            var e = await _db.TransferLogs.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (e is null) return null;

            _db.TransferLogs.Remove(e);
            await _db.SaveChangesAsync(ct);

            return new TransferLogDeleteModel { Id = request.Id, Success = true, Message = "Log silindi." };
        }
    }
}
