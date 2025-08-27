using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingSystem.Business.ProductInventory.Models;
using StockTrackingSystem.Business.ProductInventory.Requests;

namespace StockTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductInventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductInventoryGetModel>> Get(int id)
        {
            var result = await _mediator.Send(new ProductInventoryGetRequest { Id = id });
            if (result == null)
                return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductInventoryDeleteModel>> Delete(int id)
        {
            var result = await _mediator.Send(new ProductInventoryDeleteRequest { Id = id });
            if (result == null)
                return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpPost("upsert")]
        public async Task<ActionResult<ProductInventoryUpsertModel>> Upsert([FromBody] ProductInventoryUpsertRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
