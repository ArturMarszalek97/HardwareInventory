using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Cache.Logic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.IRepositories
{
    public interface IUserRepository
    {
        HashSet<CacheObject<IUserCacheModel>> Objects { get; set; }

        void AddUser(User user);

        User GetUserByUsername(string username);
    }
}
