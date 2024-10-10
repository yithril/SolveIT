using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public record CreateCommentDto(
    string Content,
    int TicketId);

