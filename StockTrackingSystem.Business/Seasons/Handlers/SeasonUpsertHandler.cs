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
using DataSeason = StockTrackingSystem.Data.EF.dbo.Season;

namespace StockTrackingSystem.Business.Seasons.Handlers
{
    public class SeasonUpsertHandler : IRequestHandler<SeasonUpsertRequest, SeasonUpsertModel>
    {
        private readonly StockTrackingSystemDbContext _db;

        public SeasonUpsertHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<SeasonUpsertModel> Handle(SeasonUpsertRequest request, CancellationToken ct)
        {
            var name = request.SeasonName.Trim();

            if (request.Id > 0)
            {
                var entity = await _db.Seasons.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
                if (entity is null)
                {
                   
                    var inserted = new DataSeason
                    {
                        SeasonName = name,
                        CreatedAt = DateTime.UtcNow
                    };
                    _db.Seasons.Add(inserted);
                    await _db.SaveChangesAsync(ct);
                    return new SeasonUpsertModel { Id = inserted.Id, Message = "Eklendi (upsert)" };
                }

                entity.SeasonName = name;
                await _db.SaveChangesAsync(ct);
                return new SeasonUpsertModel { Id = entity.Id, Message = "Güncellendi" };
            }
            else
            {
                var entity = new DataSeason
                {
                    SeasonName = name,
                    CreatedAt = DateTime.UtcNow
                };
                _db.Seasons.Add(entity);
                await _db.SaveChangesAsync(ct);
                return new SeasonUpsertModel { Id = entity.Id, Message = "Eklendi" };
            }
        }
    }
}