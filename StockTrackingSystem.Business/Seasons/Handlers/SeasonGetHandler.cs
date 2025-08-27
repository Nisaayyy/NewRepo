using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.Seasons.Models;
using StockTrackingSystem.Business.Seasons.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Seasons.Handlers
{
    public class SeasonGetHandler : IRequestHandler<SeasonGetRequest, SeasonGetModel?>
    {
        private readonly StockTrackingSystemDbContext _db;

        public SeasonGetHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<SeasonGetModel?> Handle(SeasonGetRequest request, CancellationToken ct)
        {
            var entity = await _db.Seasons
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (entity == null) return null;

            return new SeasonGetModel
            {
                Id = entity.Id,
                SeasonName = entity.SeasonName,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}