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

namespace StockTrackingSystem.Business.ProductTransferDetails.Handlers
{
    public class ProductTransferDetailGetHandler : IRequestHandler<ProductTransferDetailGetRequest, ProductTransferDetailGetModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductTransferDetailGetHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductTransferDetailGetModel?> Handle(ProductTransferDetailGetRequest r, CancellationToken ct)
        {
            var e = await _db.ProductTransferDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == r.Id, ct);

            if (e == null) return null;

            return new ProductTransferDetailGetModel
            {
                Id = e.Id,
                TransferId = e.TransferId,
                ProductId = e.ProductId,
                Quantity = e.Quantity,
                CreatedAt = e.CreatedAt
            };
        }
    }
}