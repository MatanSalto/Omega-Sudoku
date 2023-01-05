using System;


namespace Omega_Sudoku.src.IO
{
    public class ConsoleGridWriter : IGridWriter
    {
        public virtual void Write(string s) {
            Console.WriteLine(s);
        }
    }
}