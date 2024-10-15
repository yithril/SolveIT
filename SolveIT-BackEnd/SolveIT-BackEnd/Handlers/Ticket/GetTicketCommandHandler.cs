using MediatR;
using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Commands.Ticket;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_BackEnd.Handlers.Ticket;

public class GetTicketCommandHandler : IRequestHandler<GetAllTicketsQuery, List<TicketDto>>
{
    private readonly AppDbContext _appDbContext;

    public GetTicketCommandHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<List<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var query = _appDbContext.Tickets.AsQueryable();

        if (request.Status != null)
        {
            query = query.Where(x => x.Status == request.Status);
        }

        if (request.Language != null)
        {
            query = query.Where(x => x.Language == request.Language);
        }

        if (request.Title != null)
        {
            query = query.Where(x => x.Title.Contains(request.Title, StringComparison.InvariantCultureIgnoreCase));
        }

        if (request.Severity != null)
        {
            query = query.Where(x => x.Severity == request.Severity);
        }

        if (request.DepartmentId != null)
        {
            query = query.Where(x => x.DepartmentId == request.DepartmentId);
        }

        if (request.Priority != null)
        {
            query = query.Where(x => x.Priority == request.Priority);
        }

        var tickets = await query
                        .Where(x => x.IsActive == request.IsActive)
                        .Include(x => x.TicketUsers)
                        .Include(x => x.Comments)
                        .ToListAsync();

        return tickets.Select(x => x.ToDto()).ToList();
    }
}
