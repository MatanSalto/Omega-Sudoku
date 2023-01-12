using System;


namespace Omega_Sudoku.src.Exceptions
{
    /// <summary>
    /// This class represents the Unsolvable Board Exception,
    /// that is thrown when the input board has no solution
    /// </summary>
    public class UnsolvableBoardException : Exception
    {
        /// <summary>
        /// Constructor for the  UnsolvableBoardException
        /// </summary>
        /// <param name="message">The string to output</param>
        /// <returns></returns>
        public UnsolvableBoardException(string message) : base(message) { }

    }
}

