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

namespace StockTrackingSystem.Business.Categories.Handlers
{
    public class CategoryGetHandler : IRequestHandler<CategoryGetRequest, CategoryGetModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public CategoryGetHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<CategoryGetModel?> Handle(CategoryGetRequest request, CancellationToken ct)
        {
            var entity = await _db.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (entity == null) return null;

            return new CategoryGetModel
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}