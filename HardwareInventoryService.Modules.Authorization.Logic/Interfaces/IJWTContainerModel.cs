using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Interfaces
{
    public interface IJWTContainerModel
    {
        string SecurityAlgorithm { get; set; }

        int ExpireMinutes { get; set; }

        Claim[] Claims { get; set; }
    }
}
