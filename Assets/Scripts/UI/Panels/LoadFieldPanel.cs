using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class LoadFieldPanel : Panel
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button returnButton;

        public Button StartButton => startButton;
        public Button ReturnButton => returnButton;
    }
}
