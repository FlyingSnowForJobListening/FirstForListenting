using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Database.Entries
{
    public class EntryCreate : BaseEntry
    {
        public bool IsCreated { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsReceived { get; set; }
        public DateTime ReceiveTime { get; set; }
        public int MessageId { get; set; }
        [ForeignKey("MessageId")]
        public virtual MessageTrack MessageTrack { get; set; }
    }
}
