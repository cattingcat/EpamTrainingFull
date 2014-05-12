using MyLogger;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask6Console.LoggerAdapters
{
    class NLogAdapter: ILogger
    {
        private Logger _log = LogManager.GetCurrentClassLogger();

        public NLogAdapter()
        {

        }

        public void Log(MyLogger.LogLevel level, string message)
        {
            switch(level)
            {
                case MyLogger.LogLevel.Debug:
                    _log.Debug(message); break;
                case MyLogger.LogLevel.Error:
                    _log.Error(message); break;
                case MyLogger.LogLevel.Fatal:
                    _log.Fatal(message); break;
                case MyLogger.LogLevel.Info:
                    _log.Info(message); break;
                case MyLogger.LogLevel.Trace:
                    _log.Trace(message); break;
                case MyLogger.LogLevel.Warn:
                    _log.Warn(message); break;
            }
        }
    }
}
