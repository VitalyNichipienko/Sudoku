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

        public SudokuFieldView SudokuFieldView => sudokuFieldView;
        public Button CheckButton => checkButton;
        public Button MenuButton => menuButton;
    }
}
