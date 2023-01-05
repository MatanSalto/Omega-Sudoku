using System;


namespace Omega_Sudoku.src.IO
{
    public class FileGridReader : IGridReader
    {
        public string Read() {
            Console.WriteLine("Enter the path to the file");
            string path = Console.ReadLine();
            
            // If the path exists
            if (File.Exists(path)) {
                return File.ReadAllLines(path)[0];
            }
            else {
                // TO-DO: Handle invalid path
                return null;
            }
        }
    }
}