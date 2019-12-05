using HardwareInventoryService.Models.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Interfaces
{
    public interface IAuthorizationConfigurationRepository
    {
        AuthorizationModuleConfiguration Get();

        void Set(AuthorizationModuleConfiguration config);
    }
}
