using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public class CommentDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string Content { get; set; }
    public int TicketId { get; set; }
    public User User { get; set; }
    public DateTime CreatedOn { get; set; }
}
