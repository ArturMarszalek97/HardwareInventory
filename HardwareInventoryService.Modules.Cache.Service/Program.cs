using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Wcf;
using HardwareInventoryService.Modules.Cache.Host.Interfaces;
using HardwareInventoryService.Modules.Cache.Host.Services;
using HardwareInventoryService.Modules.Cache.Logic.Interfaces;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using HardwareInventoryService.Modules.Cache.Logic.Logic;
using HardwareInventoryService.Modules.Cache.Logic.Repositories;
using HardwareInventoryService.ServicesReferences.Contracts;
using HardwareInventoryService.ServicesReferences.Interceptors;
using HardwareInventoryService.ServicesReferences.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Service
{
    public static class Program
    {
        private static ILoggerService _logger;

        private static CacheService _cacheService;

        static void Main(string[] args)
        {
            try
            {
                var container = BuildIOCContainer();
                AutofacHostFactory.Container = container;

                var loggerService = container.Resolve<ILoggerService>();
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
                _cacheService = container.Resolve<CacheService>();
                //AppDomain.CurrentDomain.UnhandledException += MainHandler;
                ServicesToRun = new ServiceBase[]
                {
                    _cacheService
                };

                if (!Environment.UserInteractive)
                {
                    ServiceBase.Run(ServicesToRun);
                }
                else
                {
                    // register console close event
                    //_consoleHandler = ConsoleEventHandler;
                    //SetConsoleCtrlHandler(_consoleHandler, true);

                    _cacheService.Start();

                    Console.WriteLine("Press any key to stop...");
                    Console.ReadKey(true);

                    _cacheService.Stop();
                    //AppDomain.CurrentDomain.UnhandledException -= MainHandler;
                }
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.Append(@"Failed starting up the application in console mode\n");
                sb.Append(ex.Message);
                if (Environment.UserInteractive) Console.WriteLine(sb);
                _logger.LogMessage(sb.ToString(), LogLevel.Fatal);
                _logger.LogMessage(ex.StackTrace, LogLevel.Trace);
            }

            Environment.Exit(0);
        }

        private static IContainer BuildIOCContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoggerService>().As<ILoggerService>()
                .WithParameter("applicationName", "CacheService").SingleInstance();

            builder.RegisterType<MethodLoggingInterceptor>().As<MethodLoggingInterceptor>();

            builder.RegisterType<SessionRepository>().As<ISessionRepository>().SingleInstance();

            builder.RegisterType<CacheLogicService>().As<ICacheLogicService>()
                .SingleInstance()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(MethodLoggingInterceptor));

            builder.RegisterType<CacheWCFContract>().As<ICacheWCFContract>().SingleInstance().EnableClassInterceptors();

            builder.RegisterType<CacheService>().SingleInstance().EnableClassInterceptors().InterceptedBy(typeof(MethodLoggingInterceptor));

            return builder.Build();
        }
    }
}
