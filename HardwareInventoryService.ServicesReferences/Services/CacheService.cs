using HardwareInventoryService.ServicesReferences.CacheServiceReference;
using HardwareInventoryService.ServicesReferences.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.ServicesReferences.Services
{
    public class CacheService : CacheWCFContractClient, ICacheService
    {
        private readonly ILoggerService _loggerService;

        public CacheService(ILoggerService loggerService)
        {
            this._loggerService = loggerService;

            this.ChannelFactory.Open();
        }
    }
}
