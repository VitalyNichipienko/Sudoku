using Core.Data;
using UI.Sudoku;
using UI.Windows.Game;
using UnityEngine;
using Zenject;

namespace Sudoku
{
    public class SudokuModel
    {
        private SudokuGenerator _sudokuGenerator;
        private SudokuFieldView _sudokuFieldView;
        private GameWindowView _gameWindowView;
        private SaveManager _saveManager;
        private StartGameData _startGameData;

        private SudokuField _currentSudokuField;
        private SudokuField _solutionField;
        private SudokuField _generatedSudokuField;

        public SudokuField CurrentSudokuField => _currentSudokuField;
        public SudokuField SolutionField => _solutionField;
        public SudokuField GeneratedSudokuField => _generatedSudokuField;

        [Inject]
        private void Construct(SudokuGenerator sudokuGenerator, SudokuFieldView sudokuFieldView, GameWindowView gameWindowView, SaveManager saveManager, StartGameData startGameData)
        {
            _sudokuGenerator = sudokuGenerator;
            _sudokuFieldView = sudokuFieldView;
            _gameWindowView = gameWindowView;
            _saveManager = saveManager;
            _startGameData = startGameData;
        }

        public void Init()
        {
            switch (_startGameData.StartType)
            {
                case StartType.GenerateNewField:
                    GenerateNewField(_startGameData.Complexity);
                    break;
                case StartType.LoadField:
                    LoadTemplateField(_startGameData.FileName);
                    break;
                case StartType.LoadProgress:
                    LoadProgressField(_startGameData.FileName);
                    break;
            }
            
            FillSudokuField();
            
            _gameWindowView.CheckButton.onClick.AddListener(CheckSolution);
        }

        private void GenerateNewField(int cellToHide)
        {
            _sudokuGenerator.GetSudokuField(cellToHide, out _generatedSudokuField, out _solutionField);
            _currentSudokuField = new SudokuField(_generatedSudokuField.Cells);
        }

        private void LoadTemplateField(string fileName)
        {
            GeneratedFieldSaveData saveData = _saveManager.LoadFromFile<GeneratedFieldSaveData>(fileName);
            if (saveData != null)
            {
                _generatedSudokuField = saveData.GeneratedField;
                _solutionField = saveData.SolutionField;
                _currentSudokuField = new SudokuField(_generatedSudokuField.Cells);
            }
            else
            {
                Debug.LogError("Failed to load template field.");
            }
        }

        private void LoadProgressField(string fileName)
        {
            ProgressFieldSaveData saveData = _saveManager.LoadFromFile<ProgressFieldSaveData>(fileName);
            if (saveData != null)
            {
                _generatedSudokuField = saveData.GeneratedField; 
                _solutionField = saveData.SolutionField;
                _currentSudokuField = saveData.CurrentField;
            }
            else
            {
                Debug.LogError("Failed to load progress field.");
            }
        }

        private void FillSudokuField()
        {
            SudokuBlockView[] blockViews = _sudokuFieldView.SudokuBlockViews;

            for (int blockRow = 0; blockRow < Constants.BlockSize; blockRow++)
            {
                for (int blockCol = 0; blockCol < Constants.BlockSize; blockCol++)
                {
                    SudokuBlockView blockView = blockViews[blockRow * Constants.BlockSize + blockCol];
                    SudokuCellView[] cellViews = blockView.SudokuCellViews;

                    for (int cellRow = 0; cellRow < Constants.BlockSize; cellRow++)
                    {
                        for (int cellCol = 0; cellCol < Constants.BlockSize; cellCol++)
                        {
                            SudokuCellView cellView = cellViews[cellRow * Constants.BlockSize + cellCol];
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
            return _currentSudokuField[blockRow * Constants.BlockSize + cellRow, blockCol * Constants.BlockSize + cellCol];
        }

        private void OnCellValueChanged(int blockRow, int blockCol, int cellRow, int cellCol, string newValue)
        {
            if (int.TryParse(newValue, out int value))
            {
                _currentSudokuField[blockRow * Constants.BlockSize + cellRow, blockCol * Constants.BlockSize + cellCol] = new Cell(value, true);
            }
            else
            {
                Debug.LogWarning("An incorrect value has been entered into a cell!");
            }
        }

        private void CheckSolution()
        {
            int n = Constants.BlockSize * Constants.BlockSize;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Cell cell = _currentSudokuField[row, col];
                    if (cell.Value != _solutionField[row, col].Value)
                    {
                        _gameWindowView.ShowResult(false);
                        return;
                    }
                }
            }

            _gameWindowView.ShowResult(true);
        }
    }
}