using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            this.process = new ServiceProcessInstaller();
            this.process.Account = ServiceAccount.LocalSystem;
            this.service = new ServiceInstaller();
            this.service.ServiceName = "HardwareInventoryService.Modules.Authorization";
            this.Installers.Add(process);
            this.Installers.Add(service);
            InitializeComponent();
        }
    }
}
