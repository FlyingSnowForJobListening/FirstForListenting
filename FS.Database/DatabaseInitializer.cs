using System.Data.Entity;

namespace FS.Database
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<EntryContext>
    {
        protected override void Seed(EntryContext context)
        {
            base.Seed(context);
        }
    }
}
