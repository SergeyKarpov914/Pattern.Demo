using NLog;
using NLog.Config;
using System.Diagnostics;

namespace Clio.Demo.VisitingProfessor.Util
{
    internal static class Log
    {
        private static Logger _logger;

        static Log()
        {
            LogManager.Configuration = new XmlLoggingConfiguration("nlog.config");
            _logger = LogManager.GetCurrentClassLogger();
        }

        public static void Info(object sender, string message)
        {
            _logger.Info($"  {sender.Stamp().PadRight(22)} {message}");
        }
        public static void Error(object sender, Exception ex)
        {
            _logger.Info($"  {sender.Stamp().PadRight(22)} ERROR! {ex.Message}");
        }
        public static void Line()
        {
            _logger.Info($"");
        }

        public static string Caller => new StackTrace().GetFrame(1)?.GetMethod()?.Name;
    }
}