using SolveIT_BackEnd.Commands;
using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Models.Mapper;

public static class TicketMapper
{
    public static CreateTicketCommand ToCommand(this CreateTicketDto dto)
    {
        return new CreateTicketCommand
        {
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority,
            Severity = dto.Severity,
            Status = dto.Status,
            Language = dto.Language,
            DepartmentId = dto.DepartmentId
        };
    }

    public static Ticket ToEntity(this CreateTicketCommand command) => new()
    {
        Title = command.Title,
        Description = command.Description,
        Priority = command.Priority,
        Severity = command.Severity,
        Status = command.Status,
        Language = command.Language,
        CreatedById = command.CreatedById
    };

    public static TicketDto ToDto(this Ticket ticket) => new(ticket.Id, ticket.Priority, ticket.Severity, ticket.Status, ticket.Title, ticket.Description, ticket.Language, ticket.CreatedBy, ticket.CreatedOn, ticket.Comments.Select(x => x.ToDto()).ToList());
}
