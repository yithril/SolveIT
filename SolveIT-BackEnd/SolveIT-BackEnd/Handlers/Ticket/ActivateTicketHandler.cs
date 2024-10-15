using MediatR;
using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Commands.Ticket;
using SolveIT_BackEnd.Data;

namespace SolveIT_BackEnd.Handlers.Ticket;

public class ActivateTicketHandler : IRequestHandler<ActivateTicketCommand, bool>
{
    private readonly AppDbContext _appDbContext;

    public ActivateTicketHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> Handle(ActivateTicketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ticket = await _appDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (ticket == null)
            {
                return false;
            }

            ticket.IsActive = true;

            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
