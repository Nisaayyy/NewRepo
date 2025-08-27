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
    public class SeasonDeleteHandler : IRequestHandler<SeasonDeleteRequest, SeasonDeleteModel?>
    {
        private readonly StockTrackingSystemDbContext _db;

        public SeasonDeleteHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<SeasonDeleteModel?> Handle(SeasonDeleteRequest request, CancellationToken ct)
        {
            var entity = await _db.Seasons.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (entity is null) return null;

            try
            {
                _db.Seasons.Remove(entity);
                await _db.SaveChangesAsync(ct);
                return new SeasonDeleteModel { Id = request.Id, Success = true, Message = "Sezon silindi." };
            }
            catch (DbUpdateException)
            {
                return new SeasonDeleteModel
                {
                    Id = request.Id,
                    Success = false,
                    Message = "Bu sezona bağlı kayıtlar olduğu için silinemiyor. Önce ilişkili verileri taşı veya sil."
                };
            }
        }
    }
}