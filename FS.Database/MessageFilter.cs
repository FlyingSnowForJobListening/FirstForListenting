using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Database.Entries
{
    public class MessageFilter
    {
        public Guid Guid { get; set; }
        public string OrderNo { get; set; }
        public string LogisticsNo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Status { get; set; }
    }
}
