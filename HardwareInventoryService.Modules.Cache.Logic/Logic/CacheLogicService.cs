using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Cache.Logic.Interfaces;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Logic
{
    public partial class CacheLogicService : ICacheLogicService
    {
        public CacheLogicService(ISessionRepository sessionRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            this._sessionRepo = sessionRepository;
            this._userRepository = userRepository;
            this._itemRepository = itemRepository;
        }
    }
}
