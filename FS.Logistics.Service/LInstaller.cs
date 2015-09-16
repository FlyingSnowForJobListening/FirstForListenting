using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FS.Logistics.Service
{
    [RunInstaller(true)]
    public partial class LInstaller : System.Configuration.Install.Installer
    {
        public LInstaller()
        {
            InitializeComponent();
            ServiceProcessInstaller process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;

            ServiceInstaller serviceAdmin = new ServiceInstaller();

            serviceAdmin.StartType = ServiceStartMode.Automatic;
            serviceAdmin.ServiceName = "LogisticsPlatForm";
            serviceAdmin.DisplayName = "Logistics Platform";

            Installers.Add(process);
            Installers.Add(serviceAdmin);
        }
    }
}
