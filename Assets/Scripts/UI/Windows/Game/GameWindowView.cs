using TMPro;
using UI.Sudoku;
using UnityEngine;
using UnityEngine.UI;

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

        public SudokuFieldView SudokuFieldView => sudokuFieldView;
        public Button CheckButton => checkButton;
        public Button MenuButton => menuButton;
        public Button SaveProgressButton => saveProgressButton;
        public Button SaveTemplateButton => saveTemplateButton;

        public void ShowResult(bool isSolved)
        {
            resultText.text = isSolved ? Constants.SolutionIsTrue : Constants.SolutionIsFalse;
            resultText.color = isSolved ? Color.green : Color.red;
        }

        public override void Hide()
        {
            base.Hide();
            resultText.text = "";
        }
    }
}