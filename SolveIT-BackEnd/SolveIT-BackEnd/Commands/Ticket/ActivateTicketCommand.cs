using MediatR;

namespace SolveIT_BackEnd.Commands.Ticket;

public class ActivateTicketCommand : IRequest<bool>
{
    public int Id { get; set; }
}
