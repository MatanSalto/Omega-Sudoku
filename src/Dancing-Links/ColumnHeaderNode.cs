using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.DancingLinks
{
    /// <summary>
    /// This class represents a column header node, which is a regular
    /// dancing node with 2 additional fields
    /// </summary>
    public class ColumnHeaderNode : DancingNode
    {
        // The number of connected nodes in the current column
        public int size;

        // The name of the column
        public string name;
        
        public ColumnHeaderNode(string name) : base(this) {
            this.size = 0;
            this.name = name;
        } 

        /// <summary>
        /// This method performs the cover operation: unlinking all of the rows that
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
                rowPointer = rowPointer.down;
            }
        }

        /// <summary>
        /// This method performs the uncover operation: relinking all of the rows that are
        /// connected to the current column
        /// </summary>
        public void Uncover() {

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