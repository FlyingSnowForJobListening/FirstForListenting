using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS.Database.Entries
{
    public class EntryCreate : BaseEntry
    {
        public bool IsCreated { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsReceived { get; set; }
        public DateTime ReceiveTime { get; set; }
    }
}
