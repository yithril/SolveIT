using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models.DTO;

public record UpdateCommentDto(
    int Id,
    string Content);

