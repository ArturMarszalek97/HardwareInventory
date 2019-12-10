using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Wcf;
using HardwareInventoryService.Modules.Authorization.Host.Services;
using HardwareInventoryService.Modules.Authorization.Logic.Helpers;
using HardwareInventoryService.Modules.Authorization.Logic.Logic;
using HardwareInventoryService.ServicesReferences.Contracts;
using HardwareInventoryService.ServicesReferences.Interceptors;
using HardwareInventoryService.ServicesReferences.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            // self service installer/uninstaller
            if (args != null && args.Length == 1
                            && (args[0][0] == '-' || args[0][0] == '/'))
                switch (args[0].Substring(1).ToLower())
                {
                    case "install":
                    case "i":
                        if (!ServiceInstallerUtility.InstallMe())
                            _logger.LogMessage("Failed to install service", LogLevel.Fatal);
                        break;
                    case "uninstall":
                    case "u":
                        if (!ServiceInstallerUtility.UninstallMe())
                            _logger.LogMessage("Failed to uninstall service", LogLevel.Fatal);
                        break;
                    default:
                        _logger.LogMessage(
                            "Unrecognized parameters (allowed: /install and /uninstall, shorten /i and /u)",
                            LogLevel.Error);
                        break;
                }

            ServiceBase[] ServicesToRun;

            _wcfService = iocContainer.Resolve<AuthorizationService>();

            ServicesToRun = new ServiceBase[] { _wcfService };

            if (!Environment.UserInteractive)
            {
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                // register console close event
                //_consoleHandler = ConsoleEventHandler;
                //SetConsoleCtrlHandler(_consoleHandler, true);

                //Console.Title = AppDomain.CurrentDomain.FriendlyName;

                _wcfService.Start();

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);

                _wcfService.Stop();
                //AppDomain.CurrentDomain.UnhandledException -= MainHandler;
            }
        }

        private static IContainer BuildIOCContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterType<MethodLoggingInterceptor>().As<MethodLoggingInterceptor>();
            container.RegisterType<ExceptionLoggingInterceptor>().As<ExceptionLoggingInterceptor>();
            container.RegisterType<TimeMeasuringInterceptor>().As<TimeMeasuringInterceptor>();

            container.RegisterType<AuthorizationWCFContract>().AsImplementedInterfaces().SingleInstance().EnableClassInterceptors();
            container.RegisterType<AuthorizationConfigurationRepository>().AsImplementedInterfaces().SingleInstance();

            container.RegisterType<JWTService>().AsImplementedInterfaces().SingleInstance()
                .WithParameter("secretKey", ConfigurationManager.AppSettings["JWTSecretKey"]).EnableInterfaceInterceptors()
                .InterceptedBy(typeof(MethodLoggingInterceptor));

            container.RegisterType<CacheService>().AsImplementedInterfaces().SingleInstance().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(MethodLoggingInterceptor));

            container.RegisterType<LoggerService>().AsImplementedInterfaces()
                .WithParameter("applicationName", StringContainer.ApplicationName)
                .SingleInstance();

            container.RegisterType<AuthorizationService>().SingleInstance().EnableClassInterceptors()
                .InterceptedBy(typeof(MethodLoggingInterceptor))
                .InterceptedBy(typeof(ExceptionLoggingInterceptor))
                .InterceptedBy(typeof(TimeMeasuringInterceptor));

            container.RegisterType<AuthInterface>().AsImplementedInterfaces().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(MethodLoggingInterceptor));

            return container.Build();
        }
    }
}
