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
    public class StoreDeleteHandler : IRequestHandler<StoreDeleteRequest, StoreDeleteModel?>
    {
        private readonly StockTrackingSystemDbContext _db;

        public StoreDeleteHandler(StockTrackingSystemDbContext db)
        {
            _db = db;
        }

        public async Task<StoreDeleteModel?> Handle(StoreDeleteRequest request, CancellationToken cancellationToken)
        {
            var entity = await _db.Stores.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null)
                return null;

           
            _db.Stores.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);

            return new StoreDeleteModel
            {
                Id = request.Id,
                Success = true,
                Message = "Mağaza silindi."
            };
        }
    }
}
