using Core.Infrastructure.StateMachine;
using Core.Infrastructure.States;
using Zenject;

namespace UI.Windows.Menu
{
    public class MenuWindowModel
    {
        private GameStateMachine<IState> _gameStateMachine;
        private MenuWindowView _menuWindowView;

        [Inject]
        private void Construct(GameStateMachine<IState> gameStateMachine, MenuWindowView menuWindowView)
        {
            _gameStateMachine = gameStateMachine;
            _menuWindowView = menuWindowView;
        }
        
        public void StartNewGame()
        {
            _gameStateMachine.Enter<GameState>();
        }

        public void ShowNewGamePanel()
        {
            HidePanels();
            _menuWindowView.NewGamePanel.Show();
        }

        public void ShowLoadGamePanel()
        {
            HidePanels();
            _menuWindowView.LoadGamePanel.Show();
        }

        public void ShowGenerateFieldPanel()
        {
            HidePanels();
            _menuWindowView.GenerateFieldPanel.Show();
        }

        public void ShowLoadFieldPanel()
        {
            HidePanels();
            _menuWindowView.LoadFieldPanel.Show();
        }

        public void ReturnToMainMenu()
        {
            HidePanels();
            _menuWindowView.MainMenuPanel.Show();
        }

        private void HidePanels()
        {
            for (int i = 0; i < _menuWindowView.Panels.Count; i++)
            {
                _menuWindowView.Panels[i].Hide();
            }
        }
    }
}
