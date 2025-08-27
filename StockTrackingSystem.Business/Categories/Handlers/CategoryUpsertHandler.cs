using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.Categories.Models;
using StockTrackingSystem.Business.Categories.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCategory = StockTrackingSystem.Data.EF.dbo.Category;

namespace StockTrackingSystem.Business.Categories.Handlers
{
    public class CategoryUpsertHandler : IRequestHandler<CategoryUpsertRequest, CategoryUpsertModel>
    {
        private readonly StockTrackingSystemDbContext _db;
        public CategoryUpsertHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<CategoryUpsertModel> Handle(CategoryUpsertRequest request, CancellationToken ct)
        {
            var name = request.CategoryName?.Trim();

            if (request.Id > 0)
            {
                var entity = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
                if (entity is null)
                {
                    var inserted = new DataCategory
                    {
                        CategoryName = name,
                        CreatedAt = DateTime.UtcNow
                    };
                    _db.Categories.Add(inserted);
                    await _db.SaveChangesAsync(ct);
                    return new CategoryUpsertModel { Id = inserted.Id, Mesaj = "Eklendi (upsert)" };
                }

                entity.CategoryName = name;
                await _db.SaveChangesAsync(ct);
                return new CategoryUpsertModel { Id = entity.Id, Mesaj = "Güncellendi" };
            }
            else
            {
                var entity = new DataCategory
                {
                    CategoryName = name,
                    CreatedAt = DateTime.UtcNow
                };
                _db.Categories.Add(entity);
                await _db.SaveChangesAsync(ct);
                return new CategoryUpsertModel { Id = entity.Id, Mesaj = "Eklendi" };
            }
        }
    }
}
