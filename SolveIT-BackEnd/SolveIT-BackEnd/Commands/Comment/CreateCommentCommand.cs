namespace SolveIT_BackEnd.Commands.Comment;

public class CreateCommentCommand
{
    public string Content { get; set; }
    public int TicketId { get; set; }
}
