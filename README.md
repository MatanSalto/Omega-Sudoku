# Omega Sudoku Solver


This project implements a Sudoku Solver. 
The application accepts as input a string representing a sudoku board (at any valid size), and outputs the solved board (if there is a solution).

 The project is written in C# (.NET 7.0), and is implemented using the [Dancing Links](https://en.wikipedia.org/wiki/Dancing_Links) technique, as shown in [Harrysson and Laestander's paper](https://www.kth.se/social/files/58861771f276547fe1dbf8d1/HLaestanderMHarrysson_dkand14.pdf
)

## Table of Contents
* [Installation](https://github.com/MatanSalto/Omega-Sudoku#installation)
	* [Requirements](https://github.com/MatanSalto/Omega-Sudoku#requirements)
	* [Running The Application](https://github.com/MatanSalto/Omega-Sudoku#running-the-application)
* [Usage](https://github.com/MatanSalto/Omega-Sudoku#usage)
	* [Using The Solver Class](https://github.com/MatanSalto/Omega-Sudoku#using-the-solver-class)
	* [Possible Exceptions](https://github.com/MatanSalto/Omega-Sudoku#possible-exceptions)
	* [Ways of Getting Input](https://github.com/MatanSalto/Omega-Sudoku#ways-of-getting-input)


## Installation
### Requirements 
Make sure you have .NET 7.0 installed on your computer.

### Running The Application
In order to run the application, clone the repository to your local computer, and run the command 
```
dotnet run
```
from the inner directory __Omega-Sudoku__.

Or, you can run the **Program.cs** file in Visual Studio (this is where the Main method is located).

## Usage
### Using the Solver Class
Here is an example of how to solve a sudoku board using the Solver class.
```c
Solver solver = new Solver();
string solution = solver.Solve("1000001020000003");
Console.WriteLine(solution);
```
Output:
```
The solution to the input board is:

 1  2  3  4
 3  4  1  2
 2  3  4  1
 4  1  2  3
```
Note that the input board is represented by a **one-line string**, with zeros as blank cells. 

For example, the input string in the code example above is equivalent to the following board:
```
 1  0  0  0
 0  0  1  0
 2  0  0  0
 0  0  0  3
``` 
As mentioned, the application accepts any board at a valid size up to 25x25: 1x1, 4x4, 9x9, 16x16, 25x25.
For boards larger than 9x9, the values in the cells, besides the digits are the next Ascii characters.

For example, a solved 16x16 sudoku board can look like this:
```
 1  2  3  4  5  6  7  8  9  :  ;  <  =  >  ?  @
 ?  =  @  7  1  4  ;  <  3  6  8  >  2  9  :  5
 <  ;  :  >  2  =  9  ?  1  4  5  @  3  6  8  7
 6  8  5  9  3  :  >  @  2  7  ?  =  1  4  ;  <
 9  1  2  3  ?  @  4  7  5  <  >  8  :  ;  6  =
 :  6  ?  ;  8  1  5  =  @  3  4  9  7  2  <  >
 >  @  <  =  9  2  6  ;  ?  1  7  :  5  3  4  8
 4  5  7  8  >  3  <  :  =  2  6  ;  @  1  9  ?
 3  ?  1  2  7  <  8  4  :  >  @  6  ;  =  5  9
 8  <  =  6  @  ?  1  5  ;  9  3  4  >  7  2  :
 7  9  >  @  :  ;  2  6  8  =  1  5  ?  <  3  4
 5  4  ;  :  =  >  3  9  <  ?  2  7  8  @  1  6
 2  3  6  1  4  5  =  >  7  8  <  ?  9  :  @  ;
 =  :  8  ?  6  7  @  1  4  ;  9  3  <  5  >  2
 @  >  9  <  ;  8  :  2  6  5  =  1  4  ?  7  3
 ;  7  4  5  <  9  ?  3  >  @  :  2  6  8  =  1
```

### Possible Exceptions
As required, the solver also notifies when the input board has no solution (for example: invalid length, invalid arrangement of numbers, invalid characters or unsolvable).

#### Invalid Arrangement of Numbers 
If we try to run this piece of code:
```
Solver solver = new Solver();
string solution = solver.Solve("1000100020034000");
```
we will get the exception:
```
The given sudoku board is invalid
```
Because the value '1' appears twice in the first column

#### Invalid Length
If we try to run this piece of code:
```
Solver solver = new Solver();
string solution = solver.Solve("100000000");
```
we will get the exception
```
Invalid Length. Length 9 doesn't produce a valid sudoku board size
```
Because 9 is not a length of a valid sudoku board string.

#### Invalid Character
If we try to run this piece of code:
```
Solver solver = new Solver();
string solution = solver.Solve("1000001090000003");
```
we will get the exception
```
The char '9' is not valid in the current sudoku board size
```
Because in a 4x4 board, the values can be 0-4 only.

#### Unsolvable Board
If we try to run this piece of code:
```
Solver solver = new Solver();
string solution = solver.Solve("000005080000601043000000000010500000000106000300000005530000061000000004000000000");
```
we will get the exception
```
The given sudoku board is unsolvable
```
Because there is no solution to the given board

### Ways of Getting Input
when running the Main method, a menu is presented. There, the user can choose to input the board from a text file, or directly from the console.
```
Welcome to the sudoku solving app

Enter 'c' to enter the board from console
Enter 'f' to enter the board from a file
Enter 'x' to exit the app
```
When choosing to use a file, the user should then provide the path to the file
```
Enter the path to the file:
```
When choosing to input the board via a file, the **solution will also be written to a file** (in addition to the console) named _Solution.txt_
