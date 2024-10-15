using MediatR;
using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Commands.Ticket;
using SolveIT_BackEnd.Data;

namespace SolveIT_BackEnd.Handlers.Ticket;

public class DeactivateTicketHandler : IRequestHandler<DeactivateTicketCommand, bool>
{
    private readonly AppDbContext _appDbContext;

    public DeactivateTicketHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> Handle(DeactivateTicketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ticket = await _appDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (ticket == null)
            {
                return false;
            }

            ticket.IsActive = false;

            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
