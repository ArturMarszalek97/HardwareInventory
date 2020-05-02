using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Interfaces
{
    public interface ICacheLogicService : ISessionsLogic, IUserLogic, IItemLogic
    {
    }
}
