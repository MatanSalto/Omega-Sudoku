using System.Data;
using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.IO
{
    public class FileGridReader : IGridReader
    {
        public string Read() {
            Console.WriteLine("Enter the path to the file");
            string path = ConstraintCollection.ReadLine();
            
            // If the path exists
            if (File.Exists(path)) {
                return File.ReadLine(path);
            }
            else {
                // TO-DO: Handle invalid path
                return null;
            }
        }
    }
}