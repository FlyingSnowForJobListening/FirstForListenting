using FS.Cache;
using FS.Message.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace FS.Message.Receiption
{
    public class MessageCache601
    {
        #region Fields
        static Hashtable a_hashCache = new Hashtable();
        static Thread a_thread;
        #endregion

        #region Public Methods
        static MessageCache601()
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
        private static void StartCacheThread()
        {
            try
            {
                a_thread = new Thread(CheckCacheThread);
                a_thread.Name = "OrderCenter MessageCache";
                a_thread.Start();
            }
            catch (Exception ex)
            {
            }
        }
        private static void CheckCacheThread()
        {
            int _sleepTime = 60000 * 20;
            while (true)
            {
                lock (a_hashCache)
                {
                    List<string> keys = new List<string>();
                    foreach (DictionaryEntry de in a_hashCache)
                    {
                        CacheInfo info = de.Value as CacheInfo;
                        if ((DateTime.Now - info.createTime).TotalMinutes > 30)
                        {
                            Thread send601 = new Thread(new ParameterizedThreadStart(MessageControl.CreateMessage601));
                            send601.Start(de.Key.ToString());
                            keys.Add(de.Key.ToString());
                        }
                    }
                    foreach (string k in keys)
                    {
                        a_hashCache.Remove(k);
                    }
                }
                Thread.Sleep(_sleepTime);
            }
        }
        public static bool AddCache(CacheInfo cacheInfo)
        {
            try
            {
                lock (a_hashCache)
                {
                    if (!a_hashCache.ContainsKey(cacheInfo.key))
                    {
                        a_hashCache.Add(cacheInfo.key, cacheInfo);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool RemoveCache(string key)
        {
            try
            {
                lock (a_hashCache)
                {
                    if (a_hashCache.ContainsKey(key))
                    {
                        a_hashCache.Remove(key);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static int GetCacheLength()
        {
            return a_hashCache.Count;
        }
        public static void ClearMessageCache()
        {
            lock (a_hashCache)
            {
                List<string> keys = new List<string>();
                foreach (DictionaryEntry de in a_hashCache)
                {
                    CacheInfo info = de.Value as CacheInfo;
                    Thread send601 = new Thread(new ParameterizedThreadStart(MessageControl.CreateMessage601));
                    send601.Start(de.Key.ToString());
                    keys.Add(de.Key.ToString());
                }
                foreach (string k in keys)
                {
                    a_hashCache.Remove(k);
                }
            }
        }
        #endregion
    }
}
