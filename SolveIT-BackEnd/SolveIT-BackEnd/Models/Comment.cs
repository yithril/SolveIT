using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models;

public class Comment : BaseModel
{
    [Required]
    [MaxLength(300)]
    public string Content { get; set; }
    public Ticket Ticket { get; set; }
}
