using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models.Authorization
{
    public interface IAuthCacheModel
    {
        string Username { get; set; }

        string Token { get; set; }

        string ConnectionId { get; set; }

        List<DateTime> FailedLoginAttempts { get; set; }

        DateTime? TokenValidity { get; set; }
    }
}
