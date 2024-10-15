using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolveIT_BackEnd.Commands.Ticket;
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

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllTickets([FromQuery] GetAllTicketsQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetTicketById(int id)
    {
        var result = await _mediator.Send(new GetTicketByIdQuery()
        {
            Id = id
        });

        if(result == null)
        {
            return NotFound();
        }

        return Ok(result);
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

    [HttpPatch("{id}/deactivate")]
    [Authorize]
    public async Task<IActionResult> DeactivateTicket(int id)
    {
        var result = await _mediator.Send(new DeactivateTicketCommand()
        {
            Id = id
        });

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPatch("{id}/activate")]
    public async Task<IActionResult> ActivateTicket(int id)
    {
        var result = await _mediator.Send(new ActivateTicketCommand()
        {
            Id = id
        });

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket([FromBody] UpdateTicketDto dto, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(dto.ToCommand());

        if(result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
