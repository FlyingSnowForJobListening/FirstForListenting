using System.Collections.Generic;

namespace FS.Database.Entries
{
    public class MessageTrack : BaseEntry
    {
        public string OrderNo { get; set; }
        public string OrderNoFake { get; set; }
        public string LogisticsNo { get; set; }
        public int Schedule { get; set; }
        public long LastUpdateTicks { get; set; }
        public bool IsFinished { get; set; }
        public virtual List<EntryCreate> Entry301s { get; set; }
        public virtual List<EntryReceive> Entry302s { get; set; }
        public virtual List<EntryCreate> Entry501s { get; set; }
        public virtual List<EntryReceive> Entry502s { get; set; }
        public virtual List<EntryCreate> Entry503s { get; set; }
        public virtual List<EntryReceive> Entry504s { get; set; }
        public virtual List<EntryCreate> Entry601s { get; set; }
        public virtual List<EntryReceive> Entry602s { get; set; }
    }
}
