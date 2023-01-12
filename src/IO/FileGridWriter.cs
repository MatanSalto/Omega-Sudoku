using System;

namespace Omega_Sudoku.src.IO
{
    /// <summary>
    /// This class represents an object that is responsible
    /// for writing strings into a file.
    /// It inherits from ConsoleGridWriter because the output 
    /// should be written to console before written to the file
    /// </summary>
    public class FileGridWriter : ConsoleGridWriter
    {
        /// <summary>
        /// This method writes the string into a file
        /// </summary>
        /// <param name="s"></param>
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