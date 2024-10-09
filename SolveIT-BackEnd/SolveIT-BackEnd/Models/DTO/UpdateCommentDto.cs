using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public class UpdateCommentDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string Content { get; set; }
}
