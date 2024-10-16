using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Models;
using SolveIT_UnitTesting.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveIT_UnitTesting.Domain.Tickets;

[TestFixture]
public class TicketStateTests
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
    public async Task TicketIsOpen_StartWork_TicketIsInProgress()
    {
        await LoadBasicTickets();

        var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == 1);

        Assert.That(ticket, Is.Not.Null);

        ticket.ChangeStatus(TicketTrigger.StartWork);

        Assert.That(ticket.Status, Is.EqualTo(TicketStatus.InProgress));
    }

    [Test]
    public async Task TicketIsOpen_HoldTicket_NoChangeInState()
    {
        await LoadBasicTickets();

        var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == 1);

        Assert.That(ticket, Is.Not.Null);
        Assert.That(ticket.Status, Is.EqualTo(TicketStatus.Open));

        Assert.Throws<InvalidOperationException>(() => ticket.ChangeStatus(TicketTrigger.Hold));
    }

    private async Task LoadBasicTickets(bool IsActive = true)
    {
        var department = new Department()
        {
            Name = "IT"
        };

        var department2 = new Department()
        {
            Name = "Human Resources"
        };

        _context.Departments.Add(department);
        _context.Departments.Add(department2);

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
            TicketType = TicketType.ITSupport,
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
