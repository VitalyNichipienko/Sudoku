using Sudoku;
using UI.Configurations;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowController : IInitializable
    {
        private const string FieldSaved = "Field saved";
        private const string ProgressSaved = "Progress saved";
        
        private GameWindowView _gameWindowView;
        private GameWindowModel _gameWindowModel;
        private SudokuModel _sudokuModel;
        private UiConfiguration _uiConfiguration;

        [Inject]
        public GameWindowController(GameWindowView gameWindowView, GameWindowModel gameWindowModel, SudokuModel sudokuModel, UiConfiguration uiConfiguration)
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
                _gameWindowView.ShowMessage(FieldSaved, _uiConfiguration.MessageTextColor);
            });
            
            _gameWindowView.SaveProgressButton.onClick.AddListener(_gameWindowModel.SaveProgress);
            _gameWindowView.SaveProgressButton.onClick.AddListener(() =>
            {
                _gameWindowView.ShowMessage(ProgressSaved, _uiConfiguration.MessageTextColor);
            });
        }
    }
}