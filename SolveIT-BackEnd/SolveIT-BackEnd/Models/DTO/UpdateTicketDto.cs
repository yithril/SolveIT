using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public record UpdateTicketDto(
    [Required]
    TicketPriority Priority,
    [Required]
    TicketSeverity Severity,
    [Required]
    TicketStatus Status,
    [Required]
    TicketType TicketType,
    [Required]
    string Title,
    [Required]
    string Description,
    [Required]
    Language Language,
    int DepartmentId);

