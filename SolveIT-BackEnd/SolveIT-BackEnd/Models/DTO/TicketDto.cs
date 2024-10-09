using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public class TicketDto
{
    public int Id { get; set; }

    [Required]
    public TicketPriority Priority { get; set; }

    [Required]
    public TicketSeverity Severity { get; set; }

    [Required]
    public TicketStatus Status { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(750)]
    public string Description { get; set; }

    [Required]
    public Language Language { get; set; }
    public User User { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
}
