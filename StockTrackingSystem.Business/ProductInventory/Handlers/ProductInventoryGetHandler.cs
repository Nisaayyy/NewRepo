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
    public class ProductInventoryGetHandler
        : IRequestHandler<ProductInventoryGetRequest, ProductInventoryGetModel?>
    {
        private readonly StockTrackingSystemDbContext _context;
        public ProductInventoryGetHandler(StockTrackingSystemDbContext context) => _context = context;

        public async Task<ProductInventoryGetModel?> Handle(ProductInventoryGetRequest request, CancellationToken ct)
        {
            var e = await _context.ProductInventory
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (e is null) return null;

            return new ProductInventoryGetModel
            {
                Id = e.Id,
                ProductId = e.ProductId,
                StoreId = e.StoreId,
                Quantity = e.Quantity,
                LastUpdated = e.LastUpdated
            };
        }
    }
}