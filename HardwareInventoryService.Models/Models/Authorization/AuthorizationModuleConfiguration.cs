using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models.Authorization
{
    public class AuthorizationModuleConfiguration
    {
        public int AccountBlockTime { get; set; }

        public string JWTSecretKey { get; set; }

        public int MaximumLoginFailures { get; set; }
    }
}
