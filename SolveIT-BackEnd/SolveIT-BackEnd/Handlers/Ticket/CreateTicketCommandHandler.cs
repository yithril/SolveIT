using MediatR;
using SolveIT_BackEnd.Commands.Ticket;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Events;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_BackEnd.Handlers.Ticket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketDto>
{
    private readonly AppDbContext _appDbContext;
    private readonly IMediator _mediator;

    public CreateTicketCommandHandler(AppDbContext context, IMediator mediator)
    {
        _appDbContext = context;
        _mediator = mediator;
    }

    public async Task<TicketDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ticket = request.ToEntity();
            ticket.CreatedOn = DateTime.UtcNow;
            ticket.IsActive = true;

            _appDbContext.Add(ticket);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new TicketCreatedEvent(ticket.Id, ticket.DepartmentId), cancellationToken);

            return ticket.ToDto();
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating ticket", ex);
        }
    }
}
