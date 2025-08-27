using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.ProductTransfers.Models;
using StockTrackingSystem.Business.ProductTransfers.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransfer = StockTrackingSystem.Data.EF.dbo.ProductTransfer;

namespace StockTrackingSystem.Business.ProductTransfers.Handlers
{
    public class ProductTransferUpsertHandler : IRequestHandler<ProductTransferUpsertRequest, ProductTransferUpsertModel>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductTransferUpsertHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductTransferUpsertModel> Handle(ProductTransferUpsertRequest r, CancellationToken ct)
        {
            if (r.StoreIdFrom == r.StoreIdTo)
                throw new ArgumentException("Kaynak ve hedef mağaza aynı olamaz.");

            var fromExists = await _db.Stores.AnyAsync(s => s.Id == r.StoreIdFrom, ct);
            var toExists = await _db.Stores.AnyAsync(s => s.Id == r.StoreIdTo, ct);
            var userExists = await _db.Users.AnyAsync(u => u.Id == r.UserId, ct);
            if (!fromExists) throw new KeyNotFoundException($"Kaynak mağaza bulunamadı. Id={r.StoreIdFrom}");
            if (!toExists) throw new KeyNotFoundException($"Hedef mağaza bulunamadı. Id={r.StoreIdTo}");
            if (!userExists) throw new KeyNotFoundException($"Kullanıcı bulunamadı. Id={r.UserId}");

            if (r.Id > 0)
            {
                var e = await _db.ProductTransfers.FirstOrDefaultAsync(x => x.Id == r.Id, ct);
                if (e is null)
                {
                    var ins = new DataTransfer
                    {
                        StoreIdFrom = r.StoreIdFrom,
                        StoreIdTo = r.StoreIdTo,
                        TransferDate = r.TransferDate ?? DateTime.UtcNow,
                        Status = r.Status.Trim(),
                        UserId = r.UserId,
                        CreatedAt = DateTime.UtcNow
                    };
                    _db.ProductTransfers.Add(ins);
                    await _db.SaveChangesAsync(ct);
                    return new ProductTransferUpsertModel { Id = ins.Id, Mesaj = "Eklendi (upsert)" };
                }

                e.StoreIdFrom = r.StoreIdFrom;
                e.StoreIdTo = r.StoreIdTo;
                e.TransferDate = r.TransferDate ?? e.TransferDate;
                e.Status = r.Status.Trim();
                e.UserId = r.UserId;

                await _db.SaveChangesAsync(ct);
                return new ProductTransferUpsertModel { Id = e.Id, Mesaj = "Güncellendi" };
            }
            else
            {
                var e = new DataTransfer
                {
                    StoreIdFrom = r.StoreIdFrom,
                    StoreIdTo = r.StoreIdTo,
                    TransferDate = r.TransferDate ?? DateTime.UtcNow,
                    Status = r.Status.Trim(),
                    UserId = r.UserId,
                    CreatedAt = DateTime.UtcNow
                };
                _db.ProductTransfers.Add(e);
                await _db.SaveChangesAsync(ct);
                return new ProductTransferUpsertModel { Id = e.Id, Mesaj = "Eklendi" };
            }
        }
    }
}