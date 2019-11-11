using HardwareInventoryService.Models.Attributes;
using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Authorization.Host.Interfaces;
using HardwareInventoryService.Modules.Authorization.Logic.Interfaces;
using HardwareInventoryService.ServicesReferences.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Host.Services
{
    public class AuthorizationWCFContract : IAuthorizationWCFContract
    {
        private readonly IAuthInterface _authInterface;

        private readonly ILoggerService _loggerService;

        public Session Authorize(Session authData)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string username, [HashDataForLog] string password, [HashDataForLog] string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool Deauthorize(Session authData)
        {
            throw new NotImplementedException();
        }
    }
}
