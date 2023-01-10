using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using System.Collections;
using System;

namespace Omega_Sudoku.src.DancingLinks
{
    /// <summary>
    /// This class is responsible for the implementation of Algorithm X in order to solve
    /// the exact cover problem
    /// </summary>
    public class DancingLinksSolver
    {
        // The list representing the nodes that are included in the solution
        private Stack<DancingNode> _solution;

        // The DLX cover problem list to solve
        private ColumnHeaderNode _root;


        public DancingLinksSolver(ColumnHeaderNode root) {
            this._root = root;
            this._solution = new Stack<DancingNode>();
        }

        public Stack<DancingNode> Solve() {
            this.Search(0);
            return this._solution;
        }

        public bool Search(int k) {
            // If there are no more columns, we reached a solution, so return true
            if (_root.right == _root) {
                return true;
            }

            // Else, choose the column and cover it
            ColumnHeaderNode column = this.SelectColumnHeaderNode();
            column.Cover();

            // Traverse the nodes in the chosen column
            DancingNode rowPointer = column.down;
            while (rowPointer != column) {
                // Add the current node to the solution
                _solution.Push(rowPointer);

                // Cover all of the columns that are connected to the current row
                DancingNode nodePointer = rowPointer.right;
                while (nodePointer != rowPointer) {
                    nodePointer.header.Cover();
                    nodePointer = nodePointer.right;
                }

                // Call the function recursively
                if (Search(k+1)) {
                    return true;
                }

                // Get the last node in the solution and its column
                rowPointer = _solution.Pop();
                column = rowPointer.header;

                // Uncover all of the columns that are connected to the current row
                nodePointer = rowPointer.left;
                while (nodePointer != rowPointer) {
                    nodePointer.header.Uncover();
                    nodePointer = nodePointer.left;
                }

                rowPointer = rowPointer.down;
            }
            // Uncover the current column
            column.Uncover();
            return false;
        }

        public ColumnHeaderNode SelectColumnHeaderNode() {
            // The header node with the minimum value
            ColumnHeaderNode minColumnNode = (ColumnHeaderNode) _root.right;
            // A pointer to traverse the headers
            ColumnHeaderNode columnPointer = (ColumnHeaderNode) _root.right;

            // Traverse the headers
            while (columnPointer != _root) {
                // If the current header's value is smaller than the min, 
                // set it as the min node
                if (columnPointer.size < minColumnNode.size) {
                    minColumnNode = columnPointer;
                }
                columnPointer = (ColumnHeaderNode) columnPointer.right;
            }

            return minColumnNode;
        }
    } 
}