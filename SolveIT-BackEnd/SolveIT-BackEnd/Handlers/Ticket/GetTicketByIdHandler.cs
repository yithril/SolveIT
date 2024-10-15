using MediatR;
using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Commands.Ticket;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_BackEnd.Handlers.Ticket;

public class GetTicketByIdHandler : IRequestHandler<GetTicketByIdQuery, TicketDto>
{
    private readonly AppDbContext _appDbContext;

    public GetTicketByIdHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<TicketDto?> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _appDbContext.Tickets
            .Include(x => x.TicketUsers)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return ticket != null ? ticket.ToDto() : null;
    }
}
