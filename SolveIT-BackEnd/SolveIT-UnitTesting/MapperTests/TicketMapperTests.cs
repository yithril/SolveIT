using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Models;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_UnitTesting.MapperTests;

[TestFixture]
public class TicketMapperTests
{
    [Test]
    public void ToDto_ShouldMapTicketToTicketDto_WithComments()
    {
        var ticket = new Ticket
        {
            Id = 1,
            Priority = TicketPriority.High,
            Severity = TicketSeverity.Critical,
            Status = TicketStatus.Open,
            Title = "Sample Ticket",
            Description = "This is a sample ticket.",
            Language = Language.English,
            CreatedOn = new DateTime(2023, 10, 1),
            Comments = new List<Comment>
            {
                new Comment
                {
                    Content = "First comment",
                    CreatedOn = new DateTime(2023, 10, 2)
                },
                new Comment
                {
                    Content = "Second comment",
                    CreatedOn = new DateTime(2023, 10, 3)
                }
            }
        };

        var ticketDto = ticket.ToDto();

        Assert.That(ticketDto.Id, Is.EqualTo(1));
        Assert.That(ticketDto.Priority, Is.EqualTo(TicketPriority.High));
        Assert.That(ticketDto.Severity, Is.EqualTo(TicketSeverity.Critical));
        Assert.That(ticketDto.Status, Is.EqualTo(TicketStatus.Open));
        Assert.That(ticketDto.Title, Is.EqualTo("Sample Ticket"));
        Assert.That(ticketDto.Description, Is.EqualTo("This is a sample ticket."));
        Assert.That(ticketDto.Language, Is.EqualTo(Language.English));
        Assert.That(ticketDto.CreatedOn, Is.EqualTo(new DateTime(2023, 10, 1)));

        Assert.That(ticketDto.Comments.Count, Is.EqualTo(2));
        Assert.That(ticketDto.Comments[0].Content, Is.EqualTo("First comment"));
        Assert.That(ticketDto.Comments[0].CreatedOn, Is.EqualTo(new DateTime(2023, 10, 2)));

        Assert.That(ticketDto.Comments[1].Content, Is.EqualTo("Second comment"));
        Assert.That(ticketDto.Comments[1].CreatedOn, Is.EqualTo(new DateTime(2023, 10, 3)));
    }

    [Test]
    public void FromCreateDto_ShouldMapCreateTicketDtoToTicket()
    {
        var createDto = new CreateTicketDto
        {
            Priority = TicketPriority.Medium,
            Severity = TicketSeverity.Major,
            Status = TicketStatus.In_Progress,
            Title = "New Ticket",
            Description = "Creating a new ticket.",
            Language = Language.Spanish
        };

        var ticket = createDto.FromCreateDto();

        Assert.That(ticket.Priority, Is.EqualTo(TicketPriority.Medium));
        Assert.That(ticket.Severity, Is.EqualTo(TicketSeverity.Major));
        Assert.That(ticket.Status, Is.EqualTo(TicketStatus.In_Progress));
        Assert.That(ticket.Title, Is.EqualTo("New Ticket"));
        Assert.That(ticket.Description, Is.EqualTo("Creating a new ticket."));
        Assert.That(ticket.Language, Is.EqualTo(Language.Spanish));
        Assert.That(ticket.Comments, Is.Empty); 
    }

    [Test]
    public void FromUpdateTicketDto_ShouldMapUpdateTicketDtoToTicket()
    {
        var updateDto = new UpdateTicketDto
        {
            Priority = TicketPriority.Low,
            Severity = TicketSeverity.Minor,
            Status = TicketStatus.Closed,
            Title = "Updated Ticket",
            Description = "This ticket has been updated.",
            Language = Language.French
        };

        var ticket = updateDto.FromUpdateTicketDto();

        Assert.That(ticket.Priority, Is.EqualTo(TicketPriority.Low));
        Assert.That(ticket.Severity, Is.EqualTo(TicketSeverity.Minor));
        Assert.That(ticket.Status, Is.EqualTo(TicketStatus.Closed));
        Assert.That(ticket.Title, Is.EqualTo("Updated Ticket"));
        Assert.That(ticket.Description, Is.EqualTo("This ticket has been updated."));
        Assert.That(ticket.Language, Is.EqualTo(Language.French));

        Assert.That(ticket.Comments, Is.Empty); 
    }
}
