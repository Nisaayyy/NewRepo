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
    public class ProductTransferDetailDeleteHandler : IRequestHandler<ProductTransferDetailDeleteRequest, ProductTransferDetailDeleteModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductTransferDetailDeleteHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductTransferDetailDeleteModel?> Handle(ProductTransferDetailDeleteRequest request, CancellationToken ct)
        {
            var e = await _db.ProductTransferDetails.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (e is null) return null;

            _db.ProductTransferDetails.Remove(e);
            await _db.SaveChangesAsync(ct);

            return new ProductTransferDetailDeleteModel
            {
                Id = request.Id,
                Success = true,
                Message = "Transfer detayı silindi."
            };
        }
    }
}