using HardwareInventoryService.Models.Attributes;
using HardwareInventoryService.Models.Exceptions;
using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Authorization.Logic.Interfaces;
using HardwareInventoryService.ServicesReferences.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Logic
{
    public class AuthInterface : IAuthInterface
    {
        private readonly ICacheService _cacheWCF;

        public async Task<Session> Authorize(Session authData)
        {
            if (!this.ValidateUserData(authData))
            {

            }

            var sessionFromCache = await this.GetSessionFromCache(authData);

            if (sessionFromCache != null && sessionFromCache.FailedLoginAttempts.Count >= 5)
            {
                if (sessionFromCache.FailedLoginAttempts.Max() > DateTime.Now.AddHours(-(5)))
                {
                    throw new SessionException(
                            $"Account blocked till {sessionFromCache.FailedLoginAttempts.Max().AddHours(conf.AccountBlockTime)}",
                            ErrorCode.AccountBlocked,
                            sessionFromCache.FailedLoginAttempts.Max().AddHours(conf.AccountBlockTime));
                }
            }
                return authData;
        }

        public async Task<bool> ChangePassword(string username, [HashDataForLog] string password, [HashDataForLog] string newPassword)
        {
            return await Task.Run(() => true);
        }

        public async Task<bool> Deauthorize(Session authData)
        {
            return await Task.Run(() => true);
        }

        private bool ValidateUserData(Session authData)
        {
            return authData != null && !string.IsNullOrEmpty(authData.Username) && !string.IsNullOrEmpty(authData.Password);
        }

        public virtual async Task<Session> GetSessionFromCache(Session authData)
        {
            Session session = null;
            try
            {
                var wcfSession = await this._cacheWCF.GetSessionByUsernameAsync(authData.Username);
                //session = this._mapper.Map<Session>(wcfSession);
            }
            catch (Exception ex)
            {
            }

            return session;
        }
    }
}
