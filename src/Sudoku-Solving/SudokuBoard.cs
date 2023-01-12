using System;
using Omega_Sudoku.src.Exceptions;


namespace Omega_Sudoku.src.SudokuSolving
{
    /// <summary>
    /// This class represents a Sudoku Board object,
    /// which is responsible for converting the board into an
    /// excact cover problem
    /// </summary>
    public class SudokuBoard
    {
        // The 2D array representing the sudoku grid
        private byte[, ] _grid;
        // The size of the board
        private int _size;
        // The number of constraints there are
        private const int NUMBER_OF_CONSTRAINTS = 4;

        /// <summary>
        /// Constructor for the SudokuBoard class
        /// </summary>
        /// <param name="grid">The 2D array representing the board</param>
        /// <param name="size">The size of the board</param>
        public SudokuBoard(byte[, ] grid, int size) 
        {
            this._grid = grid;
            this._size = size;   
        }

        /// <summary>
        /// Thie method validates the board according to the rules of Sudoku
        /// </summary>
        public void ValidateBoard()
        {
            byte[,] rows = new byte[_size, _size];
            byte[,] cols = new byte[_size, _size];
            byte[,] squares = new byte[_size, _size];

            // Loop through the cells of the given sudoku board
            for(int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    // Get the number at the current cell
                    int number = _grid[row, col];

                    // Get the current square
                    int square = (row / (int)Math.Sqrt(_size)) * (int)Math.Sqrt(_size) + col / (int)Math.Sqrt(_size);

                    // If the current cell is not empty,
                    // fill the rows, cols, and sqaures arrays
                    if (number != 0)
                    {
                        // If the number doesn't appear in the current row, col and square
                        if (rows[row, number-1] == 0 && cols[col, number-1] == 0 && squares[square, number-1] == 0)
                        {
                            // Fill the number
                            rows[row, number-1] = 1;
                            cols[col, number-1] = 1;
                            squares[square, number-1] = 1;
                        }
                        // If the number already exists in the current row/col/square
                        // raise an exception
                        else
                        {
                           throw new InvalidBoardException();
                        }
                    }
                }
            }
        }

        public byte[,] CreateExactCoverMatrix()
        {
            // Initialize the cover matrix
            byte[,] coverMatrix = new byte[_size*_size*_size, _size*_size*NUMBER_OF_CONSTRAINTS];

            // The current row in the cover matrix
            int currentRow = 0;

            // The current column for the cell constraint
            int currentCellConstraintColumn = 0;
            // The current column for the column constraint
            int currentColumnConstraintColumn = _size * _size;
            // The current column for the row constraint
            int currentRowConstraintColumn = 2 * _size * _size;
            // The current column for the square constraint
            int currentBoxConstraintColumn = 3 * _size * _size;


            // Loop through the cells of the grid
            for (int row = 0; row < _size; row++)
            {
                // Move the column constraint column back to the start
                currentColumnConstraintColumn = _size * _size;

                for (int col = 0; col < _size; col++)
                {

                    // Get the current value in the grid
                    int value = _grid[row, col];

                    // Get the current box number (1 -> size)
                    int square = (row / (int)Math.Sqrt(_size)) * (int)Math.Sqrt(_size) + col / (int)Math.Sqrt(_size);

                    // Loop through the possible numbers in the current cell
                    for (byte number = 1; number <= _size; number++)
                    {
                        // Put a 1 only if the value is 0 or the number is the same as the value
                        if (value == 0 || number == value)
                        {

                            // Fill the cell constraint
                            coverMatrix[currentRow, currentCellConstraintColumn] = 1;

                            // Fill the column constraint
                            coverMatrix[currentRow, currentColumnConstraintColumn] = 1;

                            // Fill the row constraint
                            coverMatrix[currentRow, currentRowConstraintColumn + number-1] = 1;

                            // Fill the square constraint
                            coverMatrix[currentRow, currentBoxConstraintColumn + square * _size + number-1] = 1;
                        }
                        currentRow++;
                        currentColumnConstraintColumn++;
                    }
                    currentCellConstraintColumn++;
                }
                currentRowConstraintColumn += _size;
            }
            return coverMatrix;
        }
    }
}   