using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public record UpdateTicketDto(
    TicketPriority Priority,
    TicketSeverity Severity,
    TicketStatus Status,
    string Title,
    string Description,
    Language Language);

