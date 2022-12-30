using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.SudokuSolver
{
    public class GridToExactCoverConvertor
    {
        // The 2D array representing the sudoku grid
        private int[, ] _grid;
        // The size of the board
        private int _size;

        // The number of constraints there are
        private const int NUMBER_OF_CONSTRAINTS = 4;


        public GridToExactCoverConvertor(int[, ] grid, int size) {
            this._grid = grid;
            this._size = size;   
        }

        public int[, ] CreateEmptyExactCoverMatrix() {
            // Initialize the cover matrix
            int [, ] coverMatrix = new int[_size*_size*_size, _size*_size*NUMBER_OF_CONSTRAINTS];

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
            for (int row = 0; row < _size; row++) {
                
                // Move the column constraint column back to the start
                currentColumnConstraintColumn = _size * _size;

                for (int col = 0; col < _size; col++) {

                    // Get the current value in the grid
                    int value = _grid[row, col];

                    // Get the current box number (1 -> size)
                    int square = (row / (int)Math.Sqrt(_size)) * (int)Math.Sqrt(_size) + col / (int)Math.Sqrt(_size);

                    // Loop through the possible numbers in the current cell
                    for (int number = 1; number <= _size; number++) {
                        // Put a 1 only if the value is 0 or the number is the same as the value
                        if (value == 0 || number == value) {

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

        public static void Main(string[] args) {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            InputStringToMatrixConvertor convertor1 = new InputStringToMatrixConvertor("800000070006010053040600000000080400003000700020005038000000800004050061900002000", 9);
            int [,] grid = convertor1.ConvertToMatrix();

            GridToExactCoverConvertor convertor = new GridToExactCoverConvertor(grid , 9);
            int[,] cover = convertor.CreateEmptyExactCoverMatrix();

            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + " ms");

        }
    }
}   