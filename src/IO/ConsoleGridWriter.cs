using System;


namespace Omega_Sudoku.src.IO
{
    /// <summary>
    /// This class represents an object that is responsible for
    /// output strings to the console
    /// </summary>
    public class ConsoleGridWriter : IGridWriter
    {
        /// <summary>
        /// This method outputs string to the console
        /// </summary>
        /// <param name="s">The string to output</param>
        public virtual void Write(string s) {
            Console.WriteLine(s);
        }
    }
}