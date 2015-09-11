using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Message.Structure;

namespace FS.Logistics.Server
{
    public class LogisticsService : ILogisticsService
    {
        public bool UploadLogistics501(LogisticsHead info)
        {
            LogisticsControl control = new LogisticsControl();
            return control.Create501Message(info);
        }

        public bool UploadLogistics503(LogisticsStatus info)
        {
            LogisticsControl control = new LogisticsControl();
            return control.Create503Message(info);
        }
    }
}
