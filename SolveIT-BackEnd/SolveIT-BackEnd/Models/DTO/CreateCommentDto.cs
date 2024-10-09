using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public class CreateCommentDto
{
    [Required]
    [MaxLength(300)]
    public string Content { get; set; }
    public int TicketId { get; set; }
}
