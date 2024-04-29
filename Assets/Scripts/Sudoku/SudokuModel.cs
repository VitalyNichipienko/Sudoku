using UI.Sudoku;
using UI.Windows.Game;
using UnityEngine;
using Zenject;

namespace Sudoku
{
    public class SudokuModel : IInitializable
    {
        private SudokuGenerator _sudokuGenerator;
        private SudokuField _sudokuField;
        private SudokuField _solution;
        private SudokuFieldView _sudokuFieldView;

        [Inject]
        private void Construct(SudokuGenerator sudokuGenerator, SudokuFieldView sudokuFieldView, GameWindowView gameWindowView)
        {
            _sudokuGenerator = sudokuGenerator;
            _sudokuFieldView = sudokuFieldView;
            
            gameWindowView.CheckButton.onClick.AddListener(CheckSolution);
        }

        public void Initialize()
        {
            _sudokuGenerator.GetSudokuField(out _sudokuField, out _solution);
            
            FillSudokuField();
        }

        private void FillSudokuField()
        {
            SudokuBlockView[] blockViews = _sudokuFieldView.SudokuBlockViews;

            for (int blockRow = 0; blockRow < 3; blockRow++)
            {
                for (int blockCol = 0; blockCol < 3; blockCol++)
                {
                    SudokuBlockView blockView = blockViews[blockRow * 3 + blockCol];
                    SudokuCellView[] cellViews = blockView.SudokuCellViews;

                    for (int cellRow = 0; cellRow < 3; cellRow++)
                    {
                        for (int cellCol = 0; cellCol < 3; cellCol++)
                        {
                            SudokuCellView cellView = cellViews[cellRow * 3 + cellCol];
                            Cell newCell = GetValueFromSudokuArray(blockRow, cellRow, blockCol, cellCol);
                            cellView.Init(new Cell(newCell.Value, newCell.IsEditable));

                            int currentBlockRow = blockRow;
                            int currentBlockCol = blockCol;
                            int currentCellRow = cellRow;
                            int currentCellCol = cellCol;

                            cellView.InputField.onValueChanged.AddListener((newValue) => OnCellValueChanged(currentBlockRow, currentBlockCol, currentCellRow, currentCellCol, newValue));
                        }
                    }
                }
            }
        }

        private Cell GetValueFromSudokuArray(int blockRow, int cellRow, int blockCol, int cellCol)
        {
            return _sudokuField[blockRow * 3 + cellRow, blockCol * 3 + cellCol];
        }
        
        private void OnCellValueChanged(int blockRow, int blockCol, int cellRow, int cellCol, string newValue)
        {
            if (int.TryParse(newValue, out int value))
            {
                _sudokuField[blockRow * Constants.BlockSize + cellRow, blockCol * Constants.BlockSize + cellCol] = new Cell(value, true);
            }
            else
            {
                Debug.LogWarning("An incorrect value has been entered into a cell!");
            }
        }
        
        public void CheckSolution()
        {
            int n = Constants.BlockSize * Constants.BlockSize;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Cell cell = _sudokuField[row, col];
                    if (cell.Value != _solution[row, col].Value)
                    {
                        Debug.Log("Solution is false");
                        return;
                    }
                }
            }

            Debug.Log("Solution is true");
        }
    }
}