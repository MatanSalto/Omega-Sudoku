#pragma warning disable CS8602

using System;  
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using Omega_Sudoku.src.Exceptions;
using Omega_Sudoku.src.IO;
using Omega_Sudoku.src.SudokuSolving;

namespace Omega_Sudoku
{
    public class Program
    {
        public static void Main(string[] args) {

            Console.WriteLine("Welcome to the sudoku solving app");
            Solver solver = new Solver();
            while (true)
            {
                // Show the main menu
                ShowMenu();

                // Get the user's choice
                char choice = Console.ReadLine()[0];

                // If the user's choice was 'x', exit the mainloop
                if (choice == 'x')
                {
                    break;
                }

                // If the choice in invalid
                if (choice != 'c' && choice != 'f')
                {
                    Console.WriteLine("Invalid choice. Try again");
                    continue;
                }
                // Else, create an IO device with the method
                IODevice ioDevice = new IODevice(choice);

                // Get the input string from the user
                string inputString = ioDevice.Read();

                // Activate the stopwatch
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Try solving the board
                try
                {
                    // Solve the board and stop the stopwatch
                    string solution = solver.Solve(inputString);
                    stopwatch.Stop();

                    // Output the solution string
                    ioDevice.Write("The solution to the input board is\n\n" + solution);

                    // Print the time it took solve the board
                    Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + " ms");
                }

                // Catch Solving Exceptions
                catch (InvalidLengthException ile)
                {
                    Console.WriteLine(ile.Message);
                    continue;
                }
                catch (InvalidCharacterException ice)
                {
                    Console.WriteLine(ice.Message);
                    continue;
                }
                catch (InvalidBoardException ibe)
                {
                    Console.WriteLine(ibe.Message);
                    continue;
                }
                catch (UnsolvableBoardException ube)
                {
                    Console.WriteLine(ube.Message);
                    continue;
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n\nEnter 'c' to enter the board from console");
            Console.WriteLine("Enter 'f' to enter the board from a file");
            Console.WriteLine("Enter 'x' to exit the app\n\n");
        }
    }
}