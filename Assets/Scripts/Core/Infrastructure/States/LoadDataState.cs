using Core.Data;
using Core.Infrastructure.SceneLoad;
using Core.Infrastructure.StateMachine;
using Zenject;

namespace Core.Infrastructure.States
{
    public class LoadDataState : IState
    {
        private readonly GameStateMachine<IState> _stateMachine;

        private readonly SaveManager _saveManager;

        [Inject]
        public LoadDataState(GameStateMachine<IState> stateMachine, SaveManager saveManager)
        {
            _stateMachine = stateMachine;
            _saveManager = saveManager;
        }
        
        public void Enter()
        {
            LoadData();
        }

        private void LoadData()
        {
            _saveManager.LoadData();
            
            _stateMachine.Enter<LoadSceneState, LoadingScenes>(LoadingScenes.Game);
        }
    }
}