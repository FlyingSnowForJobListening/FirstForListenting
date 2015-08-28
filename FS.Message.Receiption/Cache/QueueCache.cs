using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FS.Message.Receiption
{
    public class QueueCache
    {
        #region Fields
        static Queue<string> a_queueCache = new Queue<string>();
        static Thread a_thread;
        #endregion

        #region Public Methods
        static QueueCache()
        {
            IsliveCache();
        }
        private static void IsliveCache()
        {
            if (a_thread == null || !a_thread.IsAlive)
            {
                StartCacheThread();
            }
        }
        /// <summary>
        /// start Cache Thread
        /// </summary>
        private static void StartCacheThread()
        {
            try
            {
                a_thread = new Thread(CheckCacheThread);
                a_thread.Start();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Clear Cache by time
        /// </summary>
        private static void CheckCacheThread()
        {
            while (true)
            {
                lock (a_queueCache)
                {
                    int number = a_queueCache.Count();
                    if (number > 0)
                    {
                        for (int i = 0; i < number; i++)
                        {
                            string filePath = a_queueCache.Dequeue();
                            //Thread receipt = new Thread(new ParameterizedThreadStart(ReceiptThread.DealByQuene));
                            //receipt.Start(filePath);
                        }
                    }
                }
                Thread.Sleep(2000);
            }
        }
        /// <summary>
        /// Add Chace to Queue
        /// </summary>      
        public static void AddQueueCache(string value)
        {
            lock (a_queueCache)
            {
                a_queueCache.Enqueue(value);
            }
        }
        #endregion
    }
}
