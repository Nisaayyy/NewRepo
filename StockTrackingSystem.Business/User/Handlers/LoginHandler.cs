using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.User.Models;
using StockTrackingSystem.Business.User.Requests;
using StockTrackingSystem.Data.EF;
using StockTrackingSystem.Data.EF.dbo;
using StockTrackingSystem.Business.Utils; 

namespace StockTrackingSystem.Business.User.Handlers
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginModel>
    {
        private readonly StockTrackingSystemDbContext _context;

        public LoginHandler(StockTrackingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<LoginModel> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            var loginAttempt = new LoginAttempts
            {
                UserId = user.UserId,
                AttemptTime = DateTime.Now,
                IpAddress = request.IpAddress,
                Success = false
            };

            string hashedInputPassword = PasswordHasher.HashPassword(request.Password);

            if (user.Password == hashedInputPassword)
            {
                loginAttempt.Success = true;

                await _context.LoginAttempts.AddAsync(loginAttempt);
                await _context.SaveChangesAsync();

                return new LoginModel
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Username = user.UserName
                };
            }

            await _context.LoginAttempts.AddAsync(loginAttempt);
            await _context.SaveChangesAsync();

            throw new Exception("Şifre hatalı.");
        }
    }
}
