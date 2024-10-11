using SolveIT_BackEnd.Enums;

namespace SolveIT_BackEnd.Models.DTO;

public record TicketDto(
    int Id,
    TicketPriority Priority,
    TicketSeverity Severity,
    TicketStatus Status,
    string Title,
    string Description,
    Language Language,
    int CreatedById,
    DateTime CreatedOn,
    List<CommentDto> Comments,
    int DepartmentId);

