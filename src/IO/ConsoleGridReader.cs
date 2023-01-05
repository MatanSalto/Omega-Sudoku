using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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