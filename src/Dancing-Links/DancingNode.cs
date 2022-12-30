using System.ComponentModel.Design.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.DancingLinks
{
    /// <summary>
    /// This class represents a dancing node (a node with 4 connections)
    /// </summary>
    public class DancingNode
    {
        public DancingNode left, right, up, down;
        public ColumnHeaderNode header;

        public DancingNode(ColumnHeaderNode header) {
            // Initialize the linked nodes to null
            this.left = this.right = this.up = this.down = null;
            // Set the column header node
            this.header = header;
        }

        public void LinkRight(DancingNode node) {
            node.right = this.right;
            this.right.left = node;
            this.right = node;
            node.left = this;
        }

        public void LinkDown(DancingNode node) {
            node.down = this.down;
            this.down.up = node;
            this.down = n1;
            n1.up = this;
        }

        protected void UnlinkLeftRight() {
            this.right.left = this.left;
            this.left.right = this.right;
        }

        protected void UnlinkUpDown() {
            this.down.up = this.up;
            this.up.down = this.down;
        }

        protected void RelinkLeftRight() {
            this.left.right = this.right.left = this;
        }

        protected void RelinkUpDown() {
            this.up.down = this.down.up = this;
        }
    }
}