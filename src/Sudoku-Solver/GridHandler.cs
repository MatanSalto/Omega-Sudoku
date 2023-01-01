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
        
        public GridHandler(int gridSize, string inputString) {
            this._gridSize = gridSize;
            this._inputString = inputString;
        }

        public byte[, ] CreateExactCoverMatrix() {
            this._stringToGridConvertor = new InputStringToMatrixConvertor(_inputString, _gridSize);
            byte[, ] grid = _stringToGridConvertor.ConvertToMatrix();

            this._gridToExactCoverConvertor = new GridToExactCoverConvertor(grid, _gridSize);
            byte[, ] cover = _gridToExactCoverConvertor.CreateExactCoverMatrix();

            return cover;
        } 

    }
}