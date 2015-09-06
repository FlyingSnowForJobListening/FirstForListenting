using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS.Database.Entries
{
    public class EntryReceive : BaseEntry
    {
        public int Status { get; set; }
        public string ReturnTime { get; set; }
        public string ReturnInfo { get; set; }
    }
}
