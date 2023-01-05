using System;

namespace Omega_Sudoku.src.IO
{
    public class ConsoleGridReader : IGridReader
    {
        public string Read() {
            Console.WriteLine("Enter the string");
            return Console.ReadLine();
        }
    }
}