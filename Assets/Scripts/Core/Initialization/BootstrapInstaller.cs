using System;
using System.Collections.Generic;
using Core.Data;
using Core.Infrastructure;
using Core.Infrastructure.SceneLoad;
using Core.Infrastructure.Services.CoroutineRunner;
using Core.Infrastructure.StateMachine;
using Core.Infrastructure.States;
using Core.Infrastructure.UiManagement;
using UnityEngine;
using Zenject;

namespace Core.Initialization
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner coroutineRunner;
        [SerializeField] private SaveManager saveManager;
        
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindCommonFactory();
            BindUiManager();
            BindSaveManager();
            BindSceneLoader();
            BindGameStateMachine();
            BindStartGameSettings();
        }

        private void BindStartGameSettings() => 
            Container.Bind<StartGameData>().AsSingle().NonLazy();

        private void BindCommonFactory() => 
            Container.Bind<CommonFactory>().FromInstance(new CommonFactory(Container)).AsSingle();
        
        private void BindUiManager() => 
            Container.Bind<UiManager>().AsSingle().NonLazy();

        private void BindSaveManager() => 
            Container.Bind<SaveManager>().FromInstance(saveManager).AsSingle().NonLazy();
        
        private void BindCoroutineRunner() => 
            Container.Bind<ICoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
        
        private void BindSceneLoader() => 
            Container.Bind<SceneLoader>().AsSingle().NonLazy();

        private void BindGameStateMachine()
        {
            GameStateMachine<IState> stateMachine = new();
            Container.Bind<GameStateMachine<IState>>().FromInstance(stateMachine).AsSingle();
  
            Dictionary<Type, IState> states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = Container.Instantiate<BootstrapState>(),
                [typeof(LoadSceneState)] = Container.Instantiate<LoadSceneState>(),
                [typeof(MenuState)] = Container.Instantiate<MenuState>(),
                [typeof(GameState)] = Container.Instantiate<GameState>()
            };
        
            stateMachine.FillStateDictionary(states);
        }
    }
}
