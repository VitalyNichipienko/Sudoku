using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class MenuWindow : Window
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button loadGameButton;

        public Button NewGameButton => newGameButton;
        public Button LoadGameButton => loadGameButton;
        
        public override void Show()
        {
            
        }

        public override void Hide()
        {
            
        }
    }
}
