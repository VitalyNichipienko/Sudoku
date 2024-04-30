using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class NewGamePanel : Panel
    {
        [SerializeField] private Button generateNewFieldButton;
        [SerializeField] private Button loadFieldButton;
        [SerializeField] private Button returnButton;

        public Button GenerateNewFieldButton => generateNewFieldButton;
        public Button LoadFieldButton => loadFieldButton;
        public Button ReturnButton => returnButton;
    }
}
