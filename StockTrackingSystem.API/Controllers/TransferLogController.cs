using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockTrackingSystem.Business.TransferLogs.Models;
using StockTrackingSystem.Business.TransferLogs.Requests;

namespace StockTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransferLogController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TransferLogGetModel>> Get(int id)
        {
            var result = await _mediator.Send(new TransferLogGetRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TransferLogDeleteModel>> Delete(int id)
        {
            var result = await _mediator.Send(new TransferLogDeleteRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpPost("upsert")]
        public async Task<ActionResult<TransferLogUpsertModel>> Upsert([FromBody] TransferLogUpsertRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

