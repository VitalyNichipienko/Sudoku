﻿using Core.Infrastructure.UiManagement;
using UI.Windows.Menu;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowModel
    {
        private UiManager _uiManager;

        [Inject]
        private void Construct(UiManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void ReturnToMenu()
        {
            _uiManager.ShowWindow<MenuWindowView>();
        }
        
        public void StartGame()
        {
            
        }
    }
}