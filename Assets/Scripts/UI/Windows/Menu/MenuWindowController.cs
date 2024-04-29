using Zenject;

namespace UI.Windows.Menu
{
    public class MenuWindowController : IInitializable
    {        
        private MenuWindowView _menuWindowView;
        private MenuWindowModel _menuWindowModel;

        [Inject]
        private void Construct()
        {
        }
        
        public void Initialize()
        {
            
        }
    }
}
