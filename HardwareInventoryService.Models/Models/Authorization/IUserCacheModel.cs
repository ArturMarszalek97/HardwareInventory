using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models.Authorization
{
    public interface IUserCacheModel
    {
        string Username { get; set; }

        string Password { get; set; }

        byte[] AccountPhoto { get; set; }
    }
}
