using System;

namespace Omega_Sudoku.src.Exceptions
{
	/// <summary>
	/// This class represents the Invalid Length Exception,
	/// that is thrown when the user enters a string with an invalid
	/// length (length that doesn't produce a valid sudoku board)
	/// </summary>
	public class InvalidLengthException : Exception
	{
		/// <summary>
		/// Constructor for the InvalidLengthException class
		/// </summary>
		/// <param name="message">The string to output</param>
		/// <returns></returns>
		public InvalidLengthException(string message) : base(message) { }

		/// <summary>
		/// Constructor for the InvalidLengthException class
		/// </summary>
		/// <param name="length">The invalid length of the string</param>
		/// <returns></returns>
		public InvalidLengthException(int length) : this("Invalid Length. Length " + length + " doesn't produce a valid sudoku board size") { }
	}

}

