using MediatR;
using SolveIT_BackEnd.Events;

namespace SolveIT_BackEnd.Handlers.Ticket;

public class AssignUsersToTicketHandler : INotificationHandler<TicketCreatedEvent>
{
    public Task Handle(TicketCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
