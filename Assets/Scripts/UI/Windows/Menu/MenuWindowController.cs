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
            _menuWindowView.GenerateFieldPanel.StartButton.onClick.AddListener(_menuWindowModel.StartNewGame);
            _menuWindowView.GenerateFieldPanel.ReturnButton.onClick.AddListener(_menuWindowModel.ReturnToMainMenu);
            
            _menuWindowView.LoadFieldPanel.ReturnButton.onClick.AddListener(_menuWindowModel.ReturnToMainMenu);
            _menuWindowView.LoadFieldPanel.PanelShown += _menuWindowModel.OnLoadFieldPanelShow;
            
            
            _menuWindowView.LoadGamePanel.ReturnButton.onClick.AddListener(_menuWindowModel.ReturnToMainMenu);
            _menuWindowView.LoadGamePanel.PanelShown += _menuWindowModel.OnLoadGamePanelShow;
            
            _menuWindowView.MainMenuPanel.NewGameButton.onClick.AddListener(_menuWindowModel.ShowNewGamePanel);
            _menuWindowView.MainMenuPanel.LoadGameButton.onClick.AddListener(_menuWindowModel.ShowLoadGamePanel);
            
            _menuWindowView.NewGamePanel.GenerateNewFieldButton.onClick.AddListener(_menuWindowModel.ShowGenerateFieldPanel);
            _menuWindowView.NewGamePanel.LoadFieldButton.onClick.AddListener(_menuWindowModel.ShowLoadFieldPanel);
            _menuWindowView.NewGamePanel.ReturnButton.onClick.AddListener(_menuWindowModel.ReturnToMainMenu);
        }
    }
}
