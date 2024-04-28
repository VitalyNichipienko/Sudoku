using Core.Infrastructure.States;

namespace Core.Infrastructure.StateMachine
{
    public interface IStateMachine<TUsedState>
    {
        void Enter<TState>() where TState : class, TUsedState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, TUsedState, IPayloadedState<TPayload>;
    }
}
