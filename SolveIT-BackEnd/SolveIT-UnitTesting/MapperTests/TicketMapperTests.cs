using SolveIT_BackEnd.Commands;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Models;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_UnitTesting.MapperTests;

[TestFixture]
public class TicketMapperTests
{
    [Test]
    public void CreateTicketDto_ToCommand_Succeeds()
    {
        CreateTicketDto dto = new(TicketPriority.Low, TicketSeverity.Major, TicketStatus.Open, "Test", "Test Description", Language.English, 1);

        var result = dto.ToCommand();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Priority, Is.EqualTo(TicketPriority.Low));
        Assert.That(result.Severity, Is.EqualTo(TicketSeverity.Major));
        Assert.That(result.Status, Is.EqualTo(TicketStatus.Open));
        Assert.That(result.Title, Is.EqualTo("Test"));
        Assert.That(result.Description, Is.EqualTo("Test Description"));
        Assert.That(result.Language, Is.EqualTo(Language.English));
        Assert.That(result.DepartmentId, Is.EqualTo(1));
    }

    [Test]
    public void Command_ToTicket_Succeeds()
    {
        CreateTicketCommand command = new CreateTicketCommand()
        {
            Title = "Test",
            Description = "Test Description",
            Priority = TicketPriority.Low,
            Severity = TicketSeverity.Major,
            Status = TicketStatus.Open,
            Language = Language.English,
            DepartmentId = 1,
            CreatedById = 1
        };

        var result = command.ToEntity();

        Assert.That(result.Title.Equals("Test"), Is.True);
        Assert.That(result.Description, Is.EqualTo("Test Description"));
        Assert.That(result.Priority, Is.EqualTo(TicketPriority.Low));
        Assert.That(result.Severity, Is.EqualTo(TicketSeverity.Major));
        Assert.That(result.Status, Is.EqualTo(TicketStatus.Open));
        Assert.That(result.Language.Equals(Language.English));
        Assert.That(result.CreatedById, Is.EqualTo(1));
    }

    [Test]
    public void Ticket_ToTicketDTO_Succeeds()
    {

    }
}
