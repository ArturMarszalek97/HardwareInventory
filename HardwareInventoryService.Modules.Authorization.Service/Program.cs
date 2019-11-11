using Autofac;
using Autofac.Integration.Wcf;
using HardwareInventoryService.Modules.Authorization.Host.Services;
using HardwareInventoryService.Modules.Authorization.Logic.Helpers;
using HardwareInventoryService.Modules.Authorization.Logic.Logic;
using HardwareInventoryService.ServicesReferences.Contracts;
using HardwareInventoryService.ServicesReferences.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Service
{
    class Program
    {
        private static ILoggerService _logger;

        private static AuthorizationService _wcfService;

        static void Main(string[] args)
        {
            var iocContainer = BuildIOCContainer();
            AutofacHostFactory.Container = iocContainer;
            var loggerService = iocContainer.Resolve<ILoggerService>();
            _logger = loggerService;

            ServiceInstallerUtility.InstallMe();

            ServiceBase[] ServicesToRun;

            _wcfService = iocContainer.Resolve<AuthorizationService>();

            ServicesToRun = new ServiceBase[] { _wcfService };

            ServiceBase.Run(ServicesToRun);
        }

        private static IContainer BuildIOCContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterType<AuthorizationWCFContract>().AsImplementedInterfaces().SingleInstance();

            container.RegisterType<LoggerService>().AsImplementedInterfaces()
                .WithParameter("applicationName", StringContainer.ApplicationName)
                .SingleInstance();

            container.RegisterType<AuthorizationService>().SingleInstance();

            container.RegisterType<AuthInterface>().AsImplementedInterfaces().SingleInstance();

            return container.Build();
        }
    }
}
