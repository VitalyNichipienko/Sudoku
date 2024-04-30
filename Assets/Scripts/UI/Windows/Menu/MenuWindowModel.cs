using Core.Infrastructure.UiManagement;
using UI.Windows.Game;
using Zenject;

namespace UI.Windows.Menu
{
    public class MenuWindowModel
    {
        private UiManager _uiManager;

        [Inject]
        private void Construct(UiManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void StartNewGame()
        {
            _uiManager.ShowWindow<GameWindowView>();
        }
    }
}
