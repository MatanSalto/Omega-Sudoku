using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Omega_Sudoku.src.DancingLinks
{
    /// <summary>
    /// This class represents a column header node, which is the node that holds the nodes below it
    /// </summary>
    public class ColumnHeaderNode : DancingNode
    {
        // The number of connected nodes in the current column
        public int size;

        // The name of the column
        public string name;
        
        /// <summary>
        /// Constructor for the ColumnHeaderNode class
        /// </summary>
        /// <param name="name">The name of the column</param>
        /// <returns></returns>
        public ColumnHeaderNode(string name) : base(null) {
            this.size = 0;
            this.name = name;
            this.header = this;
        } 

        /// <summary>
        /// This method performs the Cover operation: unlinking all of the rows that
        /// are connected to the current column
        /// </summary>
        public void Cover() { 
            // Unlink the column header node
            this.UnlinkLeftRight();
            DancingNode rowPointer = this.down;

            // Traverse the nodes in the current column
            while (rowPointer != this) {
                // Traverse the nodes that are connected to the current row node
                DancingNode nodePointer = rowPointer.right;
                while (rowPointer != nodePointer) {
                    // Unlink the current node from its column and update its column's size
                    nodePointer.UnlinkUpDown();
                    nodePointer.header.size--;
                    nodePointer = nodePointer.right;
                }
                // Move to the next node (down)
                rowPointer = rowPointer.down;
            }
        }

        /// <summary>
        /// This method performs the Uncover operation: relinking all of the rows that are
        /// connected to the current column
        /// </summary>
        public void Uncover() {
            // Get the pointer to the last row
            DancingNode rowPointer = this.up;

            // Traverse the nodes in the current column
            while (rowPointer != this) {
                // Traverse the nodes that are connected to the current row node
                DancingNode nodePointer = rowPointer.left;
                while (nodePointer != rowPointer) {
                    // Relink the current node to its column and update its column's size
                    nodePointer.RelinkUpDown();
                    nodePointer.header.size++;
                    nodePointer = nodePointer.left;
                }
                rowPointer = rowPointer.up;
            }
            // Relink the column header node
            this.RelinkLeftRight(); 
        }
    }
}