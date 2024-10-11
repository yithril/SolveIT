using MediatR;

namespace SolveIT_BackEnd.Commands.Ticket;

public class DeactivateTicketCommand : IRequest
{
    public int Id { get; set; }
}
