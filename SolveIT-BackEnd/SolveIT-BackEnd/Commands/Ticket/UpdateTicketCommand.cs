using MediatR;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Commands.Ticket;

public class UpdateTicketCommand : IRequest<TicketDto>
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public TicketPriority Priority { get; set; }
    public TicketSeverity Severity { get; set; }
    public TicketStatus Status { get; set; }
    public Language Language { get; set; }
    public int DepartmentId { get; set; }
    public int UpdatedById { get; set; }
}
