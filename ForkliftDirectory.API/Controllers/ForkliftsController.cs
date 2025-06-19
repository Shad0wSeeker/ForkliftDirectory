using ForkliftDirectory.Application.CQRS.Forklifts.Commands.CreateForkliftCommand;
using ForkliftDirectory.Application.CQRS.Forklifts.Commands.DeleteForkliftCommand;
using ForkliftDirectory.Application.CQRS.Forklifts.Commands.UpdateForkliftCommand;
using ForkliftDirectory.Application.CQRS.Forklifts.Queries.GetAllForkliftsQuery;
using ForkliftDirectory.Application.CQRS.Forklifts.Queries.GetForkliftByIdQuery;
using ForkliftDirectory.Application.CQRS.Forklifts.Queries.SearchByNumberQuery;
using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForkliftDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForkliftsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForkliftsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForklifts(CancellationToken cancellationToken)
        {
            var query = new GetAllForkliftsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForkliftById(int id, CancellationToken cancellationToken)
        {
            var query = new GetForkliftByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByNumber([FromQuery] string? number, CancellationToken cancellationToken)
        {
            var query = new SearchByNumberQuery(number);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateForklift([FromBody] CreateForkliftDto createForkliftDto, CancellationToken cancellationToken)
        {
            var command = new CreateForkliftCommand(createForkliftDto);
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetForkliftById), new { id = result}, result);  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForklift(int id, [FromBody] UpdateForkliftDto updateForkliftDto, CancellationToken cancellationToken)
        {
            var command = new UpdateForkliftCommand(id, updateForkliftDto);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForklift(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteForkliftCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new { message = "Погрузчик удален успешно" });
        }
    }
}
