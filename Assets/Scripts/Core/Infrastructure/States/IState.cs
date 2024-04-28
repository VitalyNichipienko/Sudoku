namespace Core.Infrastructure.States
{
    public interface IState
    {
        void Enter();
    }

    public interface IPayloadedState<TPayload> : IState
    {
        void Enter(TPayload payload);
    }
  
    public interface IExitableState : IState
    {
        void Exit();
    }
}