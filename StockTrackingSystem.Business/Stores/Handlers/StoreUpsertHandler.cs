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
using DataStore = StockTrackingSystem.Data.EF.dbo.Store; 

namespace StockTrackingSystem.Business.Store.Handlers
{
    public class StoreUpsertHandler : IRequestHandler<StoreUpsertRequest, StoreUpsertModel>
    {
        private readonly StockTrackingSystemDbContext _db;

        public StoreUpsertHandler(StockTrackingSystemDbContext db)
        {
            _db = db;
        }

        public async Task<StoreUpsertModel> Handle(StoreUpsertRequest request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                var entity = new DataStore
                {
                    StoreName = request.StoreName?.Trim(),
                    Location = string.IsNullOrWhiteSpace(request.Location) ? null : request.Location.Trim(),
                    IsActive = request.IsActive,
                    CreatedAt = DateTime.UtcNow
                };

                _db.Stores.Add(entity);
                await _db.SaveChangesAsync(cancellationToken);

                return new StoreUpsertModel { Id = entity.Id, Message = "Eklendi" };
            }
            else
            {
                var entity = await _db.Stores.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (entity == null)
                    throw new KeyNotFoundException($"Mağaza bulunamadı. Id={request.Id}");

                entity.StoreName = request.StoreName?.Trim();
                entity.Location = string.IsNullOrWhiteSpace(request.Location) ? null : request.Location.Trim();
                entity.IsActive = request.IsActive;

                await _db.SaveChangesAsync(cancellationToken);

                return new StoreUpsertModel { Id = entity.Id, Message = "Güncellendi" };
            }
        }
    }
}