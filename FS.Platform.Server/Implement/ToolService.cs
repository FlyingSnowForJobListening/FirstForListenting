using FS.Cache;
using FS.Configuration;
using FS.Message.Controller;
using FS.Message.Receiption;
using FS.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FS.Platform.Server
{
    public class ToolService : IToolService
    {
        public string AwakeThread()
        {
            ReceiptThread.AwakenThread();
            int cacheQueue = QueueCache.GetCacheLength();
            return JsonConvert.SerializeObject(new
            {
                cacheQueue = cacheQueue
            });
        }

        public int ClearFileCache()
        {
            ReceiptThread.AwakenThread();
            return QueueCache.GetCacheLength();
        }

        public int ClearFileResidue()
        {
            List<string> files = null;
            try
            {
                files = FileUtilities.GetFilesInFolder(ConfigurationInfo.PathReceipt);
                foreach (var fileName in files)
                {
                    WaitCallback waitCallBack = new WaitCallback(ReceiptThread.ProgressMethod);
                    ThreadPool.QueueUserWorkItem(waitCallBack, fileName);
                }
            }
            catch (Exception)
            {
            }
            return 0;
        }

        public string ClearMessageCache(string flag)
        {
            MessageCache.ClearMessageCache();
            return GetCacheCount();
        }

        public string GetCacheCount()
        {
            Dictionary<string, CacheInfo> dic = MessageCache.GetAllMessageCaches();
            int cache501 = dic.Where(e => e.Key.IndexOf("501") > -1).Count();
            int cache503R = dic.Where(e => e.Key.IndexOf("503R") > -1).Count();
            int cache601 = dic.Where(e => e.Key.IndexOf("601") > -1).Count();
            int cacheQueue = QueueCache.GetCacheLength();
            //int cacheFile = Fil
            return JsonConvert.SerializeObject(new { cache501 = cache501, cache503R = cache503R, cache601 = cache601, cacheQueue = cacheQueue });
        }
    }
}
