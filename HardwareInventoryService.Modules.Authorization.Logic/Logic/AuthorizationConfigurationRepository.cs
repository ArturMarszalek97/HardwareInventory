using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Authorization.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Logic
{
    public class AuthorizationConfigurationRepository : IAuthorizationConfigurationRepository
    {
        private AuthorizationModuleConfiguration _configuration;

        private readonly object _configurationLock = new object();

        public AuthorizationConfigurationRepository()
        {
            this._configuration = new AuthorizationModuleConfiguration();
            this._configuration.AccountBlockTime = 5;
            this._configuration.JWTSecretKey = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
            this._configuration.MaximumLoginFailures = 3;
        }

        private AuthorizationModuleConfiguration AuthorizationModuleConfiguration
        {
            get { lock (this._configurationLock) { return this._configuration; } }
            set { lock (this._configurationLock) { this._configuration = value; } }
        }

        public AuthorizationModuleConfiguration Get()
        {
            return this.AuthorizationModuleConfiguration;
        }

        public void Set(AuthorizationModuleConfiguration config)
        {
            this.AuthorizationModuleConfiguration = config;
        }
    }
}
