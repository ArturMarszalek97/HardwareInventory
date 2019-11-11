using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models.Enums
{
    public enum ErrorCode
    {
        ConnectionError = 1000,
        ArgumentNullError = 1001,
        SessionError = 4001,
        AccountBlocked = 4002,
        PassAlreadyUsedError = 4003,
        Undefined = 0
    }
}
