using HardwareInventoryService.Models.Attributes;
using HardwareInventoryService.Models.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ExceptionDetail = HardwareInventoryService.Models.Models.ExceptionDetail;
using Session = HardwareInventoryService.Models.Models.Authorization.Session;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Host.Interfaces
{
    [ServiceContract]
    public interface IAuthorizationWCFContract
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        Session Authorize(Session authData);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        bool Deauthorize(Session authData);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        bool ChangePassword(string username, [HashDataForLog] string password, [HashDataForLog] string newPassword);
    }
}
