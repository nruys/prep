using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dropbox.IO
{
    class Program
    {
        public const string _filePath = "input.txt";

        static void Main(string[] args)
        {
            var fileReader = new FileReader(_filePath);
            if (fileReader.ReadFile())
            {
                for (var i = 0; i < fileReader.GetNrOfLines(); i++)
                {
                    var line = fileReader.ReadLine(i);
                }
            }
        }
    }
}
