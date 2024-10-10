using MediatR;
using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Commands;
using SolveIT_BackEnd.Data;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_BackEnd.Handlers;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketDto>
{
    private readonly AppDbContext _appDbContext;
    public CreateTicketCommandHandler(AppDbContext context)
    {
        _appDbContext = context;
    }

    public async Task<TicketDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            //Does the department even exist?
            var departmentExists = await _appDbContext.Departments.AnyAsync(x => x.Id == request.DepartmentId);

            if(!departmentExists)
            {
                throw new ArgumentException("The department does not exist!");
            }

            var ticket = request.ToEntity();
            ticket.CreatedOn = DateTime.UtcNow;

            _appDbContext.Add(ticket);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return ticket.ToDto();
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating ticket", ex);
        }
    }
}
