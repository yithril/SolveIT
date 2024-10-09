using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Models.Mapper;

public static class TicketMapper
{
    public static TicketDto ToDto(this Ticket ticket) => new ()
    {
        Id = ticket.Id,
        Priority = ticket.Priority,
        Severity = ticket.Severity,
        Status = ticket.Status,
        Title = ticket.Title,
        Description = ticket.Description,
        Language = ticket.Language,
        CreatedOn = ticket.CreatedOn,
    };
}
