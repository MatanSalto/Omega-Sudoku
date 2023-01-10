using System.ComponentModel;
using System.Xml;
using System.Reflection.Metadata;
using System.Threading.Tasks.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omega_Sudoku.src.DancingLinks;
using System.Diagnostics;


namespace Omega_Sudoku.src.SudokuSolving
{
    public class Solver
    {
        public Solver() { }
        public string Solve(string input) {
            // Create a new InputString object
            InputStringBoard inputStringBoard = new InputStringBoard(input);

            // Convert to string to a matrix
            SudokuBoard board = new SudokuBoard(inputStringBoard.ConvertToMatrix(), inputStringBoard.size);
            // Validate the board
            board.ValidateBoard();
            
            // Convert to exact covert matrix
            ExactCoverMatrix cover = new ExactCoverMatrix(board.CreateExactCoverMatrix());

            // Create a DLX solver with the DLX representation of the cover
            DancingLinksSolver solver = new DancingLinksSolver(cover.ConvertToDLXRepresentation());

            // Create a solution handler
            SolutionHandler solutionHandler = new SolutionHandler(solver.Solve(), inputStringBoard.size);

            // Get the string representing the solution
            string solution = solutionHandler.ConvertToString();

            // Return the solution string
            return solution;
        }
    }
}