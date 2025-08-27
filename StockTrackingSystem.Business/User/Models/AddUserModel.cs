using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.User.Models;

public class AddUserModel
{
    public int? UserId { get; set; } 
    public bool IsSuccess { get; set; } 
}
