using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Tool
{
    public class RequestObj
    {
        public RequestObj()
        {
            this.RequestUrl = ConfigurationManager.AppSettings["RequestUrl"];
        }
        public string RequestUrl { get; set; }
        public string RequestMethod { get; set; }
        public string OrderNo { get; set; }
        public string OrderNoFake { get; set; }
        public string LogisticsNo { get; set; }
    }
}
