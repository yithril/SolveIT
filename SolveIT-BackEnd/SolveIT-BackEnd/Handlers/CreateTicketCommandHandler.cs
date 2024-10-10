using MediatR;
using SolveIT_BackEnd.Commands;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Handlers;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketDto>
{
    private readonly AppDbContext _appDbContext;
    public CreateTicketCommandHandler(AppDbContext context)
    {
        _appDbContext = context;
    }

    public Task<TicketDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
