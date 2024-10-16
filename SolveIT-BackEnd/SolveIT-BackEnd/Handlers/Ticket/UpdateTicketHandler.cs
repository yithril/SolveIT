using MediatR;
using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Commands.Ticket;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_BackEnd.Handlers.Ticket;

public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand, TicketDto?>
{
    private readonly AppDbContext _appDbContext;

    public UpdateTicketHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<TicketDto?> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _appDbContext.Tickets
            .Include(x => x.Comments)
            .Include(x => x.TicketUsers)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if(ticket == null)
        {
            return null;
        }

        ticket.UpdatedOn = DateTime.UtcNow;
        ticket.UpdatedById = request.UpdatedById;
        ticket.Title = request.Title;
        ticket.Description = request.Description;
        //ticket.Status = request.Status;
        ticket.Priority = request.Priority;
        ticket.Severity = request.Severity;
        ticket.Language = request.Language;
        ticket.DepartmentId = request.DepartmentId;

        await _appDbContext.SaveChangesAsync();

        return ticket.ToDto();
    }
}
