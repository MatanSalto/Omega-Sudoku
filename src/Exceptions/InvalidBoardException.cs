using System;


namespace Omega_Sudoku.src.Exceptions
{
    public class InvalidBoardException: Exception
    {
        public InvalidBoardException() : base("The given sudoku board is invalid") { }
    }
}

