using Core.Infrastructure.StateMachine;
using Core.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Core.Initialization
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine<IState> _stateMachine;

        [Inject]
        private void Construct(GameStateMachine<IState> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Start() => 
            _stateMachine.Enter<BootstrapState>();
    }
}
