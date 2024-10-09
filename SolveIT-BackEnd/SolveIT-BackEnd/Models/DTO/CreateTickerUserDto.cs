using SolveIT_BackEnd.Enums;

namespace SolveIT_BackEnd.Models.DTO;

public class CreateTickerUserDto
{
    public int TicketId { get; set; }
    public int UserId { get; set; }
    public TicketUserRole Role { get; set; }
}
