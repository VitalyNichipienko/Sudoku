using Sudoku;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowController : IInitializable
    {
        private GameWindowView _gameWindowView;
        private GameWindowModel _gameWindowModel;

        [Inject]
        private void Construct(GameWindowView gameWindowView, GameWindowModel gameWindowModel)
        {
            _gameWindowView = gameWindowView;
            _gameWindowModel = gameWindowModel;
        }
        
        public void Initialize()
        {
        }
    }
}