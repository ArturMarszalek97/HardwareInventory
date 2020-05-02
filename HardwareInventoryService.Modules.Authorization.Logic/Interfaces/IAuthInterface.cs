using HardwareInventoryService.Models.Attributes;
using HardwareInventoryService.Models.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session = HardwareInventoryService.Models.Models.Authorization.Session;

namespace HardwareInventoryService.Modules.Authorization.Logic.Interfaces
{
    public interface IAuthInterface
    {
        Task<Session> Authorize(Session authData);

        Task<bool> Deauthorize(Session authData);

        Task<bool> ChangePassword(string username, [HashDataForLog] string password, [HashDataForLog] string newPassword);
    }
}
