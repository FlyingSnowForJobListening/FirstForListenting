using FS.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FS.Message.Receiption.Cache
{
    public class MessageCache
    {
        internal static Dictionary<string, CacheInfo> a_dic = new Dictionary<string, CacheInfo>();
        static Thread a_thread;

        static MessageCache()
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
                a_thread = new Thread(MessageThread.CheckCacheThread);
                a_thread.Start();
            }
            catch (Exception)
            {
            }
        }

        public static void AddMessageCache(string key, CacheInfo info)
        {
            lock (a_dic)
            {
                if (!a_dic.ContainsKey(key))
                {
                    a_dic.Add(key, info);
                }
            }
        }

        public static void DeleteMessageCache(string key)
        {
            lock (a_dic)
            {
                if (a_dic.ContainsKey(key))
                {
                    a_dic.Remove(key);
                }
            }
        }

        public static int GetCacheCount()
        {
            return a_dic.Count;
        }

        public static Dictionary<string, CacheInfo> GetAllMessageCaches()
        {
            return a_dic;
        }
    }
}
