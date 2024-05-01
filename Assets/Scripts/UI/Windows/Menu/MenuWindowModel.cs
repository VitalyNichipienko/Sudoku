using Core.Data;
using Core.Infrastructure.StateMachine;
using Core.Infrastructure.States;
using UI.Elements;
using Zenject;

namespace UI.Windows.Menu
{
    public class MenuWindowModel
    {
        private GameStateMachine<IState> _gameStateMachine;
        private MenuWindowView _menuWindowView;
        private StartGameData _startGameData;
        private SaveManager _saveManager;

        [Inject]
        public MenuWindowModel(GameStateMachine<IState> gameStateMachine, MenuWindowView menuWindowView, StartGameData startGameData, SaveManager saveManager)
        {
            _gameStateMachine = gameStateMachine;
            _menuWindowView = menuWindowView;
            _startGameData = startGameData;
            _saveManager = saveManager;
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

            for (int i = 0; i < _menuWindowView.LoadFieldPanel.SaveItems.Count; i++)
            {
                _menuWindowView.LoadFieldPanel.SaveItems[i].OnLoad += fileName =>
                {
                    _startGameData.Init(StartType.LoadField, fileName);
                    
                    _gameStateMachine.Enter<GameState>();
                };

                var index = i;
                _menuWindowView.LoadFieldPanel.SaveItems[i].OnDelete += fileName =>
                {
                    SaveItem saveItem = _menuWindowView.LoadFieldPanel.SaveItems[index];
                    
                    _saveManager.DeleteSaveFile(fileName, SaveType.Template);
                    _menuWindowView.LoadFieldPanel.DeleteSaveItemFromWindow(saveItem);
                };
            }
        }

        public void OnLoadGamePanelShow()
        {
            _menuWindowView.LoadGamePanel.AddButtonsToWindow();
            
            for (int i = 0; i < _menuWindowView.LoadGamePanel.SaveItems.Count; i++)
            {
                _menuWindowView.LoadGamePanel.SaveItems[i].OnLoad += fileName =>
                {
                    _startGameData.Init(StartType.LoadProgress, fileName);
            
                    _gameStateMachine.Enter<GameState>();
                };
                
                var index = i;
                _menuWindowView.LoadGamePanel.SaveItems[i].OnDelete += fileName =>
                {
                    SaveItem saveItem = _menuWindowView.LoadGamePanel.SaveItems[index];

                    _saveManager.DeleteSaveFile(fileName, SaveType.Progress);
                    _menuWindowView.LoadGamePanel.DeleteSaveItemFromWindow(saveItem);
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
