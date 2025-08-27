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
    public class ProductDeleteHandler : IRequestHandler<ProductDeleteRequest, ProductDeleteModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductDeleteHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductDeleteModel?> Handle(ProductDeleteRequest request, CancellationToken ct)
        {
            var e = await _db.Products.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (e is null) return null;

            var usedInInventory = await _db.ProductInventory.AnyAsync(pi => pi.ProductId == request.Id, ct);
            var usedInDetails = await _db.ProductTransferDetails.AnyAsync(d => d.ProductId == request.Id, ct);
            if (usedInInventory || usedInDetails)
            {
                return new ProductDeleteModel
                {
                    Id = request.Id,
                    Success = false,
                    Message = "Ürün ilişkili kayıtlarda kullanılıyor. Önce bu kayıtları taşı/sil."
                };
            }

            _db.Products.Remove(e);
            await _db.SaveChangesAsync(ct);
            return new ProductDeleteModel { Id = request.Id, Success = true, Message = "Ürün silindi." };
        }
    }
}