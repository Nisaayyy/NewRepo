using MediatR;
using StockTrackingSystem.Business.Seasons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Seasons.Requests
{
    public class SeasonDeleteRequest : IRequest<SeasonDeleteModel?>
    {
        public int Id { get; set; }
    }
}
