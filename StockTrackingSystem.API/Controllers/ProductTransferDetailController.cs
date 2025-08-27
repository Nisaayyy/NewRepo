using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingSystem.Business.ProductTransferDetails.Models;
using StockTrackingSystem.Business.ProductTransferDetails.Requests;

namespace StockTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTransferDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductTransferDetailController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductTransferDetailGetModel>> Get(int id)
        {
            var result = await _mediator.Send(new ProductTransferDetailGetRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductTransferDetailDeleteModel>> Delete(int id)
        {
            var result = await _mediator.Send(new ProductTransferDetailDeleteRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpPost("upsert")]
        public async Task<ActionResult<ProductTransferDetailUpsertModel>> Upsert([FromBody] ProductTransferDetailUpsertRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
