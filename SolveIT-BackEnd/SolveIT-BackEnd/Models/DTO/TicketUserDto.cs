using SolveIT_BackEnd.Enums;

namespace SolveIT_BackEnd.Models.DTO;

public record TicketUserDto(
    int TicketId,
    User User,
    TicketUserRole Role);

