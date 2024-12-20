﻿using MediatR;

namespace SolveIT_BackEnd.Commands.Ticket;

public class DeactivateTicketCommand : IRequest<bool>
{
    public int Id { get; set; }
}
