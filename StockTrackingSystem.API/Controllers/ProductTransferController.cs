using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingSystem.Business.ProductTransfers.Models;
using StockTrackingSystem.Business.ProductTransfers.Requests;

namespace StockTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTransferController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductTransferController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductTransferGetModel>> Get(int id)
        {
            var result = await _mediator.Send(new ProductTransferGetRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductTransferDeleteModel>> Delete(int id)
        {
            var result = await _mediator.Send(new ProductTransferDeleteRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpPost("upsert")]
        public async Task<ActionResult<ProductTransferUpsertModel>> Upsert([FromBody] ProductTransferUpsertRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
