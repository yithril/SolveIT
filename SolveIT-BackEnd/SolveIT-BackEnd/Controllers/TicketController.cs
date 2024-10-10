using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ApiBaseController
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto dto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = GetCurrentUser();

        if (user == null)
        {
            return NotFound();
        }

        var command = dto.ToCommand();
        command.CreatedById = user.Id;

        var ticketDto = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetTicketById), new { id = ticketDto.Id }, ticketDto);
    }

    [HttpGet("{id}")]
    public IActionResult GetTicketById(int id)
    {
        return Ok();
    }
}
