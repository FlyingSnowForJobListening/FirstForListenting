using FS.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FS.Message.Receiption
{
    public class ReceiptThread
    {
        static Thread a_thread;

        public static void AwakenThread()
        {
            if (a_thread == null || !a_thread.IsAlive)
            {
                StartThread();
            }
        }
        private static void StartThread()
        {
            try
            {
                a_thread = new Thread(CheckCacheThread);
                a_thread.Start();
            }
            catch (Exception)
            {
            }
        }
        private static void CheckCacheThread()
        {
            while (QueueCache.GetCacheLength() > 0)
            {
                string fileName = QueueCache.DeQueueCache();
                WaitCallback waitCallBack = new WaitCallback(ProgressMethod);
                ThreadPool.QueueUserWorkItem(waitCallBack, fileName);
            }
        }

        private static void ProgressMethod(object param)
        {
            string path = null;
            try
            {
                path = param.ToString();
                XElement xele = XElement.Load(path);

                string firstNodeName = xele.Name.LocalName.ToLower();
                switch (firstNodeName)
                {
                    case "ceb301message":
                        ReceiptHelper.DealWith301(path);
                        break;
                    case "ceb302message":
                        ReceiptHelper.DealWith302(xele, path);
                        break;
                    case "ceb501message":
                        ReceiptHelper.DealWith501(xele, path);
                        break;
                    case "ceb502message":
                        ReceiptHelper.DealWith502(xele, path);
                        break;
                    case "ceb504message":
                        //ReceiptHelper.DealWith504(xele, path);
                        break;
                    case "ceb601message":
                        ReceiptHelper.DealWith601(xele, path);
                        break;
                    case "ceb602message":
                        ReceiptHelper.DealWith602(xele, path);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Logs.Info("Error File path:" + path);
                Logs.Error("ProgressMethod Exception:" + ex.ToString());
            }
        }
    }
}
