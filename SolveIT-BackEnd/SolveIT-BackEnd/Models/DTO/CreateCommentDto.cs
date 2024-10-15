using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public record CreateCommentDto(
    [Required]
    [MaxLength(500)]
    string Content,
    [Required]
    int TicketId);

