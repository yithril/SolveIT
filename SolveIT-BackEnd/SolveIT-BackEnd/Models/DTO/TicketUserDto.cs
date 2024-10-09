using SolveIT_BackEnd.Enums;

namespace SolveIT_BackEnd.Models.DTO;

public class TicketUserDto
{
    public int TicketId { get; set; }
    public User User { get; set; }
    public TicketUserRole Role { get; set; }
}
