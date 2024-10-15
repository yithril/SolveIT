using SolveIT_BackEnd.Enums;

namespace SolveIT_BackEnd.Models.DTO;

public record TicketDto(
    int Id,
    TicketPriority Priority,
    TicketSeverity Severity,
    TicketStatus Status,
    TicketType TicketType,
    string Title,
    string Description,
    Language Language,
    int CreatedById,
    DateTime CreatedOn,
    List<CommentDto> Comments,
    List<TicketUserDto> TicketUsers,
    int DepartmentId);

