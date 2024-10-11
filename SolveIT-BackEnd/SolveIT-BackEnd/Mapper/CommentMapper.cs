using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Models.Mapper;

public static class CommentMapper
{
    public static CommentDto ToDto(this Comment comment) => new(comment.Id, comment.Content, comment.TicketId, comment.CreatedById, comment.CreatedOn);
}
