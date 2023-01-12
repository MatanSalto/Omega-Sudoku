using System;

namespace Omega_Sudoku.src.IO
{
    /// <summary>
    /// This class represents an IO Device,
    /// which is responsible for input and output
    /// </summary>
    public class IODevice
    {
        // The reader object
        private IGridReader _reader;
        // The writer object
        private IGridWriter _writer;

        /// <summary>
        /// Constructor for the IODevice class
        /// </summary>
        /// <param name="method">The IO method (console or file)</param>
        public IODevice(char method) {
            if (method == 'c') {
                _reader = new ConsoleGridReader();
                _writer = new ConsoleGridWriter();
            }
            if (method == 'f') {
                _reader = new FileGridReader();
                _writer = new FileGridWriter();
            }
        }

        /// <summary>
        /// This method gets input
        /// </summary>
        /// <returns>The input string</returns>
        public string Read() {
            return _reader.Read();
        }

        /// <summary>
        /// This method writes output
        /// </summary>
        /// <param name="s">The string to output</param>
        public void Write(string s) {
            _writer.Write(s);
        }
    }
}