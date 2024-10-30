using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models;

public class Ticket : BaseModel
{
    private readonly TicketStatusStateMachine _stateMachine;

    [Required]
    public TicketPriority Priority { get; set; }

    [Required]
    public TicketSeverity Severity { get; set; }

    [Required]
    public TicketStatus Status { get; private set; }

    [Required]
    public TicketType TicketType { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(750)]
    public string Description { get; set; }

    [Required]
    public Language Language { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public List<TicketUser> TicketUsers { get; set; } = new List<TicketUser>();

    public List<Comment> Comments { get; set; } = new List<Comment>();

    public Ticket()
    {
        _stateMachine = new TicketStatusStateMachine(Status);
    }

    public void ChangeStatus(TicketTrigger trigger)
    {
        if (!_stateMachine.CanTransition(trigger))
        {
            throw new InvalidOperationException("Invalid status transition");
        }

        _stateMachine.TransitionTo(trigger);

        Status = _stateMachine.GetCurrentState();
    }

    public int CalculateEscalationPoints()
    {
        var severityMatrix = new Dictionary<(TicketPriority, TicketSeverity), int>()
        {
            {(TicketPriority.Low, TicketSeverity.Minor), 1},
            {(TicketPriority.Low, TicketSeverity.Major), 2},
            {(TicketPriority.Medium, TicketSeverity.Minor), 2},
            {(TicketPriority.Medium, TicketSeverity.Major), 4},
            {(TicketPriority.High, TicketSeverity.Minor), 3},
            {(TicketPriority.High, TicketSeverity.Major), 5},
            {(TicketPriority.Critical, TicketSeverity.Minor), 4},
            {(TicketPriority.Critical, TicketSeverity.Major), 6}
        };

        if (severityMatrix.TryGetValue((Priority, Severity), out int points))
        {
            return points;
        }

        throw new InvalidOperationException("Invalid combination of Priority and Severity.");
    }
}
