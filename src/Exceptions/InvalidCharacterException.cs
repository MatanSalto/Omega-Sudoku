using System;

namespace Omega_Sudoku.src.Exceptions
{
    /// <summary>
    /// This class represents the Invalid Character Exception,
    /// that is thrown when the user enters a non-valid character
    /// (like 5 in a 4X4 board)
    /// </summary>
    public class InvalidCharacterException : Exception
    {
        /// <summary>
        /// Constructor for the InvalidCharacterException class
        /// </summary>
        /// <param name="message">The string to output</param>
        /// <returns></returns>
        public InvalidCharacterException(string message) : base(message) { }

        /// <summary>
        /// Constructor for the InvalidCharacterException
        /// </summary>
        /// <param name="ch">The non-valid char that was enters</param>
        /// <returns></returns>
        public InvalidCharacterException(char ch) : this("The char '" + ch + "' is not valid in the current sudoku board size") { }
    }
}