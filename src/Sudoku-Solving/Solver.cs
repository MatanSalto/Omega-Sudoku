using System;
using Omega_Sudoku.src.DancingLinks;


namespace Omega_Sudoku.src.SudokuSolving
{
    /// <summary>
    /// This class represents a Solver object,
    /// which is responsible for solving the sudoku board
    /// </summary>
    public class Solver
    {
        /// <summary>
        /// Constructor for the Solver class
        /// </summary>
        public Solver() { }

        /// <summary>
        /// This method implements the pipeline for solving
        /// the sudoku board
        /// </summary>
        /// <param name="input">The input string to solve</param>
        /// <returns>A string representing the solution</returns>
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