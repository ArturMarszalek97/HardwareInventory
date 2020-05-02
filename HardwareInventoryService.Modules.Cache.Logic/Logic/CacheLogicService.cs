using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Cache.Logic.Interfaces;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using HardwareInventoryService.Modules.Cache.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Logic
{
    public partial class CacheLogicService : ICacheLogicService
    {
        private IDataProviderService _dataProviderService;

        public CacheLogicService(IDataProviderService dataProviderService, ISessionRepository sessionRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            this._dataProviderService = dataProviderService;
            this._sessionRepo = sessionRepository;
            this._userRepository = userRepository;
            this._itemRepository = itemRepository;
        }
    }
}
