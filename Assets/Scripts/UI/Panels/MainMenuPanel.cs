using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class MainMenuPanel : Panel
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button loadGameButton;

        public Button NewGameButton => newGameButton;
        public Button LoadGameButton => loadGameButton;
    }
}
