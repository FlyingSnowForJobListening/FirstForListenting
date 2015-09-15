using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Message.Client
{
    public enum ExecuteAction
    {
        Get,
        GetByGuid,
        GetByFilter,
        GetCache,
        Clear601,
        ClearCacheFile,
        ClearFileResidue,
        AwakeThread
    }

    public enum ExecuteMethod
    {
        Messages,
        Tools
    }
}
