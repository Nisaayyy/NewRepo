using MediatR;
using StockTrackingSystem.Business.User.Models;

namespace StockTrackingSystem.Business.User.Requests
{
    public class UpdateRequest : IRequest<UpdateModel>
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

