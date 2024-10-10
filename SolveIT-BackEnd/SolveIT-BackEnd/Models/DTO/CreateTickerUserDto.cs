using SolveIT_BackEnd.Enums;

namespace SolveIT_BackEnd.Models.DTO;

public record CreateTicketUserDto(
    int TicketId,
    int UserId,
    TicketUserRole Role);
