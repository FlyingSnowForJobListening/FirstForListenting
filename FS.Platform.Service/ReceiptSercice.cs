using FS.Configuration;
using FS.Message.Receiption;
using FS.Platform.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FS.Platform.Service
{
    public partial class ReceiptSercice : ServiceBase
    {
        public ReceiptSercice()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            FileWatcher.WatcherStart(ConfigurationInfo.PathReceipt, 1, "*.xml");
            ServiceHost message = new ServiceHost(typeof(MessageService));
            message.Open();
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}
