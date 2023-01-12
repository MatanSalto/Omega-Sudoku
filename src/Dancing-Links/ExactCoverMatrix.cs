using System;
using System.Collections.Generic;


namespace Omega_Sudoku.src.DancingLinks
{
    /// <summary>
    /// This class represents the exact cover matrix representation of the board
    /// </summary>
    public class ExactCoverMatrix
    {
        // The input grid
        private byte[,] _matrix;

        /// <summary>
        /// Constructor for the ExactCoverMatrix class
        /// </summary>
        /// <param name="grid">The input exact cover matrix</param>
        public ExactCoverMatrix(byte[,] grid) {
            this._matrix = grid;
        }

        /// <summary>
        /// This method converts the byte cover matrix into DLX representation
        /// </summary>
        /// <returns></returns>
        public ColumnHeaderNode ConvertToDLXRepresentation() {
            // Create the root node
            ColumnHeaderNode root = new ColumnHeaderNode("Root");

            // Create the header nodes and save them in an array
            ColumnHeaderNode[] headers = new ColumnHeaderNode[_matrix.GetLength(1)];
            for (int i = 0; i < _matrix.GetLength(1); i++) {
                // Create the new header node
                ColumnHeaderNode currentHeader = new ColumnHeaderNode(i.ToString());
                headers[i] = currentHeader;

                // Link the current header to the rest
                root.LinkRight(currentHeader);
                root = (ColumnHeaderNode) currentHeader;                
            }

            // Get the root node again
            root = (ColumnHeaderNode) root.right.header;

            // Loop through the rows of the matrix
            for (int i = 0; i < _matrix.GetLength(0); i++) {
                // The previous node in the current row
                DancingNode? previousNode = null;

                // Loop through the cells in the current row
                for (int j = 0; j < _matrix.GetLength(1); j++) {
                    // If the cell is not empty
                    if (_matrix[i, j] == 1) {
                        // Get the header node of the current column
                        ColumnHeaderNode currentHeader = headers[j];
                        // Create a new Dancing Node
                        DancingNode newNode = new DancingNode(currentHeader);
                        // Connect the node to its column
                        currentHeader.up.LinkDown(newNode);
                        // If the previous node is null, set the current node to be the previous
                        if (previousNode == null) {
                            previousNode = newNode;
                        }
                        // Else, connect the current node to the previous and update the previous
                        else {
                            previousNode.LinkRight(newNode);
                            previousNode = previousNode.right;
                        }
                        // Update the size field of the current header
                        currentHeader.size++;
                    }
                } 
            }
            // Return the DLX list
            return root;
        }
    }
}