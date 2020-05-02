using HardwareInventoryService.Modules.Authorization.Logic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Models
{
    public class JWTContainerModel : IJWTContainerModel
    {
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha512Signature;

        public int ExpireMinutes { get; set; } = 60;

        public Claim[] Claims { get; set; }
    }
}
