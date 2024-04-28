using Core.Infrastructure.SceneLoad;
using Core.Infrastructure.StateMachine;
using Zenject;

namespace Core.Infrastructure.States
{
    public class LoadSceneState : IPayloadedState<LoadingScenes>
    {
        private readonly GameStateMachine<IState> _stateMachine;
        private readonly SceneLoader _sceneLoader;

        [Inject]
        public LoadSceneState(GameStateMachine<IState> stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() { }

        public void Enter(LoadingScenes scene) => 
            _sceneLoader.Load(scene, OnLoaded);

        private void OnLoaded() => 
            _stateMachine.Enter<GameLoopState>();
    }
}
