using MediatR;
using StockTrackingSystem.Business.Stores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Stores.Requests
{
    public class StoreDeleteRequest : IRequest<StoreDeleteModel?>
    {
        public int Id { get; set; }
    }
}