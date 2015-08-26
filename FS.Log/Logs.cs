using FS.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Log
{
    public class Logs
    {
        private static LogsInstance a_logsInstance { get; set; }
        private static readonly string productName = "OrderCenter";
        private static bool isLog4net = true;

        static Logs()
        {
            a_logsInstance = new LogsInstance();
        }

        public static void Info(string message)
        {
            LogInfo logInfo = a_logsInstance.GetLogInfoInstance(LogTypeLevel.Information, productName, message, isLog4net, "", "", "");
            a_logsInstance.Start(logInfo);
        }

        public static void Warning(string message)
        {
            LogInfo logInfo = a_logsInstance.GetLogInfoInstance(LogTypeLevel.Warning, productName, message, isLog4net, "", "", "");
            a_logsInstance.Start(logInfo);
        }

        public static void Error(string message)
        {
            LogInfo logInfo = a_logsInstance.GetLogInfoInstance(LogTypeLevel.Error, productName, message, isLog4net, "", "", "");
            a_logsInstance.Start(logInfo);
        }

        public static void Debug(string message)
        {
            if (ConfigurationInfo.EnableDebugLog)
            {
                LogInfo logInfo = a_logsInstance.GetLogInfoInstance(LogTypeLevel.Debug, productName, message, isLog4net, "", "", "");
                a_logsInstance.Start(logInfo);
            }
        }
    }
}
