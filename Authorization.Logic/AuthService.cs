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
        private readonly HardwareInventoryEntities context = new HardwareInventoryEntities();

        private readonly ICacheService _cacheService;

        public AuthService(ICacheService cacheService)
        {
            this._cacheService = cacheService;
        }

        public bool Authorize(string login, string password)
        {
            var x = this._cacheService.DoWork();

            return true;
        }
    }
}
