using UnityEngine;
using Zenject;

namespace UI.Windows.Menu
{
    public class MenuWindowInstaller : MonoInstaller
    {
        [SerializeField] private MenuWindowView menuWindowView;
        
        public override void InstallBindings()
        {
            BindMenuWindowView();
            BindMenuWindowModel();
            BindMenuWindowController();
        }

        private void BindMenuWindowView() =>
            Container.Bind<MenuWindowView>().FromInstance(menuWindowView).AsSingle().NonLazy();

        private void BindMenuWindowModel() =>
            Container.Bind<MenuWindowModel>().AsSingle().NonLazy();

        private void BindMenuWindowController() =>
            Container.Bind<IInitializable>().To<MenuWindowController>().AsSingle().NonLazy();
    }
}
