using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.Products.Models;
using StockTrackingSystem.Business.Products.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProduct = StockTrackingSystem.Data.EF.dbo.Product;

namespace StockTrackingSystem.Business.Products.Handlers
{
    public class ProductUpsertHandler : IRequestHandler<ProductUpsertRequest, ProductUpsertModel>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductUpsertHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductUpsertModel> Handle(ProductUpsertRequest r, CancellationToken ct)
        {
            var seasonExists = await _db.Seasons.AnyAsync(s => s.Id == r.SeasonId, ct);
            var categoryExists = await _db.Categories.AnyAsync(c => c.Id == r.CategoryId, ct);
            if (!seasonExists) throw new KeyNotFoundException($"Sezon bulunamadı. Id={r.SeasonId}");
            if (!categoryExists) throw new KeyNotFoundException($"Kategori bulunamadı. Id={r.CategoryId}");

            if (r.Id > 0)
            {
                var e = await _db.Products.FirstOrDefaultAsync(x => x.Id == r.Id, ct);
                if (e is null)
                {
                    var ins = new DataProduct
                    {
                        SeasonId = r.SeasonId,
                        CategoryId = r.CategoryId,
                        ProductName = r.ProductName.Trim(),
                        SKU = r.SKU?.Trim(),
                        Size = r.Size?.Trim(),
                        Color = r.Color?.Trim(),
                        Gender = r.Gender,
                        IsActive = r.IsActive,
                        CreatedAt = DateTime.UtcNow
                    };
                    _db.Products.Add(ins);
                    await _db.SaveChangesAsync(ct);
                    return new ProductUpsertModel { Id = ins.Id, Mesaj = "Eklendi (upsert)" };
                }

                e.SeasonId = r.SeasonId;
                e.CategoryId = r.CategoryId;
                e.ProductName = r.ProductName.Trim();
                e.SKU = r.SKU?.Trim();
                e.Size = r.Size?.Trim();
                e.Color = r.Color?.Trim();
                e.Gender = r.Gender;
                e.IsActive = r.IsActive;

                await _db.SaveChangesAsync(ct);
                return new ProductUpsertModel { Id = e.Id, Mesaj = "Güncellendi" };
            }
            else
            {
                var e = new DataProduct
                {
                    SeasonId = r.SeasonId,
                    CategoryId = r.CategoryId,
                    ProductName = r.ProductName.Trim(),
                    SKU = r.SKU?.Trim(),
                    Size = r.Size?.Trim(),
                    Color = r.Color?.Trim(),
                    Gender = r.Gender,
                    IsActive = r.IsActive,
                    CreatedAt = DateTime.UtcNow
                };
                _db.Products.Add(e);
                await _db.SaveChangesAsync(ct);
                return new ProductUpsertModel { Id = e.Id, Mesaj = "Eklendi" };
            }
        }
    }
}
