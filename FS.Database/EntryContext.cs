using FS.Database.Entries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Database
{
    public class EntryContext : DbContext
    {
        public EntryContext() : base("EntrySqlConnection") { }
        public DbSet<EntryCreate> CreatedEntries { get; set; }
        public DbSet<EntryReceive> ReceivedEntries { get; set; }
        public DbSet<MessageTrack> MessageTracks { get; set; }
    }
}
