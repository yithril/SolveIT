using SolveIT_BackEnd.Commands.Comment;
using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Models.Mapper;

public static class CommentMapper
{
    public static CommentDto ToDto(this Comment comment) => new(comment.Id, comment.Content, comment.TicketId, comment.CreatedById, comment.CreatedOn);

    public static CreateCommentCommand ToCommand(this CreateCommentDto dto) => new()
    {
        Content = dto.Content,
        TicketId = dto.TicketId
    };

    public static Comment ToEntity(this CreateCommentCommand command) => new()
    {
        Content = command.Content,
        TicketId = command.TicketId
    };
}
