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

            int startColumn = 0;

            // Fill the cell constraint
            FillCellConstraints(coverMatrix, ref startColumn);

            // Fill the column constraint
            FillColumnConstraints(coverMatrix, ref startColumn);

            // Fill the row constraint
            FillRowConstraints(coverMatrix, ref startColumn);

            // Fill the square constraint
            FillSquareConstraints(coverMatrix, startColumn);
            
            return coverMatrix;
        }

        private void FillCellConstraints(int [,] matrix, ref int startColumn) {
            
            // The current row in the cover matrix
            int currentRow = 0;

            // Loop through the cells of the grid
            for (int row = 0; row < _size; row++) {
                for (int col = 0; col < _size; col++) {

                    // Get the current value in the grid
                    int value = _grid[row, col];

                    // Loop through the possible numbers in the current cell
                    for (int number = 1; number <= _size; number++) {
                        // Put 1 only if the value is 0 or the number is the same as the value
                        if (value == 0 || number == value) {
                            matrix[currentRow, startColumn] = 1;
                        }  
                        currentRow++;
                    }
                    startColumn++;
                }
            }
        }

        private void FillColumnConstraints(int [,] matrix, ref int startColumn) {
            
            // The current row in the cover matrix
            int currentRow = 0;

            // Save the initial value of the starting column
            int columnConstraintStartColumn = startColumn;
            
            // Loop through the cells of the grid
            for (int row = 0; row < _size; row++) {
                startColumn = columnConstraintStartColumn;
                for (int col = 0; col < _size; col++) {

                    // Get the current value in the grid
                    int value = _grid[row, col];

                    // Loop through the possible numbers in the current cell
                    for (int number = 1; number <= _size; number++) {
                        // Put 1 only if the value is 0 or the number is the same as the value
                        if (value == 0 || number == value) {
                            matrix[currentRow, startColumn] = 1;
                        }
                        currentRow++;
                        startColumn++;
                    }         
                }
            }
        }

        private void FillRowConstraints(int [,] matrix, ref int startColumn) {
            
            // The current row in the cover matrix
            int currentRow = 0;

            // Loop through the cells of the grid
            for (int row = 0; row < _size; row++) {
                for (int col = 0; col < _size; col++) {

                    // Get the current value in the grid
                    int value = _grid[row, col];

                    // Loop through the possible numbers in the current cell
                    for (int number = 1; number <= _size; number++) {
                        // Put 1 only if the value is 0 or the number is the same as the value
                        if (value == 0 || number == value) {
                            matrix[currentRow, startColumn+number] = 1;
                        }
                        currentRow++;
                    }         
                }
                startColumn += _size;
            }
        }

        private void FillSquareConstraints(int [,] matrix, int startColumn) {

            // The current row in the cover matrix
            int currentRow = 0;

            // Loop through the cells of the grid
            for (int row = 0; row < _size; row++) {
                for (int col = 0; col < _size; col++) {

                    // Get the current value in the grid
                    int value = _grid[row, col];
                    
                    // calculate the square number (0 -> size)
                    int square = (row / (int)Math.Sqrt(_size)) * (int)Math.Sqrt(_size) + col / (int)Math.Sqrt(_size);

                    // Loop through the possible numbers in the current cell
                    for(int number = 1; number <= _size; number++) {
                        // Put 1 only if the value is 0 or the number is the same as the value
                        if (value == 0 || number == value) {
                            matrix[currentRow, startColumn + square * _size + number-1] = 1;
                        }
                        currentRow++;
                    }         
                }
            }
        }

        public static void Main(string[] args) {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            InputStringToMatrixConvertor convertor1 = new InputStringToMatrixConvertor("800000070006010053040600000000080400003000700020005038000000800004050061900002000100000027000304015500170683430962001900007256006810000040600030012043500058001000", 9);
            int [,] grid = convertor1.ConvertToMatrix();

            GridToExactCoverConvertor convertor = new GridToExactCoverConvertor(grid , 9);
            int[,] cover = convertor.CreateEmptyExactCoverMatrix();


            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}   