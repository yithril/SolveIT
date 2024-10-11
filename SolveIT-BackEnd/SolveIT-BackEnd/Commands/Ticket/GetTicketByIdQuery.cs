using MediatR;
using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Commands.Ticket;

public class GetTicketByIdQuery : IRequest<TicketDto>
{
    public int Id { get; set; }
}
