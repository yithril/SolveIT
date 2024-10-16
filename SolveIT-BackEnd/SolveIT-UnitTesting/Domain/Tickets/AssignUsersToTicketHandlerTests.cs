using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Events;
using SolveIT_BackEnd.Handlers.Ticket;
using SolveIT_BackEnd.Models;
using SolveIT_UnitTesting.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveIT_UnitTesting.Domain.Tickets;

[TestFixture]
public class AssignUsersToTicketHandlerTests
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
    public async Task TicketIsCreated_LowPriority_DifferentDepartment_AssignToLowestPerson()
    {
        await BuildExample();

        var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == 1);

        Assert.That(ticket, Is.Not.Null);
        Assert.That(ticket.Status, Is.EqualTo(TicketStatus.Open));
        Assert.That(ticket.Priority, Is.EqualTo(TicketPriority.Low));
        Assert.That(ticket.Severity, Is.EqualTo(TicketSeverity.Minor));
        Assert.That(ticket.TicketUsers.Count, Is.EqualTo(0));

        TicketCreatedEvent ticketCreatedEvent = new TicketCreatedEvent(1, 1);

        var handler = new AssignUsersToTicketHandler();

        await handler.Handle(ticketCreatedEvent, CancellationToken.None);

        ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == 1);

        Assert.That(ticket, Is.Not.Null);
        Assert.That(ticket.Status, Is.EqualTo(TicketStatus.Open));
        Assert.That(ticket.Priority, Is.EqualTo(TicketPriority.Low));
        Assert.That(ticket.Severity, Is.EqualTo(TicketSeverity.Minor));
        Assert.That(ticket.TicketUsers.Count, Is.EqualTo(1));

        var assignedEmployee = ticket.TicketUsers[0].User;

        Assert.That(assignedEmployee.FirstName, Is.EqualTo("Sansa"));
        Assert.That(assignedEmployee.LastName, Is.EqualTo("Stark"));
        Assert.That(assignedEmployee.Email, Is.EqualTo("Winterfell@reallycold.com"));
    }

    //Make a test so that when a user submits a ticket, it cannot be assigned to them
    //to do work on it

    private async Task BuildExample()
    {
        Location location = new Location()
        {
            Country = SolveIT_BackEnd.Enums.CompanyCountry.USA,
            Address = "123",
            City = "Wherever",
            Name = "Dallas"
        };

        _context.Add(location);
        await _context.SaveChangesAsync();

        Department department = new Department()
        {
            Name = "IT",
            LocationId = location.Id,
        };

        Department humanResources = new Department()
        {
            Name = "Human Resources",
            LocationId = location.Id
        };

        _context.Add(department);
        _context.Add(humanResources);
        await _context.SaveChangesAsync();

        UserRole newbRole = new UserRole()
        {
            Name = "IT Grunt",
            Description = "Do what we don't want to do."
        };

        UserRole newbBoss = new UserRole()
        {
            Name = "IT Guru",
            Description = "Ascended to a higher plane"
        };

        UserRole hrNewb = new UserRole()
        {
            Name = "HR Newb",
            Description = "Makes org charts all day"
        };

        _context.Add(newbBoss);
        _context.Add(newbRole);
        _context.Add(hrNewb);

        await _context.SaveChangesAsync();

        //ticket submitter
        var user = new User()
        {
            FirstName = "John",
            LastName = "Doe",
            Auth0Id = "auth0|123",
            Email = "somewhere@email.com",
            PhoneNumber = "1234567890",
            DepartmentId = humanResources.Id,
            UserRoleId = hrNewb.Id
        };

        var employeeOne = new User()
        {
            FirstName = "John",
            LastName = "Snow",
            Auth0Id = "whatever",
            Email = "WhiteWalkers@NorthKingdom.com",
            PhoneNumber = "1234567890",
            DepartmentId = department.Id,
            UserRoleId = newbBoss.Id
        };

        _context.Add(user);
        _context.Add(employeeOne);

        await _context.SaveChangesAsync();

        var employeeTwo = new User()
        {
            FirstName = "Sansa",
            LastName = "Stark",
            Auth0Id = "whatever2",
            Email = "Winterfell@reallycold.com",
            PhoneNumber = "1234567890",
            DepartmentId = department.Id,
            ReportsToId = employeeOne.Id,
            UserRoleId = newbRole.Id
        };

        _context.Add(employeeTwo);
        await _context.SaveChangesAsync();

        Ticket ticket = new Ticket()
        {
            Priority = TicketPriority.Low,
            Severity = TicketSeverity.Minor,
            Language = Language.German,
            Status = TicketStatus.Open,
            TicketType = TicketType.ITSupport,
            Title = "Omg everything is on fire",
            Description = "Didn't you read the title???!!!",
            DepartmentId = department.Id
        };

        _context.Add(ticket);
        await _context.SaveChangesAsync();

        //Escalation chain
        TicketEscalationRule ticketEscalationRuleStepOne = new TicketEscalationRule()
        {
            DepartmentId = department.Id,
            StartingUserRoleId = newbRole.Id,
            NextUserRoleId = newbBoss.Id,
            TicketType = TicketType.ITSupport,
            IsFinalLevel = false
        };

        TicketEscalationRule ticketEscalationRuleStepTwo = new TicketEscalationRule()
        {
            DepartmentId = department.Id,
            StartingUserRoleId = newbBoss.Id,
            NextUserRoleId = 0,
            TicketType = TicketType.ITSupport,
            IsFinalLevel = true
        };

        _context.Add(ticketEscalationRuleStepOne);
        _context.Add(ticketEscalationRuleStepTwo);

        await _context.SaveChangesAsync();
    }
}
