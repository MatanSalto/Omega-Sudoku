using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.IO
{
    public class FileGridWriter : ConsoleGridReader, IGridWriter
    {
        public override void Write(string s) {
            // First, write to console
            base.Write(s);

            // Write to the file named "Solution.txt"
            using (StreamWriter outputFile = new StreamWriter("Solution.txt")) {
                outputFile.WriteLine(s);
            }
        }
    }
}