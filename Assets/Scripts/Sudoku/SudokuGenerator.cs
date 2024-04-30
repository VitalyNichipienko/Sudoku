using UnityEngine;

namespace Sudoku
{
    public class SudokuGenerator
    {
        private const int ShuffleCount = 10;
        private Cell[,] _sudokuField = new Cell[BlockSize * BlockSize, BlockSize * BlockSize];
        private int _cellsToHide;
        
        private static int BlockSize => Constants.BlockSize;
        
        public void GetSudokuField(int cellsToHide, out SudokuField sudokuField, out SudokuField solution)
        {
            _cellsToHide = cellsToHide;
            
            GenerateMap();

            for (int i = 0; i < ShuffleCount; i++)
            {
                ShuffleMap(Random.Range(0, 5));
            }

            solution = new SudokuField(_sudokuField);
            
            HideCells();

            sudokuField = new SudokuField(_sudokuField);
        }

        private void GenerateMap()
        {
            for (int i = 0; i < BlockSize * BlockSize; i++)
            {
                for (int j = 0; j < BlockSize * BlockSize; j++)
                {
                    _sudokuField[i, j] = new Cell((i * BlockSize + i / BlockSize + j) % (BlockSize * BlockSize) + 1, false);
                }
            }
        }

        private void ShuffleMap(int i)
        {
            switch (i)
            {
                case 0: MatrixTransposition(); break;
                case 1: SwapRowsInBlock(); break;
                case 2: SwapColumnsInBlock(); break;
                case 3: SwapBlocksInRow(); break;
                case 4: SwapBlocksInColumn(); break;
                default: MatrixTransposition(); break;
            }
        }

        private void MatrixTransposition()
        {
            Cell[,] tMap = new Cell[BlockSize * BlockSize, BlockSize * BlockSize];

            for (int i = 0; i < BlockSize * BlockSize; i++)
            {
                for (int j = 0; j < BlockSize * BlockSize; j++)
                {
                    tMap[i, j] = _sudokuField[j, i];
                }
            }

            _sudokuField = tMap;
        }

        private void SwapBlocksInRow()
        {
            int block1 = Random.Range(0, BlockSize) * BlockSize;
            int block2 = Random.Range(0, BlockSize) * BlockSize;

            if (block1 != block2)
            {
                for (int i = 0; i < BlockSize * BlockSize; i++)
                {
                    int k = block2;
                    for (int j = block1; j < block1 + BlockSize; j++)
                    {
                        (_sudokuField[j, i], _sudokuField[k, i]) = (_sudokuField[k, i], _sudokuField[j, i]);
                        k++;
                    }
                }
            }
        }

        private void SwapBlocksInColumn()
        {
            int block1 = Random.Range(0, BlockSize) * BlockSize;
            int block2 = Random.Range(0, BlockSize) * BlockSize;

            if (block1 != block2)
            {
                for (int i = 0; i < BlockSize * BlockSize; i++)
                {
                    int k = block2;
                    for (int j = block1; j < block1 + BlockSize; j++)
                    {
                        (_sudokuField[i, j], _sudokuField[i, k]) = (_sudokuField[i, k], _sudokuField[i, j]);
                        k++;
                    }
                }
            }
        }

        private void SwapRowsInBlock()
        {
            int block = Random.Range(0, BlockSize) * BlockSize;
            int row1 = Random.Range(0, BlockSize);
            int row2 = Random.Range(0, BlockSize);

            if (row1 != row2)
            {
                for (int i = 0; i < BlockSize * BlockSize; i++)
                {
                    (_sudokuField[block + row1, i], _sudokuField[block + row2, i]) = (_sudokuField[block + row2, i], _sudokuField[block + row1, i]);
                }
            }
        }

        private void SwapColumnsInBlock()
        {
            int block = Random.Range(0, BlockSize) * BlockSize;
            int col1 = Random.Range(0, BlockSize);
            int col2 = Random.Range(0, BlockSize);

            if (col1 != col2)
            {
                for (int i = 0; i < BlockSize * BlockSize; i++)
                {
                    (_sudokuField[i, block + col1], _sudokuField[i, block + col2]) = (_sudokuField[i, block + col2], _sudokuField[i, block + col1]);
                }
            }
        }
        
        private void HideCells()
        {
            int totalCells = BlockSize * BlockSize;
            int cellsToHide = _cellsToHide;

            while (cellsToHide > 0)
            {
                int row = Random.Range(0, totalCells);
                int col = Random.Range(0, totalCells);

                if (_sudokuField[row, col].Value != 0)
                {
                    _sudokuField[row, col] = new Cell(0, true);
                    cellsToHide--;
                }
            }
        }
    }
}
