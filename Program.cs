using System;  
using System.Diagnostics;
using Omega_Sudoku.src.IO;
using Omega_Sudoku.src.SudokuSolving;

namespace Omega_Sudoku
{
    public class Program
    {
        public static void Main(string[] args) {

            Console.WriteLine("Welcome to the sudoku solving app");
            Solver solver = new Solver();
            while (true) {
                // Show the main menu
                Console.WriteLine("Enter 'c' to enter the board from console");
                Console.WriteLine("Enter 'f' to enter the board from a file");
                Console.WriteLine("Enter 'x' to exit the app");
                
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

                // Solve the board and stop the stopwatch
                string solution = solver.Solve(inputString);
                stopwatch.Stop();

                // Output the solution string
                ioDevice.Write(solution);

                Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + " ms");
            }
            

        }

        public static void ShowMenu()
        {
            

        }
       
    }
}