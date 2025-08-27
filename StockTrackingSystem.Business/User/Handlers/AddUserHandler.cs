using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.User.Models;
using StockTrackingSystem.Business.User.Requests;
using StockTrackingSystem.Business.Utils;
using StockTrackingSystem.Data.EF;
using StockTrackingSystem.Data.EF.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.User.Handlers
{
    public class AddUserHandler: IRequestHandler<AddUserRequest,AddUserModel>
    {
        private readonly StockTrackingSystemDbContext _context;
        public AddUserHandler(StockTrackingSystemDbContext context)

        {
              _context = context;
        }

        public async Task<AddUserModel> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (existingUser != null)
                throw new Exception("Bu e-posta adresiyle zaten bir kullanıcı kayıtlı!"); 

            if (request.Password1 != request.Password2)
                throw new Exception("Girilen şifreler uyuşmuyor!");


            var hashedPassword = PasswordHasher.HashPassword(request.Password1);  

            var newUser = new Users
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = hashedPassword,
                IsActive = true,
                CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,      
                    TimeZoneInfo.FindSystemTimeZoneById("Türkiye Standart Saati"))
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddUserModel
            {
                UserId = newUser.UserId,
                IsSuccess = true
            };
        }


    }
}
