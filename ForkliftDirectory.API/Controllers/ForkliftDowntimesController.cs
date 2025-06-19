using ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.CreateForkliftDowntimeCommand;
using ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.DeleteForkliftDowntimeCommand;
using ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.UpdateForkliftDowntimeCommand;
using ForkliftDirectory.Application.CQRS.ForkliftDowntime.Queries.GetDowntimesByForkliftIdQuery;
using ForkliftDirectory.Application.CQRS.ForkliftDowntime.Queries.GetForkliftDowntimeByIdQuery;
using ForkliftDirectory.Application.CQRS.Forklifts.Queries.GetForkliftByIdQuery;
using ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForkliftDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForkliftDowntimesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ForkliftDowntimesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{forkliftId}")]
        public async Task<IActionResult> GetDowntimesByForkliftId(int forkliftId, CancellationToken cancellationToken)
        {
            var query = new GetDowntimesByForkliftIdQuery(forkliftId);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("forkliftDowntime/{id}")]
        public async Task<IActionResult> GetForkliftDowntimeById(int id, CancellationToken cancellationToken)
        {
            var query = new GetForkliftDowntimeByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateDowntime([FromBody] CreateForkliftDowntimeDto dto, CancellationToken cancellationToken)
        {
            var command = new CreateForkliftDowntimeCommand(dto);
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetForkliftDowntimeById), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDowntime(int id, [FromBody] UpdateForkliftDowntimeDto dto, CancellationToken cancellationToken)
        {
            var command = new UpdateForkliftDowntimeCommand(id, dto);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDowntime(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteForkliftDowntimeCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new { message = "Простой удалён успешно" });
        }
    }
}
