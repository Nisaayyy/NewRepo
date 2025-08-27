using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingSystem.Business.Seasons.Models;
using StockTrackingSystem.Business.Seasons.Requests;

namespace StockTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SeasonController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SeasonGetModel>> Get(int id)
        {
            var result = await _mediator.Send(new SeasonGetRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SeasonDeleteModel>> Delete(int id)
        {
            var result = await _mediator.Send(new SeasonDeleteRequest { Id = id });
            if (result is null) return NotFound($"Id {id} için kayıt bulunamadı.");
            return Ok(result);
        }

        [HttpPost("upsert")]
        public async Task<ActionResult<SeasonUpsertModel>> Upsert([FromBody] SeasonUpsertRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}