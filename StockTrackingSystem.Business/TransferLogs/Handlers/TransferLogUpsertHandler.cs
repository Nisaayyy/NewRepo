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
using DataLog = StockTrackingSystem.Data.EF.dbo.TransferLog;

namespace StockTrackingSystem.Business.TransferLogs.Handlers
{
    public class TransferLogUpsertHandler : IRequestHandler<TransferLogUpsertRequest, TransferLogUpsertModel>
    {
        private readonly StockTrackingSystemDbContext _db;
        public TransferLogUpsertHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<TransferLogUpsertModel> Handle(TransferLogUpsertRequest r, CancellationToken ct)
        {
            var transferExists = await _db.ProductTransfers.AnyAsync(t => t.Id == r.TransferId, ct);
            var userExists = await _db.Users.AnyAsync(u => u.Id == r.UserId, ct);
            if (!transferExists) throw new KeyNotFoundException($"Transfer bulunamadı. Id={r.TransferId}");
            if (!userExists) throw new KeyNotFoundException($"Kullanıcı bulunamadı. Id={r.UserId}");

            if (r.Id > 0)
            {
                var e = await _db.TransferLogs.FirstOrDefaultAsync(x => x.Id == r.Id, ct);
                if (e is null)
                {
                    var ins = new DataLog
                    {
                        TransferId = r.TransferId,
                        Action = r.Action.Trim(),
                        UserId = r.UserId,
                        ActionDate = r.ActionDate ?? DateTime.UtcNow
                    };
                    _db.TransferLogs.Add(ins);
                    await _db.SaveChangesAsync(ct);
                    return new TransferLogUpsertModel { Id = ins.Id, Mesaj = "Eklendi (upsert)" };
                }

                e.TransferId = r.TransferId;
                e.Action = r.Action.Trim();
                e.UserId = r.UserId;
                e.ActionDate = r.ActionDate ?? e.ActionDate;

                await _db.SaveChangesAsync(ct);
                return new TransferLogUpsertModel { Id = e.Id, Mesaj = "Güncellendi" };
            }
            else
            {
                var e = new DataLog
                {
                    TransferId = r.TransferId,
                    Action = r.Action.Trim(),
                    UserId = r.UserId,
                    ActionDate = r.ActionDate ?? DateTime.UtcNow
                };
                _db.TransferLogs.Add(e);
                await _db.SaveChangesAsync(ct);
                return new TransferLogUpsertModel { Id = e.Id, Mesaj = "Eklendi" };
            }
        }
    }
}
