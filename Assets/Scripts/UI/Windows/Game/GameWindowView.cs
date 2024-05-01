using TMPro;
using UI.Configurations;
using UI.Sudoku;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowView : Window
    {
        [SerializeField] private SudokuFieldView sudokuFieldView;
        [SerializeField] private Button checkButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private TextMeshProUGUI resultText;

        [SerializeField] private Button saveProgressButton;
        [SerializeField] private Button saveTemplateButton;

        private UiConfiguration _uiConfiguration;
        
        public SudokuFieldView SudokuFieldView => sudokuFieldView;
        public Button CheckButton => checkButton;
        public Button MenuButton => menuButton;
        public Button SaveProgressButton => saveProgressButton;
        public Button SaveTemplateButton => saveTemplateButton;

        [Inject]
        private void Construct(UiConfiguration uiConfiguration)
        {
            _uiConfiguration = uiConfiguration;
        }
        
        public void ShowResult(bool isSolved)
        {
            string message = isSolved ? Constants.SolutionIsTrue : Constants.SolutionIsFalse;
            Color color = isSolved ? _uiConfiguration.TrueSolutionColor : _uiConfiguration.FalseSolutionColor;
            
            ShowMessage(message, color);
        }

        public void ShowMessage(string text, Color color)
        {
            resultText.text = text;
            resultText.color = color;
        }
        
        public override void Hide()
        {
            base.Hide();
            resultText.text = "";
        }
    }
}