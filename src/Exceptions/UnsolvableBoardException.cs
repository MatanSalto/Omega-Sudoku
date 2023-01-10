using System;


namespace Omega_Sudoku.src.Exceptions
{
    public class UnsolvableBoardException : Exception
    {
        public UnsolvableBoardException(string message) : base(message) { }

    }
}

