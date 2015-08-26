using log4net;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FS.Log
{
    public class LogsInstance
    {
        Queue<LogInfo> a_logsQueue = new Queue<LogInfo>();
        Thread a_thread = null;

        public LogsInstance()
        {
            log4net.Config.XmlConfigurator.Configure();
            a_thread = new Thread(new ThreadStart(PrintLogQueue));
            a_thread.Name = "OrderCenter Log";
            a_thread.Start();
        }

        #region Private Method
        void PrintLogQueue()
        {
            while (true)
            {
                try
                {
                    if (a_logsQueue.Count > 0)
                    {
                        LogInfo log = a_logsQueue.Dequeue();
                        WriteLog(log);
                    }
                    else
                    {
                        Thread.Sleep(5000);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        void WriteLog(LogInfo log)
        {
            ILog log4 = log4net.LogManager.GetLogger(log.productName);

            switch (log.typeLevel)
            {
                case "Error":
                    log4.ErrorFormat("{4}   {0}   {1}   {2}   {3}", log.datail, log.comment1, log.comment2, log.comment3, log.dateStamp.ToString("yyyy/MM/dd HH:mm:ss,fff"));
                    break;
                case "Warning":
                    log4.WarnFormat("{4}    {0}   {1}   {2}   {3}", log.datail, log.comment1, log.comment2, log.comment3, log.dateStamp.ToString("yyyy/MM/dd HH:mm:ss,fff"));
                    break;
                case "Debug":
                    log4.DebugFormat("{4}   {0}   {1}   {2}   {3}", log.datail, log.comment1, log.comment2, log.comment3, log.dateStamp.ToString("yyyy/MM/dd HH:mm:ss,fff"));
                    break;
                default:
                    log4.InfoFormat("{4}    {0}   {1}   {2}   {3}", log.datail, log.comment1, log.comment2, log.comment3, log.dateStamp.ToString("yyyy/MM/dd HH:mm:ss,fff"));
                    break;
            }
        }
        #endregion

        #region Public Method
        public void Start(LogInfo log)
        {
            a_logsQueue.Enqueue(log);
        }
        public LogInfo GetLogInfoInstance(LogTypeLevel typeLevel, string productName, string detals, bool isLog4net, string comment1, string comment2, string comment3)
        {
            LogInfo log = new LogInfo();
            log.dateStamp = DateTime.UtcNow;
            log.typeLevel = typeLevel.ToString();
            log.productName = productName;
            log.datail = detals;
            log.isLog4net = isLog4net;
            log.comment1 = comment1;
            log.comment2 = comment2;
            log.comment3 = comment3;
            return log;
        }
        #endregion
    }
}
