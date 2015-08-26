using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Database.Entries
{
    public class EntryReceive : BaseEntry
    {
        public int Status { get; set; }
        public DateTime ReturnTime { get; set; }
        public string ReturnInfo { get; set; }
        public int MessageId { get; set; }
        [ForeignKey("MessageId")]
        public virtual MessageTrack MessageTrack { get; set; }
    }
}
