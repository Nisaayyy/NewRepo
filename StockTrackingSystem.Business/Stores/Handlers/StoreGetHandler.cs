using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.Stores.Models;
using StockTrackingSystem.Business.Stores.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace StockTrackingSystem.Business.Stores.Handlers
{
    public class StoreGetHandler : IRequestHandler<StoreGetRequest, StoreGetModel?>
    {
        private readonly StockTrackingSystemDbContext _db;

        public StoreGetHandler(StockTrackingSystemDbContext db)
        {
            _db = db;
        }

        public async Task<StoreGetModel?> Handle(StoreGetRequest request, CancellationToken cancellationToken)
        {
            var entity = await _db.Stores
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null) return null;

            return new StoreGetModel
            {
                Id = entity.Id,
                StoreName = entity.StoreName,
                Location = entity.Location,
                IsActive = entity.IsActive,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
