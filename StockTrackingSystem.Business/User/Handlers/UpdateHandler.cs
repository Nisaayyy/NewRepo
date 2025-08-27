using MediatR;
using StockTrackingSystem.Business.User.Models;
using StockTrackingSystem.Business.User.Requests;
using StockTrackingSystem.Data.EF;

namespace StockTrackingSystem.Business.User.Handlers
{
    public class UpdateHandler : IRequestHandler<UpdateRequest, UpdateModel>
    {
        private readonly StockTrackingSystemDbContext _context;

        public UpdateHandler(StockTrackingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateModel> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı!");

            if (!string.IsNullOrWhiteSpace(request.UserName))
                user.UserName = request.UserName;

            if (!string.IsNullOrWhiteSpace(request.Email))
                user.Email = request.Email;

            if (!string.IsNullOrWhiteSpace(request.Password))
                user.Password = request.Password; 

            await _context.SaveChangesAsync();

            return new UpdateModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email
            };
        }
    }
}

