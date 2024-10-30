using MediatR;
using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Events;
using SolveIT_BackEnd.Exceptions;
using SolveIT_BackEnd.Models;

namespace SolveIT_BackEnd.Handlers.Ticket;

public class AssignUsersToTicketHandler : INotificationHandler<TicketCreatedEvent>
{
    private readonly AppDbContext _appDbContext;

    public AssignUsersToTicketHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Handle(TicketCreatedEvent notification, CancellationToken cancellationToken)
    {
        var ticket = await _appDbContext.Tickets.FindAsync(notification.TicketId);

        if (ticket == null)
        {
            //Not sure how this will happen, need to email a human
            throw new InvalidOperationException("Can't assign people to a ticket that doesn't exist.");
        }

        var allRules = await _appDbContext.TicketEscalationRules.ToListAsync();

        var escalationRoleId = await _appDbContext.TicketEscalationRules
            .Where(x => x.IsActive &&
                   x.DepartmentId == notification.DepartmentId &&
                   x.Threshhold >= ticket.CalculateEscalationPoints() &&
                   x.TicketType == ticket.TicketType)
             .OrderBy(x => x.Threshhold)
             .Select(x => x.StartingUserRoleId)
             .FirstOrDefaultAsync();

        if (escalationRoleId == 0)
        {
            throw new EscalationRuleConfiguratonError($"Escalation rules for Department with id: ${notification.DepartmentId} have not been setup correctly. Contact IT");
        }

        //TODO
        //Make this a stored procedure and call it from here
        var userGroup = await (from user in _appDbContext.Users
                                     join ticketUsers in _appDbContext.TicketUsers
                                     on user.Id equals ticketUsers.UserId into ticketUserGroup
                                     from ticketUsers in ticketUserGroup.DefaultIfEmpty()
                                     join tickets in _appDbContext.Tickets
                                     on ticketUsers.TicketId equals tickets.Id into ticketGroup
                                     from tickets in ticketGroup.DefaultIfEmpty()
                                     where user.IsActive &&
                                     user.DepartmentId == notification.DepartmentId &&
                                     user.UserRoleId == escalationRoleId &&
                                     (ticket == null || ticket.Status == Enums.TicketStatus.InProgress || ticket.Status == Enums.TicketStatus.Open)
                               group new { user, ticket } by user.Id into grouped
                               orderby grouped.Count(x => x.ticket != null) ascending,
                                   grouped.Key
                               select new
                               {
                                   UserId = grouped.Key,
                                   TicketCount = grouped.Count(x => x.ticket != null)
                               }).FirstOrDefaultAsync();

        if (userGroup == null)
        {
            throw new Exception("Something horrible happened.");
        }

        var userToAssignTo = await _appDbContext.Users.FindAsync(userGroup.UserId);

        if (userToAssignTo == null)
        {
            throw new Exception("Something horrible happened.");
        }

        //create a ticket user based on who the ticket should be assigned to
        var ticketUser = new TicketUser()
        {
            TicketId = notification.TicketId,
            UserId = userToAssignTo.Id,
            Role = Enums.TicketUserRole.Support,
            CreatedOn = DateTime.UtcNow,
            IsActive = true,
            CreatedById = userToAssignTo.Id
        };

        _appDbContext.TicketUsers.Add(ticketUser);
        await _appDbContext.SaveChangesAsync();
    }
}
