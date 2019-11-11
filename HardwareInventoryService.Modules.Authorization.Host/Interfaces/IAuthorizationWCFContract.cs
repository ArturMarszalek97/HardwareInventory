using HardwareInventoryService.Models.Attributes;
using HardwareInventoryService.Models.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Host.Interfaces
{
    [ServiceContract]
    public interface IAuthorizationWCFContract
    {
        [OperationContract]
        Session Authorize(Session authData);

        [OperationContract]
        bool Deauthorize(Session authData);

        [OperationContract]
        bool ChangePassword(string username, [HashDataForLog] string password, [HashDataForLog] string newPassword);
    }
}
