using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FS.Platform.Service
{
    [RunInstaller(true)]
    public partial class ReceiptInstaller : System.Configuration.Install.Installer
    {
        public ReceiptInstaller()
        {
            InitializeComponent();
            ServiceProcessInstaller process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;

            ServiceInstaller serviceAdmin = new ServiceInstaller();

            serviceAdmin.StartType = ServiceStartMode.Automatic;
            serviceAdmin.ServiceName = "ReceiptPlatForm";
            serviceAdmin.DisplayName = "Platform of Receipt";

            Installers.Add(process);
            Installers.Add(serviceAdmin);
        }
    }
}
