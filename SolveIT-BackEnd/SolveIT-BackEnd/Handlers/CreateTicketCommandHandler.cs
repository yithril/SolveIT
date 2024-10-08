﻿using MediatR;
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
            var ticket = request.ToEntity();
            ticket.CreatedOn = DateTime.UtcNow;
            ticket.IsActive = true;

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
