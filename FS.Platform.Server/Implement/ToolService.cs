﻿using FS.Configuration;
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
        public bool AwakeThread()
        {
            try
            {
                ReceiptThread.AwakenThread();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

        public int ClearMessageCache601()
        {
            MessageCache.ClearMessageCache();
            return MessageCache.GetCacheLength();
        }

        public string GetCacheCount()
        {
            int cache601 = MessageCache.GetCacheLength();
            int cacheQueue = QueueCache.GetCacheLength();
            //int cacheFile = Fil
            return JsonConvert.SerializeObject(new { cache601 = cache601, cacheQueue = cacheQueue });
        }
    }
}
