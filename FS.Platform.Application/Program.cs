using FS.Configuration;
using FS.Database;
using FS.Database.Entries;
using FS.Message.Receiption;
using FS.Platform.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
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
                FileWatcher.WatcherStart(ConfigurationInfo.PathReceipt, 1, "*.xml");

                ServiceHost message = new ServiceHost(typeof(MessageService));
                message.Open();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
