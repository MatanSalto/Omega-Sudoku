using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega_Sudoku.src.IO
{
    public class IODevice
    {
        private IGridReader _reader;
        private IGridWriter _writer;

        public IODevice(char method) {
            if (method == 'c') {
                _reader = new ConsoleGridReader();
                _writer = new ConsoleGridWriter();
            }
            if (method == 'f') {
                _reader = new FileGridReader();
                _writer = new FileGridWriter();
            }
            else {
                // TO-DO: Handle invalid method
            }
        }

        public string Read() {
            return _reader.Read();
        }

        public void Write(string s) {
            return _writer.Write(s);
        }
    }
}