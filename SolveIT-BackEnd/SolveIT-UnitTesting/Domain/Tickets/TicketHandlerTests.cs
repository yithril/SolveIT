using SolveIT_BackEnd.Commands.Ticket;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Handlers.Ticket;
using SolveIT_BackEnd.Models;
using SolveIT_UnitTesting.Config;

namespace SolveIT_UnitTesting.Domain.Tickets;

[TestFixture]
public class TicketHandlerTests
{
    private InMemoryDatabaseSetup _setup;
    private AppDbContext _context;

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        _setup = new InMemoryDatabaseSetup();
    }

    [SetUp]
    public void Setup()
    {
        _context = _setup.GetDbContext();
    }

    [TearDown]
    public void Cleanup()
    {
        if (_context != null)
        {
            _context.Database.EnsureDeleted(); 
            _context.Dispose();
        }
    }

    [Test]
    public async Task ValidDepartment_ValidUser_TicketCreationSuccessfull()
    {
        await LoadBasicTickets();

        CreateTicketCommand command = new()
        {
            Title = "Test Ticket",
            Description = "Test Description",
            Priority = TicketPriority.High,
            Status = TicketStatus.Open,
            Severity = TicketSeverity.Critical,
            Language = Language.English,
            DepartmentId = 1,
            CreatedById = 1
        };

        var handler = new CreateTicketCommandHandler(_context);
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

    [Test]
    public async Task NoQueryParams_ReturnsAllTickets()
    {
        await LoadBasicTickets();

        var handler = new GetTicketCommandHandler(_context);

        var result = await handler.Handle(new GetAllTicketsQuery(), CancellationToken.None);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Id, Is.EqualTo(1));
        Assert.That(result[0].Comments.Count, Is.EqualTo(1));
        Assert.That(result[0].TicketUsers.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task GetTicketById_Succeeds()
    {
        await LoadBasicTickets();

        var handler = new GetTicketByIdHandler(_context);

        var result = await handler.Handle(new GetTicketByIdQuery() { Id = 1 }, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1));
        Assert.That(result.Status, Is.EqualTo(TicketStatus.Open));
        Assert.That(result.Language, Is.EqualTo(Language.English));
        Assert.That(result.Severity, Is.EqualTo(TicketSeverity.Critical));
    }

    [Test]
    public async Task GetTicketById_NoTicket_ReturnsNull()
    {
        var handler = new GetTicketByIdHandler(_context);

        var result = await handler.Handle(new GetTicketByIdQuery() { Id = 100 }, CancellationToken.None);

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task DeactivateTicket_Succeeds()
    {
        await LoadBasicTickets();

        var ticket = await _context.Tickets.FindAsync(1);

        Assert.That(ticket, Is.Not.Null);

        var handler = new DeactivateTicketHandler(_context);

        var result = await handler.Handle(new DeactivateTicketCommand()
        {
            Id = ticket.Id
        }, CancellationToken.None);

        Assert.That(result, Is.True);

        ticket = await _context.Tickets.FindAsync(ticket.Id);

        Assert.That(ticket, Is.Not.Null);
        Assert.That(ticket.IsActive, Is.False);
    }

    [Test]
    public async Task ActivateTicket_Succeeds()
    {
        await LoadBasicTickets(false);

        var ticket = await _context.Tickets.FindAsync(1);

        Assert.That(ticket, Is.Not.Null);
        Assert.That(ticket.IsActive, Is.False);

        var handler = new ActivateTicketHandler(_context);
        var result = await handler.Handle(new ActivateTicketCommand()
        {
            Id = ticket.Id
        }, CancellationToken.None);

        ticket = await _context.Tickets.FindAsync(1);

        Assert.That(result, Is.True);
        Assert.That(ticket, Is.Not.Null);
        Assert.That(ticket.IsActive, Is.True);
    }

    private async Task LoadBasicTickets(bool IsActive = true)
    {
        var department = new Department()
        {
            Name = "IT",
            Address = "Somewhere",
            City = "Smallville"
        };

        _context.Departments.Add(department);

        var user = new User()
        {
            FirstName = "John",
            LastName = "Doe",
            Auth0Id = "auth0|123",
            Email = "somewhere@email.com",
            PhoneNumber = "1234567890"
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        Ticket ticket = new()
        {
            CreatedById = user.Id,
            IsActive = IsActive,
            Severity = TicketSeverity.Critical,
            Priority = TicketPriority.High,
            Language = Language.English,
            Status = TicketStatus.Open,
            Title = "Test",
            Description = "Test",
            DepartmentId = 1
        };

        _context.Add(ticket);

        await _context.SaveChangesAsync();

        TicketUser ticketUser = new()
        {
            IsActive = true,
            Role = TicketUserRole.Support,
            TicketId = ticket.Id
        };

        Comment comment = new()
        {
            Content = "Test Comment",
            TicketId = ticket.Id
        };

        _context.Add(comment);
        _context.Add(ticketUser);

        await _context.SaveChangesAsync();
    }
}
