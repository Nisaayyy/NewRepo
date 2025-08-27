using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Data.EF.dbo;

public class LoginAttempts
{
    [Key]
    public int LoginId { get; set; }
    public int? UserId { get; set; }
    public DateTime? AttemptTime { get; set; }
    public bool? Success { get; set; }
    public string? IpAddress { get; set; }


}
