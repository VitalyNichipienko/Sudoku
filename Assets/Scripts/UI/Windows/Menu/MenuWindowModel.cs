using Core.Data;
using Core.Infrastructure.StateMachine;
using Core.Infrastructure.States;
using Zenject;

namespace UI.Windows.Menu
{
    public class MenuWindowModel
    {
        private GameStateMachine<IState> _gameStateMachine;
        private MenuWindowView _menuWindowView;
        private StartGameData _startGameData;

        [Inject]
        public MenuWindowModel(GameStateMachine<IState> gameStateMachine, MenuWindowView menuWindowView, StartGameData startGameData)
        {
            _gameStateMachine = gameStateMachine;
            _menuWindowView = menuWindowView;
            _startGameData = startGameData;
        }
        
        public void StartNewGame()
        {
            _startGameData.Init(StartType.GenerateNewField, _menuWindowView.GenerateFieldPanel.FieldComplexity);
            
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

        public void OnLoadFieldPanelShow()
        {
            _menuWindowView.LoadFieldPanel.AddButtonsToWindow();

            for (int i = 0; i < _menuWindowView.LoadFieldPanel.LoadButtons.Count; i++)
            {
                _menuWindowView.LoadFieldPanel.LoadButtons[i].OnLoad += fileName =>
                {
                    _startGameData.Init(StartType.LoadField, fileName);
                    
                    _gameStateMachine.Enter<GameState>();
                };
            }
        }

        public void OnLoadGamePanelShow()
        {
            _menuWindowView.LoadGamePanel.AddButtonsToWindow();
            
            for (int i = 0; i < _menuWindowView.LoadGamePanel.LoadButtons.Count; i++)
            {
                _menuWindowView.LoadGamePanel.LoadButtons[i].OnLoad += fileName =>
                {
                    _startGameData.Init(StartType.LoadProgress, fileName);
            
                    _gameStateMachine.Enter<GameState>();
                };
            }
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
