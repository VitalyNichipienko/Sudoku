using Sudoku;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowController : IInitializable
    {
        private GameWindowView _gameWindowView;
        private GameWindowModel _gameWindowModel;
        private SudokuModel _sudokuModel;

        [Inject]
        private void Construct(GameWindowView gameWindowView, GameWindowModel gameWindowModel, SudokuModel sudokuModel)
        {
            _gameWindowView = gameWindowView;
            _gameWindowModel = gameWindowModel;
            _sudokuModel = sudokuModel;
        }
        
        public void Initialize()
        {
            _gameWindowView.MenuButton.onClick.AddListener(_gameWindowModel.ReturnToMenu);
            _gameWindowView.WindowShown += _sudokuModel.Init;
            
            _gameWindowView.SaveTemplateButton.onClick.AddListener(_gameWindowModel.SaveTemplate);
            _gameWindowView.SaveProgressButton.onClick.AddListener(_gameWindowModel.SaveProgress);
        }
    }
}