#pragma warning disable CS8603

using System;

namespace Omega_Sudoku.src.IO
{
    /// <summary>
    /// This class represents an object that is responsible for getting
    /// input from the console
    /// </summary>
    public class ConsoleGridReader : IGridReader
    {
        /// <summary>
        /// This method reads input from the console
        /// </summary>
        /// <returns></returns>
        public string Read() {
            Console.WriteLine("Enter the string");
            return Console.ReadLine();
        }
    }
}