using System.ComponentModel;
using System.Xml;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Threading.Tasks.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.Sudoku-Solver
{
    public static class Solver
    {
        public static void Solve(string s) {
            // Create a new InputString object
            InputStringBoard inputStringBoard = new InputStringBoard(s);
            // Convert to string to a matrix
            SudokoBoard board = new SudokoBoard(inputStringBoard.ConvertToMatrix());
            // Convert to exact covert matrix
            ExactCoverMatrix cover = new ExactCoverMatrix(board.CreateExactCoverMatrix());
            // Create a DLX solver with the DLX representation of the cover
            DancingLinksSolver solver = new DancingLinksSolver(cover.ConvertToDLXRepresentation());
            // Create a solution handler
            SolutionHandler solutionHandler = new SolutionHandler(solver.Solve());
        }
    }
}