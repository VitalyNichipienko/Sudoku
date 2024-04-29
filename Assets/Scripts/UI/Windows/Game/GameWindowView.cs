using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.Game
{
    public class GameWindowView : Window
    {
        [SerializeField] private Button checkButton;

        public Button CheckButton => checkButton;
    }
}
