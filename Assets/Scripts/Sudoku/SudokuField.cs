namespace Sudoku
{
    public struct SudokuField
    {
        public Cell[,] Cells { get; }

        public SudokuField(Cell[,] cells)
        {
            int rows = cells.GetLength(0);
            int cols = cells.GetLength(1);
            Cells = new Cell[rows, cols];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Cells[i, j] = cells[i, j];
                }
            }
        }

        public Cell this[int row, int col]
        {
            get { return Cells[row, col]; }
            set { Cells[row, col] = value; }
        }
    }

}