using FS.Database;
using FS.Database.Entries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Platform.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Data.Entity.Database.SetInitializer(new Database.DatabaseInitializer());
                using (var db = new EntryContext())
                {
                    var entry = new Entry302();
                    db.Entry302s.Add(entry);
                    db.SaveChanges();
                    var s = db.Entry302s;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
