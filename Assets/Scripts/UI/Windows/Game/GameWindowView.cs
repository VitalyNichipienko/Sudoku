using System.Collections;
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

        private const float AlphaDecreaseValue = 0.03f;
        private const float FadeInDelay = 0.03f;
        private const string SolutionIsTrue = "Solution is true";
        private const string SolutionIsFalse = "Solution is false";
        
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
            string message = isSolved ? SolutionIsTrue : SolutionIsFalse;
            Color color = isSolved ? _uiConfiguration.TrueSolutionColor : _uiConfiguration.FalseSolutionColor;
            
            ShowMessage(message, color);
        }

        public void ShowMessage(string text, Color color)
        {
            resultText.text = text;
            resultText.color = color;

            StartCoroutine(FadeOutMessage());
        }
        
        public override void Hide()
        {
            base.Hide();
            resultText.text = "";
        }
        
        private IEnumerator FadeOutMessage()
        {
            resultText.alpha = 1;
            
            while (resultText.alpha > 0)
            {
                resultText.alpha -= AlphaDecreaseValue;
                yield return new WaitForSeconds(FadeInDelay);
            }

            resultText.alpha = 0;
        }
    }
}