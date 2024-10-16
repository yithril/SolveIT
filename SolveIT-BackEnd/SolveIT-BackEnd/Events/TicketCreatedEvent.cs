using MediatR;

namespace SolveIT_BackEnd.Events;

public class TicketCreatedEvent : INotification
{
    public int TicketId { get; set; }
    public int DepartmentId { get; set; }

    public TicketCreatedEvent(int ticketId, int departmentId)
    {
        TicketId = ticketId;
        DepartmentId = departmentId;
    }
}
