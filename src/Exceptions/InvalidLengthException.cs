using System;

public class InvalidLengthException : Exception
{
	
	public InvalidLengthException(string message) : base(message) { }
	public InvalidLengthException(int length) {
		this("Invalid Length. " + length + " is not a perfect square");
    }
}
