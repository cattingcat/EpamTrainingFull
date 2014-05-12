using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    public enum LogLevel{Debug, Error, Fatal, Info, Trace, Warn};

    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }
}
