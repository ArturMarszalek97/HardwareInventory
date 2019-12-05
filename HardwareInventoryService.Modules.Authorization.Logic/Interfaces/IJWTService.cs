using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Authorization.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Interfaces
{
    public interface IJWTService
    {
        string SecretKey { get; set; }

        bool IsTokenValid(string token);

        string GenerateToken(IJWTContainerModel model);

        IEnumerable<Claim> GetTokenClaims(string token);

        JWTContainerModel CreateContainer(Session authData);
    }
}
