#pragma warning disable CS8600

using System;


namespace Omega_Sudoku.src.IO
{
    /// <summary>
    /// This class represents an object that is responsible
    /// for getting input from a file
    /// </summary>
    public class FileGridReader : IGridReader
    {
        /// <summary>
        /// This method gets input from a file
        /// </summary>
        /// <returns></returns>
        public string Read() {
            Console.WriteLine("Enter the path to the file");
            string path = Console.ReadLine();
            
            // Ask for the path again until it exists
            while (!File.Exists(path)) {
                Console.WriteLine("The file was not found. Enter the path again: ");
                path = Console.ReadLine();
            }
            return File.ReadAllLines(path)[0];
        }
    }
}