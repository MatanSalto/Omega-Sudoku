using System;


namespace Omega_Sudoku.src.IO
{
    /// <summary>
    /// This interface represents a Grid Writer,
    /// which has the Write method
    /// </summary>
    public interface IGridWriter
    {
        /// <summary>
        /// This method writes the output
        /// </summary>
        /// <param name="s">The string to output</param>
        public void Write(string s);
    }
}