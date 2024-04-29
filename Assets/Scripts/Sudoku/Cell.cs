namespace Sudoku
{
    public struct Cell
    {
        public int Value { get; private set; } 
        public bool IsEditable { get; private set; } 

        public Cell(int value, bool isEditable)
        {
            Value = value;
            IsEditable = isEditable;
        }
    }
}