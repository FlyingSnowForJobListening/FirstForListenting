using FS.Database.Entries;
using System.Data.Entity;


namespace FS.Database
{
    public class EntryContext : DbContext
    {
        public EntryContext() :
            base("EntrySqlConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            System.Data.Entity.Database.SetInitializer<EntryContext>(new DropCreateDatabaseIfModelChanges<EntryContext>());
        }
        public DbSet<EntryCreate> CreatedEntries { get; set; }
        public DbSet<EntryReceive> ReceivedEntries { get; set; }
        public DbSet<MessageTrack> MessageTracks { get; set; }
    }
}
