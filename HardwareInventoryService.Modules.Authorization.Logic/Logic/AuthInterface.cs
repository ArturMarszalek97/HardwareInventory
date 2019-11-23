using HardwareInventoryService.Models.Attributes;
using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Authorization.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Logic
{
    public class AuthInterface : IAuthInterface
    {
        public async Task<Session> Authorize(Session authData)
        {
            return authData;
        }

        public async Task<bool> ChangePassword(string username, [HashDataForLog] string password, [HashDataForLog] string newPassword)
        {
            return await Task.Run(() => true);
        }

        public async Task<bool> Deauthorize(Session authData)
        {
            return await Task.Run(() => true);
        }
    }
}
