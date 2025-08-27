using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.ProductTransfers.Models;
using StockTrackingSystem.Business.ProductTransfers.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.ProductTransfers.Handlers
{
    public class ProductTransferGetHandler : IRequestHandler<ProductTransferGetRequest, ProductTransferGetModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductTransferGetHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductTransferGetModel?> Handle(ProductTransferGetRequest r, CancellationToken ct)
        {
            var e = await _db.ProductTransfers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == r.Id, ct);
            if (e == null) return null;

            return new ProductTransferGetModel
            {
                Id = e.Id,
                StoreIdFrom = e.StoreIdFrom,
                StoreIdTo = e.StoreIdTo,
                TransferDate = e.TransferDate,
                Status = e.Status,
                UserId = e.UserId,
                CreatedAt = e.CreatedAt
            };
        }
    }
}