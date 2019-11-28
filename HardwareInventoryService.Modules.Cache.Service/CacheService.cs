using Autofac.Integration.Wcf;
using HardwareInventoryService.Modules.Cache.Host.Interfaces;
using HardwareInventoryService.Modules.Cache.Host.Services;
using HardwareInventoryService.ServicesReferences.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Service
{
    public partial class CacheService : ServiceBase
    {
        private readonly ICacheWCFContract _cacheWcf;

        public ILoggerService _loggerService;

        public ServiceHost _serviceHost;

        public CacheService()
        {
            InitializeComponent();
        }

        public CacheService(ILoggerService loggerService, ICacheWCFContract cacheWcf)
        {
            InitializeComponent();
            this._loggerService = loggerService;
            this._cacheWcf = cacheWcf;
        }

        public void Start()
        {
            this.OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                this._serviceHost?.Close();

                using (var cacheHost = new ServiceHost(typeof(CacheWCFContract)))
                {
                    this._serviceHost = new ServiceHost(this._cacheWcf);
                    this._serviceHost.AddDefaultEndpoints();

                    foreach (ServiceEndpoint endpoint in cacheHost.Description.Endpoints)
                    {
                        var contract = endpoint.Contract;
                        Type t = contract.ContractType;

                        this._serviceHost.AddServiceEndpoint(t, endpoint.Binding, endpoint.Address.Uri);

                        this._serviceHost.AddDependencyInjectionBehavior(t, AutofacHostFactory.Container);
                    }
                }

                this._serviceHost.Opened += this.ServiceHost_Opened;
                this._serviceHost.Closed += this.ServiceHost_Closed;
                this._serviceHost.Closing += this.ServiceHost_Closing;
                this._serviceHost.Faulted += this.ServiceHost_Faulted;
                this._serviceHost.Opening += this.ServiceHost_Opening;
                this._serviceHost.UnknownMessageReceived += this.ServiceHost_UnknownMessageReceived;

                this._serviceHost.Open();

            }
            catch (Exception ex)
            {
                this._loggerService.LogMessage($"Failed starting Cache service, {ex.Message}", LogLevel.Fatal);
                this._loggerService.LogMessage(ex.StackTrace, LogLevel.Trace);
            }
        }

        private void ServiceHost_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            this._loggerService.LogMessage(e.Message.ToString(), LogLevel.Debug);
        }

        private void ServiceHost_Opening(object sender, EventArgs e)
        {
            this._loggerService.LogMessage("Service host going to opening state.", LogLevel.Debug);
        }

        private void ServiceHost_Faulted(object sender, EventArgs e)
        {
            this._loggerService.LogMessage("Service host in the fault state.", LogLevel.Debug);
        }

        private void ServiceHost_Closing(object sender, EventArgs e)
        {
            this._loggerService.LogMessage("Service host going to closing state.", LogLevel.Debug);
        }

        private void ServiceHost_Closed(object sender, EventArgs e)
        {
            this._loggerService.LogMessage("Service host in the closed state.", LogLevel.Debug);
        }

        private void ServiceHost_Opened(object sender, EventArgs e)
        {
            this._loggerService.LogMessage("Service host in the opened state.", LogLevel.Debug);
        }

        protected override void OnStop()
        {
            try
            {
                if (this._serviceHost != null)
                {
                    this._serviceHost.Close();
                    this._serviceHost.Opened -= this.ServiceHost_Opened;
                    this._serviceHost.Closed -= this.ServiceHost_Closed;
                    this._serviceHost.Closing -= this.ServiceHost_Closing;
                    this._serviceHost.Faulted -= this.ServiceHost_Faulted;
                    this._serviceHost.Opening -= this.ServiceHost_Opening;
                    this._serviceHost.UnknownMessageReceived -= this.ServiceHost_UnknownMessageReceived;
                }
            }
            catch (Exception ex)
            {
                this._loggerService.LogMessage($"Failed stopping Cache service, {ex.Message}", LogLevel.Fatal);
                this._loggerService.LogMessage(ex.StackTrace, LogLevel.Trace);
            }
        }
    }
}
