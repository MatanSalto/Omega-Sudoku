using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.IO
{
    public class ConsoleGridWriter : IGridWriter
    {
        public void Write(string s) {
            Console.WriteLine(s);
        }
    }
}