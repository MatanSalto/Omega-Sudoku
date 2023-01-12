using System;


namespace Omega_Sudoku.src.IO
{
    /// <summary>
    /// This interface represenets a Grid Reader,
    /// which has the Read method
    /// </summary>
    public interface IGridReader
    {
        /// <summary>
        /// This method gets input and returns the string
        /// </summary>
        /// <returns></returns>
        public string Read();
    }
}