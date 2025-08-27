using MediatR;
using StockTrackingSystem.Business.Categories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Business.Categories.Requests
{
    public class CategoryDeleteRequest : IRequest<CategoryDeleteModel?>
    {
        public int Id { get; set; }
    }
}
