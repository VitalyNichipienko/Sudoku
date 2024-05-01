using System;
using Core.Data;
using Core.Infrastructure.UiManagement;
using Sudoku;
using UI.Windows.Menu;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowModel
    {
        private UiManager _uiManager;
        private SaveManager _saveManager;
        private SudokuModel _sudokuModel;

        [Inject]
        public GameWindowModel(UiManager uiManager, SaveManager saveManager, SudokuModel sudokuModel)
        {
            _uiManager = uiManager;
            _saveManager = saveManager;
            _sudokuModel = sudokuModel;
        }
        
        public void ReturnToMenu()
        {
            _uiManager.ShowWindow<MenuWindowView>();
        }
        
        public void SaveProgress()
        {
            ProgressFieldSaveData progressSaveData = new ProgressFieldSaveData
            {
                GeneratedField = _sudokuModel.GeneratedSudokuField,
                CurrentField = _sudokuModel.CurrentSudokuField,
                SolutionField = _sudokuModel.SolutionField
            };
            _saveManager.SaveProgress(progressSaveData, CreateFileName());
        }

        public void SaveTemplate()
        {
            GeneratedFieldSaveData templateSaveData = new GeneratedFieldSaveData
            {
                GeneratedField = _sudokuModel.GeneratedSudokuField,
                SolutionField = _sudokuModel.SolutionField
            };
            _saveManager.SaveTemplate(templateSaveData, CreateFileName());
        }

        private string CreateFileName()
        {
            return "Save_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
        }
    }
}