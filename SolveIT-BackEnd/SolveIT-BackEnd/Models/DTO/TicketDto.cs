using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public record TicketDto(
    int Id,
    TicketPriority Priority,
    TicketSeverity Severity,
    TicketStatus Status,
    string Title,
    string Description,
    Language Language,
    User User,
    DateTime CreatedOn,
    List<CommentDto> Comments);

