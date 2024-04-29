using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.Menu
{
    public class MenuWindowView : Window
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button loadGameButton;

        public Button NewGameButton => newGameButton;
        public Button LoadGameButton => loadGameButton;
    }
}
