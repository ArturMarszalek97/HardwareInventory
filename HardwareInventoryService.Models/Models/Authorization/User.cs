using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models.Authorization
{
    public class User : IUserCacheModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] AccountPhoto { get; set; }
    }
}
