using System;
using System.Collections.Generic;


namespace Omega_Sudoku.src.DancingLinks
{
    /// <summary>
    /// This class represents a dancing node (a node with 4 connections)
    /// </summary>
    public class DancingNode
    {
        public DancingNode left, right, up, down;
        public ColumnHeaderNode header;

        /// <summary>
        /// Constructor for the DancingNode class
        /// </summary>
        /// <param name="header">The column header node</param>
        public DancingNode(ColumnHeaderNode header) {
            // Initialize the connections to point at the current node
            this.left = this.right = this.up = this.down = this;
            // Set the column header node
            this.header = header;
        }

        /// <summary>
        /// This method links the given node to the right of the current node
        /// </summary>
        /// <param name="node">The node to connect to the right</param>
        public void LinkRight(DancingNode node) {
            node.right = this.right;
            this.right.left = node;
            this.right = node;
            node.left = this;
        }

        /// <summary>
        /// This method links the given node to the left of the current node
        /// </summary>
        /// <param name="node">The node to connect to the right</param>
        public void LinkDown(DancingNode node) {
            node.down = this.down;
            this.down.up = node;
            this.down = node;
            node.up = this;
        }

        /// <summary>
        /// This method cancels the connections of the 
        /// left and right nodes to the current node
        /// </summary>
        public void UnlinkLeftRight() {
            this.right.left = this.left;
            this.left.right = this.right;
        }

        /// <summary>
        /// This method cancels the connections of the 
        /// up and down nodes to the current node
        /// </summary>
        public void UnlinkUpDown() {
            this.down.up = this.up;
            this.up.down = this.down;
        }

        /// <summary>
        /// This method relinks the current node to the nodes 
        /// to its right and left
        /// </summary>
        public void RelinkLeftRight() {
            this.left.right = this.right.left = this;
        }

        /// <summary>
        /// This method relinks the current node to the nodes
        /// to its up and down
        /// </summary>
        public void RelinkUpDown() {
            this.up.down = this.down.up = this;
        }
    }
}