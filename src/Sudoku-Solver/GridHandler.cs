using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Omega_Sudoku.src.SudokuSolver
{
    /// <summary>
    /// This class represents a GridHandler object.
    /// It is responsible for handling the input string and converting it to the desired binary matrix
    /// in order to use Algorithm X.
    /// </summary>
    public class GridHandler
    {

        private int _gridSize;
        private string _inputString;

        private InputStringToMatrixConvertor _stringToGridConvertor;
        private GridToExactCoverConvertor _gridToExactCoverConvertor;
        
        private GridHandler(int gridSize, string inputString) {
            this._gridSize = gridSize;
            this._inputString = inputString;
        }

        public int[, ] CreateExactCoverMatrix() {
            this._stringToGridConvertor = new InputStringToMatrixConvertor(_inputString, _gridSize);
            int[, ] grid = _stringToGridConvertor.ConvertToMatrix();

            this._gridToExactCoverConvertor = new GridToExactCoverConvertor(grid, _gridSize);
            int[, ] cover = _gridToExactCoverConvertor.CreateExactCoverMatrix();

            return cover;
        } 

        public static void Main(string[] args) {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            GridHandler gridHandler = new GridHandler(9, "800000070006010053040600000000080400003000700020005038000000800004050061900002000");
            
            int[,] cover = gridHandler.CreateExactCoverMatrix();

            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + " ms");

        }
    }
}