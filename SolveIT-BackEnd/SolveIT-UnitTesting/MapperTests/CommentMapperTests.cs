using SolveIT_BackEnd.Models;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_UnitTesting.MapperTests;

[TestFixture]
public class CommentMapperTests
{
    [Test]
    public void Comment_ToDto_Succeeds()
    {
        Comment comment = new Comment()
        {
            Id = 1,
            Content = "Test Content",
            TicketId = 1
        };

        var result = comment.ToDto();

        Assert.That(result.Id, Is.EqualTo(1));
        Assert.That(result.Content, Is.EqualTo("Test Content"));
        Assert.That(result.TicketId, Is.EqualTo(1));
    }

    [Test]
    public void CreateComment_ToComment_Succeeds()
    {
        CreateCommentDto dto = new CreateCommentDto()
        {
            TicketId = 1,
            Content = "Test Content"
        };

        var result = dto.FromCreateDto();

        Assert.That(result.TicketId, Is.EqualTo(1));
        Assert.That(result.Content, Is.EqualTo("Test Content"));
    }

    [Test]
    public void UpdateComment_ToComment_Succeeds()
    {
        UpdateCommentDto dto = new UpdateCommentDto()
        {
            Id = 1,
            Content = "Test Content"
        };

        var result = dto.FromUpdateDto();

        Assert.That(result.Id, Is.EqualTo(1));
        Assert.That(result.Content, Is.EqualTo("Test Content"));
    }
}
