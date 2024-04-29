using UnityEngine;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowInstaller : MonoInstaller
    {
        [SerializeField] private GameWindowView gameWindowView;
        
        public override void InstallBindings()
        {
            BindGameWindowView();
            BindGameWindowModel();
            BindGameWindowController();
        }

        private void BindGameWindowView() =>
            Container.Bind<GameWindowView>().FromComponentInHierarchy(gameWindowView).AsSingle().NonLazy();

        private void BindGameWindowModel() =>
            Container.Bind<GameWindowModel>().AsSingle().NonLazy();

        private void BindGameWindowController() =>
            Container.Bind<IInitializable>().To<GameWindowController>().AsSingle().NonLazy();
    }
}
