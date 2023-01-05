using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.SudokuSolver
{
    /// <summary>
    /// This class represents a String to Matrix convertor. 
    /// It is responsible for converting the input string into a matrix
    /// representing the sudoku grid.
    /// </summary>
    public class InputStringBoard
    {
        // The input string to convert
        private string _string;

        // The size of the desired matrix
        private int _size;

        public InputStringBoard(string inputString, int size) {
            this._string = inputString;
            this._size = size;
        }

        public byte[,] ConvertToMatrix() {
            // Initialize the matrix
            byte[,] matrix = new byte[this._size, this._size];

            int length = this._string.Length;

            // if the length of the string is not equal to the size^2, raise an exception
            if (length != this._size * this._size) {
                // TO-DO: handle invalid size
                Console.WriteLine("INVALID LENGTH");
            }

            // initialize the row and column indcies in the matrix
            int currentRow = 0, currentCol = 0;
            
            // Loop through the characters in the input strchromeing
            for (int i = 0; i < length; i++) {
                // Get the current digit and convert it to int
                byte value = (byte) (_string[i] - '0');

                // if the current char in the valid range, raise an exception
                if (value < 0 || value > _size) {
                    // TO-DO: handle invalid character
                    Console.WriteLine("INVALID CHAR");
                }

                // Place the value in the current place in the matrix
                matrix[currentRow, currentCol] = value;

                // Calculate the indices of the next cell
                currentRow = currentRow + ((currentCol + 1) / this._size);
                currentCol = (currentCol + 1) % this._size;
            }

            return matrix;
        }
    }
}