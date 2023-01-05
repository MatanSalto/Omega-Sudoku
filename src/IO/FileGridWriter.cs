using System;

namespace Omega_Sudoku.src.IO
{
    public class FileGridWriter : ConsoleGridWriter
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