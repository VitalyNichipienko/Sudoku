﻿using Core.Infrastructure.UiManagement;
using UI.Windows.Menu;
using Zenject;

namespace Core.Infrastructure.States
{
    public class MenuState : IState
    {
        private UiManager _uiManager;

        [Inject]
        private void Construct(UiManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void Enter()
        {
            _uiManager.ShowWindow<MenuWindowView>();
        }
    }
}