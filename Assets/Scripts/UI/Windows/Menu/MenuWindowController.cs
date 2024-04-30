using Zenject;

namespace UI.Windows.Menu
{
    public class MenuWindowController : IInitializable
    {        
        private MenuWindowView _menuWindowView;
        private MenuWindowModel _menuWindowModel;

        [Inject]
        private void Construct(MenuWindowView menuWindowView, MenuWindowModel menuWindowModel)
        {
            _menuWindowView = menuWindowView;
            _menuWindowModel = menuWindowModel;
        }
        
        public void Initialize()
        {
            _menuWindowView.NewGameButton.onClick.AddListener(_menuWindowModel.StartNewGame);
        }
    }
}
