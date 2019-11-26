using HardwareInventoryService.ServicesReferences.AuthorizationServiceReference;
using HardwareInventoryService.ServicesReferences.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.ServicesReferences.Services
{
    public class AuthorizationService : AuthorizationWCFContractClient, IAuthorizationService
    {
        private readonly ILoggerService _loggerService;

        public AuthorizationService(ILoggerService loggerService)
        {
            this._loggerService = loggerService;

            this.ChannelFactory.Open();
        }
    }
}
