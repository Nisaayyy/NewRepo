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

namespace StockTrackingSystem.Business.Products.Handlers
{
    public class ProductGetHandler : IRequestHandler<ProductGetRequest, ProductGetModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductGetHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductGetModel?> Handle(ProductGetRequest request, CancellationToken ct)
        {
            var e = await _db.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (e == null) return null;

            return new ProductGetModel
            {
                Id = e.Id,
                SeasonId = e.SeasonId,
                CategoryId = e.CategoryId,
                ProductName = e.ProductName,
                SKU = e.SKU,
                Size = e.Size,
                Color = e.Color,
                Gender = e.Gender,
                IsActive = e.IsActive,
                CreatedAt = e.CreatedAt
            };
        }
    }
}
