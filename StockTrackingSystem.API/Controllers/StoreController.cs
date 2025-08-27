using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingSystem.Business.Stores.Models;
using StockTrackingSystem.Business.Stores.Requests;

namespace StockTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StoreGetModel>> Get(int id)
        {
            var result = await _mediator.Send(new StoreGetRequest { Id = id });
            if (result == null)
                return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<StoreDeleteModel>> Delete(int id)
        {
            var result = await _mediator.Send(new StoreDeleteRequest { Id = id });
            if (result == null)
                return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpPost("upsert")]
        public async Task<ActionResult<StoreUpsertModel>> Upsert([FromBody] StoreUpsertRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}