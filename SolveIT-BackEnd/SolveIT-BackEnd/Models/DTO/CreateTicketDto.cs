using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public record CreateTicketDto(
    [Required]
    TicketPriority Priority,
    [Required]
    TicketSeverity Severity,
    [Required]
    [MaxLength(50)]
    string Title,
    [Required]
    [MaxLength(750)]
    string Description,
    [Required]
    Language Language,
    [Required]
    int DepartmentId);
