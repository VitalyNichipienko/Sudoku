using UI.Sudoku;
using UnityEngine;
using Zenject;

namespace Sudoku
{
    public class SudokuInstaller : MonoInstaller
    {
        [SerializeField] private SudokuFieldView sudokuFieldView;
        
        public override void InstallBindings()
        {
            BindSudokuFieldView();
            BindSudokuGenerator();
            BindSudokuController();
        }

        private void BindSudokuFieldView() =>
            Container.Bind<SudokuFieldView>().FromComponentInHierarchy().AsSingle();
        
        private void BindSudokuGenerator() => 
            Container.Bind<SudokuGenerator>().AsSingle().NonLazy();

        private void BindSudokuController() => 
            Container.Bind<IInitializable>().To<SudokuModel>().AsSingle().NonLazy();
    }
}