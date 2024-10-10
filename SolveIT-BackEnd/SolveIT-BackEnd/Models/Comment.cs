using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolveIT_BackEnd.Models;

public class Comment : BaseModel
{
    [Required]
    [MaxLength(300)]
    public string Content { get; set; }
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
}
