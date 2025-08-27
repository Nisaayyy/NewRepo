using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Seasons.Models
{
    public class SeasonGetModel
    {
        public int Id { get; set; }
        public string SeasonName { get; set; } = default!;
        public DateTime? CreatedAt { get; set; }   
    }
}

