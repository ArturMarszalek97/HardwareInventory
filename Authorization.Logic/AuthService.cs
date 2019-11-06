using Cache.Logic;
using HardwareInventoryDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Authorization.Logic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthService" in both code and config file together.
    public class AuthService : IAuthService
    {
        private HardwareInventoryEntities context = new HardwareInventoryEntities();

        private readonly ICacheService _cacheService;

        public bool Authorize(string login, string password)
        {
            return true;
        }
    }
}
