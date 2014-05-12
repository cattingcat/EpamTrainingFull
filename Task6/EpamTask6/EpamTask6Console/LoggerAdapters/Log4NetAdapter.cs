using log4net;
using MyLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask6Console.LoggerAdapters
{
    class Log4NetAdapter: ILogger
    {
        private ILog _log;

        public Log4NetAdapter()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log = log4net.LogManager.GetLogger(typeof(Program));
        }
 
        public void Log(LogLevel level, string message)
        {
            switch (level)
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
                    _log.Info(message); break;
                case MyLogger.LogLevel.Warn:
                    _log.Warn(message); break;
            }
        }
    }
}
