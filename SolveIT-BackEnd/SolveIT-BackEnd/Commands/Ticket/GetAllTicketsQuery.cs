using MediatR;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Commands.Ticket;

public class GetAllTicketsQuery : IRequest<List<TicketDto>>
{
    int? DepartmentId { get; set; }
    TicketPriority? Priority { get; set; }
    TicketSeverity? Severity { get; set; }
    TicketStatus? Status { get; set; }
    string? Title { get; set; }
    Language? Language { get; set; }
}
