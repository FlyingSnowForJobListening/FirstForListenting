using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS.Database.Entries
{
    public class EntryCreate : BaseEntry
    {
        public bool IsCreated { get; set; }
        public string CreateTime { get; set; }
        public bool IsReceived { get; set; }
        public string ReceiveTime { get; set; }
    }
}
