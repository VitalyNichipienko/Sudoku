using System;
using System.Collections.Generic;
using Core.Infrastructure.SceneLoad;
using Core.Infrastructure.States;

namespace Core.Infrastructure.StateMachine
{
    public class GameStateMachine<TUsedState>  : IStateMachine<TUsedState> where TUsedState : IState
    {
        private Dictionary<Type, IState> _states;
        private TUsedState _activeState;
        private SceneLoader _sceneLoader;
    
        public void FillStateDictionary(Dictionary<Type, IState> states) => 
            _states = states;

        public void Enter<TState>() where TState : class, TUsedState
        {
            TUsedState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadedState<TPayload>, TUsedState
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        private TState ChangeState<TState>() where TState : class, TUsedState
        {
            if (_activeState is IExitableState activeState)
                activeState.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, TUsedState =>
            _states[typeof(TState)] as TState;
    }
}
