using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Database.Entries
{
    public class MessageTrack : BaseEntry
    {
        public string OrderNo { get; set; }
        public string OrderNoFake { get; set; }
        public string LogisticsNo { get; set; }
        [InverseProperty("MessageTrack")]
        public virtual List<Entry302> Entry302s { get; set; }
    }
}
