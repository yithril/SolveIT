using MediatR;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Commands.Ticket;

public class GetAllTicketsQuery : IRequest<List<TicketDto>>
{
    public int? DepartmentId { get; set; }
    public TicketPriority? Priority { get; set; }
    public TicketSeverity? Severity { get; set; }
    public TicketStatus? Status { get; set; }
    public string? Title { get; set; }
    public Language? Language { get; set; }
    public bool IsActive { get; set; } = true;
}
