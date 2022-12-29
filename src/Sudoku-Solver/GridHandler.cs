using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.SudokuSolver
{
    /// <summary>
    /// This class represents a GridHandler object.
    /// It is responsible for handling the input string and converting it to the desired binary matrix
    /// in order to use Algorithm X.
    /// This object is a Singleton - only one instance of it is necessary in the program.
    /// </summary>
    public class GridHandler
    {
        // Reference for the object's instance.
        private static GridHandler _instance = null;
        private int gridSize;
        
        private GridHandler() {
            
        }

        public static GridHandler GetInstance() {
            // If the instance is null (first time asking for the instance), 
            // create a new instance of the object and return it.
            if (_instance == null) {
                _instance = new GridHandler();
                return _instance;
            }
            // Else, return the existing instance
            return _instance;
        }
    }
}