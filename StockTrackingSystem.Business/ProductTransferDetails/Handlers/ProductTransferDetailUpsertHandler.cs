using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.ProductTransferDetails.Models;
using StockTrackingSystem.Business.ProductTransferDetails.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDetail = StockTrackingSystem.Data.EF.dbo.ProductTransferDetail;

namespace StockTrackingSystem.Business.ProductTransferDetails.Handlers
{
    public class ProductTransferDetailUpsertHandler : IRequestHandler<ProductTransferDetailUpsertRequest, ProductTransferDetailUpsertModel>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductTransferDetailUpsertHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductTransferDetailUpsertModel> Handle(ProductTransferDetailUpsertRequest r, CancellationToken ct)
        {
            var transferExists = await _db.ProductTransfers.AnyAsync(t => t.Id == r.TransferId, ct);
            var productExists = await _db.Products.AnyAsync(p => p.Id == r.ProductId, ct);
            if (!transferExists) throw new KeyNotFoundException($"Transfer bulunamadı. Id={r.TransferId}");
            if (!productExists) throw new KeyNotFoundException($"Ürün bulunamadı. Id={r.ProductId}");

            if (r.Id > 0)
            {
                var e = await _db.ProductTransferDetails.FirstOrDefaultAsync(x => x.Id == r.Id, ct);
                if (e is null)
                {
                    var ins = new DataDetail
                    {
                        TransferId = r.TransferId,
                        ProductId = r.ProductId,
                        Quantity = r.Quantity,
                        CreatedAt = DateTime.UtcNow
                    };
                    _db.ProductTransferDetails.Add(ins);
                    await _db.SaveChangesAsync(ct);
                    return new ProductTransferDetailUpsertModel { Id = ins.Id, Mesaj = "Eklendi (upsert)" };
                }

                e.TransferId = r.TransferId;
                e.ProductId = r.ProductId;
                e.Quantity = r.Quantity;

                await _db.SaveChangesAsync(ct);
                return new ProductTransferDetailUpsertModel { Id = e.Id, Mesaj = "Güncellendi" };
            }
            else
            {
                var e = new DataDetail
                {
                    TransferId = r.TransferId,
                    ProductId = r.ProductId,
                    Quantity = r.Quantity,
                    CreatedAt = DateTime.UtcNow
                };
                _db.ProductTransferDetails.Add(e);
                await _db.SaveChangesAsync(ct);
                return new ProductTransferDetailUpsertModel { Id = e.Id, Mesaj = "Eklendi" };
            }
        }
    }
}