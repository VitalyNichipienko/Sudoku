using UnityEngine;

namespace UI.Sudoku
{
    public class SudokuBlockView : MonoBehaviour
    {
        [SerializeField] private SudokuCellView[] sudokuCellViews;

        public SudokuCellView[] SudokuCellViews => sudokuCellViews; 
    }
}
