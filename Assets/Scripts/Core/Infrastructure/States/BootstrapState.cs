using Core.Infrastructure.StateMachine;
using Zenject;

namespace Core.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine<IState> _stateMachine;

        [Inject]
        public BootstrapState(GameStateMachine<IState> stateMachine) => 
            _stateMachine = stateMachine;

        public void Enter() => 
            _stateMachine.Enter<LoadDataState>();
    }
}
