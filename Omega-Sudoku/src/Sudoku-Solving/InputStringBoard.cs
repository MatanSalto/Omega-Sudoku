using System;
using Omega_Sudoku.src.Exceptions;


namespace Omega_Sudoku.src.SudokuSolving
{
    /// <summary>
    /// This class represents the Input String object,
    /// which is responsible for converting the string to a matrix
    /// </summary>
    public class InputStringBoard
    {
        // The input string to convert
        private string _string;
        // The size of the desired matrix
        public int size;

        /// <summary>
        /// Constructor for the InputStringBoard class
        /// </summary>
        /// <param name="inputString">The string representing the grid</param>
        public InputStringBoard(string inputString) {
            this._string = inputString;
            this.size = 0;
        }

        /// <summary>
        /// This method converts the input string to a 
        /// grid representing the grid
        /// </summary>
        /// <returns></returns>
        public byte[,] ConvertToMatrix() {

            // Get the length of the string
            int length = this._string.Length;

            // if the size of the board is not a perfect square, raise an exception
            if (Math.Sqrt(Math.Sqrt(length)) % 1 != 0) {
                throw new InvalidLengthException(length);
            }

            // Get the size of the board
            this.size = (int) Math.Sqrt(length);

            // Initialize the matrix
            byte[,] matrix = new byte[this.size, this.size];

            // initialize the row and column indcies in the matrix
            int currentRow = 0, currentCol = 0;
            
            // Loop through the characters in the input strchromeing
            for (int i = 0; i < length; i++) {
                // Get the current digit and convert it to int
                byte value = (byte) (_string[i] - '0');

                // if the current char in the valid range, raise an exception
                if (value < 0 || value > size) {
                    throw new InvalidCharacterException(_string[i]);
                }

                // Place the value in the current place in the matrix
                matrix[currentRow, currentCol] = value;

                // Calculate the indices of the next cell
                currentRow = currentRow + ((currentCol + 1) / this.size);
                currentCol = (currentCol + 1) % this.size;
            }

            // Return the grid
            return matrix;
        }
    }
}