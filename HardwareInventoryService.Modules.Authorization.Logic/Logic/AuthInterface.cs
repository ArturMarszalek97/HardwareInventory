using HardwareInventoryService.Models.Attributes;
using HardwareInventoryService.Models.Exceptions;
using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Models.Models.Enums;
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
        private readonly ILoggerService _logger;

        private readonly ICacheService _cacheWCF;

        private readonly IAuthorizationConfigurationRepository _configurationRepository;

        private readonly IJWTService _jwtService;

        public AuthInterface(ILoggerService logger, ICacheService cacheWCF, IAuthorizationConfigurationRepository configurationRepository, IJWTService jwtService)
        {
            this._logger = logger;
            this._cacheWCF = cacheWCF;
            this._configurationRepository = configurationRepository;
            this._jwtService = jwtService;
        }

        public async Task<Session> Authorize(Session authData)
        {
            // validate user data
            if (this.ValidateUserData(authData))
            {
                // user authorization data is not valid.
                throw new ArgumentNullException(nameof(authData));
            }

            // check whether user is in database




            // get session from cache by username
            var configuration = this._configurationRepository.Get();

            var sessionFromCache = await this.GetSessionFromCache(authData);

            if (sessionFromCache != null && sessionFromCache.FailedLoginAttempts.Count >= configuration.MaximumLoginFailures)
            {
                if (sessionFromCache.FailedLoginAttempts.Max() > DateTime.Now.AddHours(-(configuration.AccountBlockTime)))
                {
                    throw new SessionException(
                            $"Account blocked till {sessionFromCache.FailedLoginAttempts.Max().AddHours(configuration.AccountBlockTime)}",
                            ErrorCode.AccountBlocked,
                            sessionFromCache.FailedLoginAttempts.Max().AddHours(configuration.AccountBlockTime));
                }
            }

            if (sessionFromCache?.FailedLoginAttempts != null)
            {
                authData.FailedLoginAttempts = sessionFromCache?.FailedLoginAttempts;
            }
            else
            {
                authData.FailedLoginAttempts = new List<DateTime>();
            }

            // generate json web tokens
            this._jwtService.SecretKey = configuration.JWTSecretKey;
            var jwtContainerModel = this._jwtService.CreateContainer(authData);
            authData.Token = this._jwtService.GenerateToken(jwtContainerModel);
            authData.TokenValidity = DateTime.Now.AddMinutes(jwtContainerModel.ExpireMinutes);


            // cleanup the failed login attempts
            if (authData.FailedLoginAttempts == null)
                authData.FailedLoginAttempts = new List<DateTime>();
            else authData.FailedLoginAttempts.Clear();


            // add session to cache
            await this._cacheWCF.AddSessionAsync(authData);

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
