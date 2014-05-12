using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    public class MyLogger: ILogger
    {
        private string _path;

        public MyLogger(string filePath)
        {
            _path = filePath;
        }
        public void Log(LogLevel level, string message)
        {
            File.AppendAllLines(_path, new[]{level.ToString() + " " + message});
        }
    }
}
