using HardwareInventoryService.Models.Attributes;
using HardwareInventoryService.Models.Helpers;
using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Authorization.Host.Interfaces;
using HardwareInventoryService.Modules.Authorization.Logic.Helpers;
using HardwareInventoryService.Modules.Authorization.Logic.Interfaces;
using HardwareInventoryService.ServicesReferences.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Session = HardwareInventoryService.Models.Models.Authorization.Session;

namespace HardwareInventoryService.Modules.Authorization.Host.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AuthorizationWCFContract : IAuthorizationWCFContract
    {
        private readonly IAuthInterface _authInterface;

        private readonly ILoggerService _loggerService;

        public AuthorizationWCFContract()
        {

        }

        public AuthorizationWCFContract(ILoggerService logger, IAuthInterface authInterface)
        {
            this._loggerService = logger;
            this._authInterface = authInterface;
        }

        public virtual Session Authorize(Session authData)
        {
            var authResult = this._authInterface.Authorize(authData).Result;

            if (authResult.TokenValidity > DateTime.Now)
            {
                this._loggerService.LogMessage(
                    string.Format(StringContainer.SuccessfullyLoggedIn, authData.Username), LogLevel.Info);
            }
            else
            {
                this._loggerService.LogMessage(string.Format(StringContainer.FailedLoggingIn, authData.Username),
                    LogLevel.Info);
            }

            this._loggerService.LogMessage(
                string.Format(CommonContainer.InfoMethodCompleted, nameof(this.Authorize)), LogLevel.Info);

            authResult.Password = string.Empty;

            return authResult;
        }

        public virtual bool Deauthorize(Session authData)
        {
            var authResult = this._authInterface.Deauthorize(authData).Result;

            if (authResult)
            {
                this._loggerService.LogMessage(
                    string.Format(StringContainer.SuccessfullyLoggedOut, authData.Username), LogLevel.Info);
            }
            else
            {
                this._loggerService.LogMessage(string.Format(StringContainer.FailedLoggingOut, authData.Username),
                    LogLevel.Info);
            }

            this._loggerService.LogMessage(
                string.Format(CommonContainer.InfoMethodCompleted, nameof(this.Deauthorize)), LogLevel.Info);

            return authResult;
        }

        public virtual bool ChangePassword(string username, [HashDataForLog] string password, [HashDataForLog] string newPassword)
        {
            return this._authInterface.ChangePassword(username, password, newPassword).Result;
        }


    }
}
