using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dropbox.IO
{
    public class FileReader
    {
        private readonly String _filePath;
        private String[] _lines;

        public FileReader(String filePath)
        {
            _filePath = filePath;
            _lines = null;
        }

        public bool ReadFile()
        {
            _lines = File.ReadAllLines(_filePath);

            return _lines.Any();
        }

        public Int32 GetNrOfLines()
        {
            return Int32.Parse(_lines[0]);
        }

        public String ReadLine(Int32 index)
        {
            return _lines[index];
        }
    }
}
