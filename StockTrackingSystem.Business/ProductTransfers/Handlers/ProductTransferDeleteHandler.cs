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
    public class ProductTransferDeleteHandler : IRequestHandler<ProductTransferDeleteRequest, ProductTransferDeleteModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public ProductTransferDeleteHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<ProductTransferDeleteModel?> Handle(ProductTransferDeleteRequest request, CancellationToken ct)
        {
            var e = await _db.ProductTransfers.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (e is null) return null;

            var hasDetails = await _db.ProductTransferDetails.AnyAsync(d => d.TransferId == request.Id, ct);
            if (hasDetails)
                return new ProductTransferDeleteModel { Id = request.Id, Success = false, Message = "Bu transferin detayları var. Önce detayları sil/taşı." };

            var hasLogs = await _db.TransferLogs.AnyAsync(l => l.TransferId == request.Id, ct);
            if (hasLogs)
                return new ProductTransferDeleteModel { Id = request.Id, Success = false, Message = "Bu transfer loglandı. Önce logları sil." };

            _db.ProductTransfers.Remove(e);
            await _db.SaveChangesAsync(ct);
            return new ProductTransferDeleteModel { Id = request.Id, Success = true, Message = "Transfer silindi." };
        }
    }
}
