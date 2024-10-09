using SolveIT_BackEnd.Enums;

namespace SolveIT_BackEnd.Models;

public class TicketUser : BaseModel
{
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public TicketUserRole Role { get; set; }
}
