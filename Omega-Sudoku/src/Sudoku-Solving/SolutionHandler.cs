using System.Numerics;
using System;
using System.Collections.Generic;
using Omega_Sudoku.src.Exceptions;
using Omega_Sudoku.src.DancingLinks;

namespace Omega_Sudoku.src.SudokuSolving
{
    /// <summary>
    /// This class is responsible for converting the solution stack to
    /// a string
    /// </summary>
    public class SolutionHandler
    {
        // The size of the output grid
        private int _size;

        // The input DLX list
        private Stack<DancingNode> _solution;

        /// <summary>
        /// Constructor for the SolutionHandler class
        /// </summary>
        /// <param name="solution">The stack of nodes representing the solution</param>
        /// <param name="size">The size of the board</param>
        public SolutionHandler(Stack<DancingNode> solution, int size) {
            this._size = size;
            this._solution = solution;
        }

        /// <summary>
        /// This method converts the stack of nodes to its string board representation
        /// </summary>
        /// <returns>A string representing the solution board</returns>
        public string ConvertToString() {
            // Get the grid representation of the solution
            int[, ] grid = ConvertToGrid();

            // Convert the matrix to string
            string outputString = "";
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    // Append the current char to the string
                    outputString = outputString +  " " + (char)(grid[i, j] + '0') + " ";
                }
                // Move down a line
                outputString = outputString + "\n";
            }
            // Return the result string
            return outputString;
        }

        /// <summary>
        /// This method converts the solution stack to a 2D array representing the solution
        /// </summary>
        /// <returns>A 2D array representing the solution board</returns>
        private int[,] ConvertToGrid() {

            // Initialize the output grid
            int[, ] grid = new int[_size, _size];
            
            // If the stack is empty, raise an exception (no solution)
            if (_solution.Count == 0)
            {
                throw new UnsolvableBoardException("The given sudoku board is unsolvable");
            }

            // Loop through the nodes in the list
            while (_solution.Count != 0) {
                DancingNode node = _solution.Pop();
                // Find the first node in the row (the node whose column is the smallest)
                DancingNode firstNode = node;
                DancingNode nodePointer = node.right;

                // Get the first column of the row
                while (nodePointer != node) {
                    if (Int128.Parse(nodePointer.header.name) < Int128.Parse(firstNode.header.name)) {
                        firstNode = nodePointer;
                    }
                    nodePointer = nodePointer.right;
                }

                // Get the names of the first and second headers
                int firstColumnName = (int) Int128.Parse(firstNode.header.name);
                int secondColumnName = (int) Int128.Parse(firstNode.right.header.name);

                // Calculate the indices in the grid and the number to put
                int row = firstColumnName / _size;
                int col = firstColumnName % _size;
                int num = secondColumnName % _size + 1;

                // Place the number in the grid
                grid[row, col] = num;
            }
            // Return the result grid
            return grid;
        }
    }
}