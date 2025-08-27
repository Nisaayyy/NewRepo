using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.ProductInventory.Models;
using StockTrackingSystem.Business.ProductInventory.Requests;
using StockTrackingSystem.Data.EF;
using StockTrackingSystem.Data.EF.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductInventory.Handlers
{
    public class ProductInventoryDeleteHandler
        : IRequestHandler<ProductInventoryDeleteRequest, ProductInventoryDeleteModel?>
    {
        private readonly StockTrackingSystemDbContext _context;
        public ProductInventoryDeleteHandler(StockTrackingSystemDbContext context) => _context = context;

        public async Task<ProductInventoryDeleteModel?> Handle(ProductInventoryDeleteRequest request, CancellationToken ct)
        {
            var e = await _context.ProductInventory.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (e is null) return null;

            var dto = new ProductInventoryDeleteModel
            {
                Id = e.Id,
                ProductId = e.ProductId,
                StoreId = e.StoreId,
                Quantity = e.Quantity,
                LastUpdated = e.LastUpdated,
                DeletedAt = DateTime.UtcNow
            };

            _context.ProductInventory.Remove(e);
            await _context.SaveChangesAsync(ct);
            return dto;
        }
    }
}