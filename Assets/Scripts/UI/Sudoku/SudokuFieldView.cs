using UnityEngine;

namespace UI.Sudoku
{
    public class SudokuFieldView : MonoBehaviour
    {
        [SerializeField] private SudokuBlockView[] sudokuBlockViews;

        public SudokuBlockView[] SudokuBlockViews => sudokuBlockViews;
    }
}