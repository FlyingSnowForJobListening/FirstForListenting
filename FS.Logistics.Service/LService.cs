using FS.Logistics.Server;
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

namespace FS.Logistics.Service
{
    public partial class LService : ServiceBase
    {
        public LService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceHost logistics = new ServiceHost(typeof(LogisticsService));
            logistics.Open();

            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}
