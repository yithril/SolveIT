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
        Comments = ticket.Comments.Select(c => c.ToDto()).ToList()
    };

    public static Ticket FromCreateDto(this CreateTicketDto dto) => new()
    {
        Priority = dto.Priority,
        Severity = dto.Severity,
        Status = dto.Status,
        Title = dto.Title,
        Description = dto.Description,
        Language = dto.Language
    };

    public static Ticket FromUpdateTicketDto(this UpdateTicketDto dto) => new()
    {
        Priority = dto.Priority,
        Severity = dto.Severity,
        Status = dto.Status,
        Title = dto.Title,
        Description = dto.Description,
        Language = dto.Language
    };
}
