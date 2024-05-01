using Sudoku;
using UI.Configurations;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowController : IInitializable
    {
        private GameWindowView _gameWindowView;
        private GameWindowModel _gameWindowModel;
        private SudokuModel _sudokuModel;
        private UiConfiguration _uiConfiguration;

        [Inject]
        private void Construct(GameWindowView gameWindowView, GameWindowModel gameWindowModel, SudokuModel sudokuModel, UiConfiguration uiConfiguration)
        {
            _gameWindowView = gameWindowView;
            _gameWindowModel = gameWindowModel;
            _sudokuModel = sudokuModel;
            _uiConfiguration = uiConfiguration;
        }
        
        public void Initialize()
        {
            _gameWindowView.MenuButton.onClick.AddListener(_gameWindowModel.ReturnToMenu);
            _gameWindowView.WindowShown += _sudokuModel.Init;
            
            _gameWindowView.SaveTemplateButton.onClick.AddListener(_gameWindowModel.SaveTemplate);
            _gameWindowView.SaveTemplateButton.onClick.AddListener(() =>
            {
                _gameWindowView.ShowMessage("Field saved", _uiConfiguration.MessageTextColor);
            });
            
            _gameWindowView.SaveProgressButton.onClick.AddListener(_gameWindowModel.SaveProgress);
            _gameWindowView.SaveProgressButton.onClick.AddListener(() =>
            {
                _gameWindowView.ShowMessage("Progress saved", _uiConfiguration.MessageTextColor);
            });
        }
    }
}