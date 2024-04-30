using Core.Infrastructure.UiManagement;
using UnityEngine;
using Zenject;

namespace Core.Initialization
{
    [CreateAssetMenu(menuName = "Installers/Create bootstrap configs installer", fileName = "BootstrapConfigsInstaller")]
    public class BootstrapConfigurationsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private WindowsPrefabsContainer windowsPrefabsContainer;
        
        public override void InstallBindings()
        {
            BindWindowsPrefabsContainer();
        }
        
        private void BindWindowsPrefabsContainer() => 
            Container.Bind<WindowsPrefabsContainer>().FromInstance(windowsPrefabsContainer).AsSingle();
    }
}
