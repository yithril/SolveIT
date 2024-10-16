using SolveIT_BackEnd.Enums;
using Stateless;

namespace SolveIT_BackEnd.Helpers;

public class TicketStatusStateMachine
{
    private readonly StateMachine<TicketStatus, TicketTrigger> _stateMachine;

    public TicketStatus Status => _stateMachine.State;

    public TicketStatusStateMachine(TicketStatus initialState)
    {
        _stateMachine = new StateMachine<TicketStatus, TicketTrigger>(initialState);

        _stateMachine.Configure(TicketStatus.Open)
            .Permit(TicketTrigger.StartWork, TicketStatus.InProgress)
            .Permit(TicketTrigger.Resolve, TicketStatus.Resolved);

        _stateMachine.Configure(TicketStatus.InProgress)
            .Permit(TicketTrigger.Resolve, TicketStatus.Resolved)
            .Permit(TicketTrigger.Hold, TicketStatus.OnHold);
    }

    public bool CanTransition(TicketTrigger trigger)
    {
        return _stateMachine.CanFire(trigger);
    }

    public void TransitionTo(TicketTrigger trigger)
    {
        _stateMachine.Fire(trigger);
    }

    public TicketStatus GetCurrentState()
    {
        return _stateMachine.State;
    }
}
