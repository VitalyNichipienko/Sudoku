namespace Sudoku
{
    public struct SudokuField
    {
        private Cell[,] _cells;

        public SudokuField(Cell[,] cells)
        {
            int rows = cells.GetLength(0);
            int cols = cells.GetLength(1);
            _cells = new Cell[rows, cols];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _cells[i, j] = cells[i, j];
                }
            }
        }

        public Cell this[int row, int col]
        {
            get { return _cells[row, col]; }
            set { _cells[row, col] = value; }
        }
    }

}