using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public record CommentDto(
    int Id,
    string Content,
    int TicketId,
    User User,
    DateTime CreatedOn);
