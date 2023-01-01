using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omega_Sudoku.src.SudokuSolver;
using System.Diagnostics;

namespace Omega_Sudoku.src.DancingLinks
{
    public class DLXToGridConvertor
    {
        // The size of the output grid
        private int _size;

        // The input DLX list
        private Stack<DancingNode> _list;


        public DLXToGridConvertor(int size, Stack<DancingNode> list) {
            this._size = size;
            this._list = list;
        }

        public int[, ] ConvertToGrid() {

            // Initialize the output grid
            int[, ] grid = new int[_size, _size];

            // Loop through the nodes in the list
            while (_list.Count != 0) {
                DancingNode node = _list.Pop();
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

        
        public static void Main(string[] args) {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            GridHandler gridHandler = new GridHandler(16, "1000000000000000000000000000100000000000000000000000000000000000000000000000000000000000000000000000000000000000020000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001");
            
            byte[,] cover = gridHandler.CreateExactCoverMatrix();


            CoverMatrixToDLXConvertor convertor = new CoverMatrixToDLXConvertor(cover);
            ColumnHeaderNode root = convertor.CreateDLXRepresentation();

            AlgorithmX algo = new AlgorithmX(root, 16);
            Stack<DancingNode> answer = algo.Solve();

            DLXToGridConvertor convertor1 = new DLXToGridConvertor(16, answer);
            int[,] grid = convertor1.ConvertToGrid();

            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + " ms");

            for(int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    Console.Write(" " + (char)(grid[i, j] + '0') + " ");
                }
                Console.WriteLine();
            }
        }
    }
}