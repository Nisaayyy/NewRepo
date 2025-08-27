using StockTrackingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Data.EF.dbo;
public class Users: BaseEntity
{

    public  int UserId { get; set; }
    public string? UserName  { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

}
