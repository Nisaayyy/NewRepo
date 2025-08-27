using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingSystem.Business.Products.Models;
using StockTrackingSystem.Business.Products.Requests;

namespace StockTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductGetModel>> Get(int id)
        {
            var result = await _mediator.Send(new ProductGetRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDeleteModel>> Delete(int id)
        {
            var result = await _mediator.Send(new ProductDeleteRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpPost("upsert")]
        public async Task<ActionResult<ProductUpsertModel>> Upsert([FromBody] ProductUpsertRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
