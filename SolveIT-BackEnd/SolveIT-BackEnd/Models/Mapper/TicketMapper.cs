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

    };

}
