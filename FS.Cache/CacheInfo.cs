using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Cache
{
    public class CacheInfo
    {
        #region Properties
        public string key { get; set; }
        public object value { get; set; }
        public DateTime createTime { get; set; }
        #endregion
        public static CacheInfo SetCacheInfo(string key, object value)
        {
            CacheInfo cacheInfo = new CacheInfo();
            cacheInfo.key = key;
            cacheInfo.value = value;
            cacheInfo.createTime = DateTime.Now;
            return cacheInfo;
        }
    }
}
