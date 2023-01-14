using System;


namespace Omega_Sudoku.src.Exceptions
{
    /// <summary>
    /// This class represents the Invalid Board Exception,
    /// that is thrown when the user enters a board that doesn't obey 
    /// the rules of sudoku (duplicate number in the same row, etc.)
    /// </summary>
    public class InvalidBoardException: Exception
    {
        /// <summary>
        /// Constructor for the InvalidBoardException Class
        /// </summary>
        /// <returns></returns>
        public InvalidBoardException() : base("The given sudoku board is invalid") { }
    }
}

