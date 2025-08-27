using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.ProductInventory.Models;
using StockTrackingSystem.Business.ProductInventory.Requests;
using StockTrackingSystem.Data.EF;

namespace StockTrackingSystem.Business.ProductInventory.Handlers
{
    public class ProductInventoryUpsertHandler
        : IRequestHandler<ProductInventoryUpsertRequest, ProductInventoryUpsertModel>
    {
        private readonly StockTrackingSystemDbContext _context;
        public ProductInventoryUpsertHandler(StockTrackingSystemDbContext context) => _context = context;

        public async Task<ProductInventoryUpsertModel> Handle(ProductInventoryUpsertRequest req, CancellationToken ct)
        {
            var now = DateTime.UtcNow;
            string op;
            Data.EF.dbo.ProductInventory e;

            if (req.Id.GetValueOrDefault() > 0)
            {
                e = await _context.ProductInventory
                                  .FirstOrDefaultAsync(x => x.Id == req.Id!.Value, ct)
                     ?? throw new KeyNotFoundException("Inventory not found.");

                e.ProductId = req.ProductId;
                e.StoreId = req.StoreId;
                e.Quantity = req.Quantity;
                e.LastUpdated = now;            
                op = "Updated";
            }
            else
            {
                e = new Data.EF.dbo.ProductInventory
                {
                    ProductId = req.ProductId,
                    StoreId = req.StoreId,
                    Quantity = req.Quantity,
                    LastUpdated = now              
                };

                await _context.ProductInventory.AddAsync(e, ct);
                op = "Created";
            }

            await _context.SaveChangesAsync(ct);

            return new ProductInventoryUpsertModel
            {
                Id = e.Id,
                ProductId = e.ProductId,
                StoreId = e.StoreId,
                Quantity = e.Quantity,
                LastUpdated = e.LastUpdated,
                Operation = op,
                AffectedAt = now
            };
        }
    }
}
