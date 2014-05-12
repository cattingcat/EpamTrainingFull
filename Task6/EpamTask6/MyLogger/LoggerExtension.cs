using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    public static class LoggerExtension
    {
        public static void Trace(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Trace, message);
        }
        public static void Trace(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Trace, String.Format(message, args));
        }

        public static void Warn(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Warn, message);
        }
        public static void Warn(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Warn, String.Format(message, args));
        }
    }
}
