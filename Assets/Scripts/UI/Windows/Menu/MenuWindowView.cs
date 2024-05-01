using System.Collections.Generic;
using UI.Panels;
using UnityEngine;

namespace UI.Windows.Menu
{
    public class MenuWindowView : Window
    {
        [SerializeField] private MainMenuPanel mainMenuPanel;
        [SerializeField] private NewGamePanel newGamePanel;
        [SerializeField] private GenerateFieldPanel generateFieldPanel;
        [SerializeField] private LoadPanel loadFieldPanel;
        [SerializeField] private LoadPanel loadGamePanel;

        public List<Panel> Panels { get; } = new();

        public MainMenuPanel MainMenuPanel => mainMenuPanel;

        public NewGamePanel NewGamePanel => newGamePanel;

        public GenerateFieldPanel GenerateFieldPanel => generateFieldPanel;

        public LoadPanel LoadFieldPanel => loadFieldPanel;

        public LoadPanel LoadGamePanel => loadGamePanel;

        private void Awake()
        {
            Panels.Add(mainMenuPanel);
            Panels.Add(newGamePanel);
            Panels.Add(generateFieldPanel);
            Panels.Add(loadFieldPanel);
            Panels.Add(loadGamePanel);
        }
    }
}