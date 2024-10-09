using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Models.Mapper;

public static class CommentMapper
{
    public static CommentDto ToDto(this Comment comment) => new()
    {
        Id = comment.Id,
        Content = comment.Content,
        TicketId = comment.TicketId,
        CreatedOn = comment.CreatedOn
    };

    public static Comment FromCreateDto(this CreateCommentDto dto) => new()
    {
        TicketId = dto.TicketId,
        Content = dto.Content
    };

    public static Comment FromUpdateDto(this UpdateCommentDto dto) => new()
    {
        Content = dto.Content,
        Id = dto.Id
    };
}
