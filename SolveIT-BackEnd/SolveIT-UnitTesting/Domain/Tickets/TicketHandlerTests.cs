using SolveIT_BackEnd.Commands.Ticket;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Handlers;
using SolveIT_BackEnd.Models;
using SolveIT_UnitTesting.Config;

namespace SolveIT_UnitTesting.Domain.Tickets;

[TestFixture]
public class TicketHandlerTests
{
    private readonly InMemoryDatabaseSetup _setup;

    public TicketHandlerTests()
    {
        _setup = new InMemoryDatabaseSetup();
    }

    [Test]
    public async Task ValidDepartment_ValidUser_TicketCreationSuccessfull()
    {
        using (var context = _setup.GetDbContext())
        {
            context.Departments.Add(new Department()
            {
                Id = 1,
                Name = "IT",
                Address = "Somewhere",
                City = "Smallville"
            });

            context.Users.Add(new User()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Auth0Id = "auth0|123",
                Email = "somewhere@email.com",
                PhoneNumber = "1234567890"
            });

            await context.SaveChangesAsync();

            var handler = new CreateTicketCommandHandler(context);

            CreateTicketCommand command = new()
            {
                Title = "Test Ticket",
                Description = "Test Description",
                Priority = TicketPriority.High,
                Status = TicketStatus.Open,
                Severity= TicketSeverity.Critical,
                Language = Language.English,
                DepartmentId = 1,
                CreatedById = 1
            };

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.EqualTo(TicketStatus.Open));
            Assert.That(result.Title, Is.EqualTo("Test Ticket"));
            Assert.That(result.Description, Is.EqualTo("Test Description"));
            Assert.That(result.Priority, Is.EqualTo(TicketPriority.High));
            Assert.That(result.Severity, Is.EqualTo(TicketSeverity.Critical));
            Assert.That(result.Language, Is.EqualTo(Language.English));
            Assert.That(result.Comments.Count, Is.EqualTo(0));
        }

    }
}
