using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.Categories.Models;
using StockTrackingSystem.Business.Categories.Requests;
using StockTrackingSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Categories.Handlers
{
    public class CategoryDeleteHandler : IRequestHandler<CategoryDeleteRequest, CategoryDeleteModel?>
    {
        private readonly StockTrackingSystemDbContext _db;
        public CategoryDeleteHandler(StockTrackingSystemDbContext db) => _db = db;

        public async Task<CategoryDeleteModel?> Handle(CategoryDeleteRequest request, CancellationToken ct)
        {
            var entity = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (entity is null) return null;

            try
            {
                _db.Categories.Remove(entity);
                await _db.SaveChangesAsync(ct);
                return new CategoryDeleteModel { Id = request.Id, Success = true, Message = "Kategori silindi." };
            }
            catch (DbUpdateException)
            {
                return new CategoryDeleteModel
                {
                    Id = request.Id,
                    Success = false,
                    Message = "Bu kategoriye bağlı kayıtlar olduğu için silinemiyor."
                };
            }
        }
    }
}
