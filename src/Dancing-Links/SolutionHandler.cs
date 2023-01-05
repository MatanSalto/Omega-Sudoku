using System.Threading.Tasks.Dataflow;
using System.Xml;
using System.Numerics;
using System.Reflection.Metadata;
using System.Collections.Specialized;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omega_Sudoku.src.SudokuSolver;
using System.Diagnostics;

namespace Omega_Sudoku.src.DancingLinks
{
    public class SolutionHandler
    {
        // The size of the output grid
        private int _size;

        // The input DLX list
        private Stack<DancingNode> _solution;


        public SolutionHandler(int size, Stack<DancingNode> solution) {
            this._size = size;
            this._solution = solution;
        }

        public string ConvertToString() {
            // Get the grid representation of the solution
            int[, ] grid = ConvertToGrid();

            // Convert the matrix to string
            outputString = "";
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    outputString = outputString +  " " + grid[i, j] + " ";
                }
                outputString = outputString + "\n";
            }

            return outputString;
        }

        private string ConvertToGrid() {

            // Initialize the output grid
            int[, ] grid = new int[_size, _size];

            // Loop through the nodes in the list
            while (_solution.Count != 0) {
                DancingNode node = _solution.Pop();
                // Find the first node in the row (the node whose column is the smallest)
                DancingNode firstNode = node;
                DancingNode nodePointer = node.right;

                while (nodePointer != node) {
                    if ( Int128.Parse(nodePointer.header.name) < Int128.Parse(firstNode.header.name)) {
                        firstNode = nodePointer;
                    }
                    nodePointer = nodePointer.right;
                }

                // Get the names of the first and second headers
                int firstColumnName = (int) Int128.Parse(firstNode.header.name);
                int secondColumnName = (int) Int128.Parse(firstNode.right.header.name);

                // Calculate the indices in the grid and the number
                int row = firstColumnName / _size;
                int col = firstColumnName % _size;
                int num = secondColumnName % _size + 1;

                // Place the number in the grid
                grid[row, col] = num;
            }

            return grid;
        }

    }
}