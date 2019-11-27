using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Cache.Logic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.IRepositories
{
    public interface ISessionRepository
    {
        HashSet<CacheObject<IAuthCacheModel>> Objects { get; set; }

        void Add(Session entity);

        void AddSaved(Session entity);

        void DeleteByUsername(string username);

        void Update(Session entity);

        Session GetByUsername(string username);
    }
}
