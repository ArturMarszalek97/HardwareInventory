using Castle.DynamicProxy;
using HardwareInventoryService.Models.Models;
using HardwareInventoryService.ServicesReferences.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.ServicesReferences.Interceptors
{
    public class MethodLoggingInterceptor : IInterceptor
    {
        private readonly ILoggerService _loggerService;

        public MethodLoggingInterceptor(ILoggerService loggerService)
        {
            this._loggerService = loggerService;
        }

        public void Intercept(IInvocation invocation)
        {
            this._loggerService.LogMessage($"Method {invocation.Method.DeclaringType?.Name}.{invocation.Method.Name} invoked", LogLevel.Info);

            var parameters = invocation.Arguments.ToList();
            //var parameters = Hashing.HashParameters(copy, invocation.Method);

            this._loggerService.LogMessage(new LogMessage
            {
                ClassName = invocation.TargetType.Name,
                MethodName = invocation.Method.Name,
                Parameters = parameters,
            }, LogLevel.Debug);

            invocation.Proceed();

            this._loggerService.LogMessage($"Method {invocation.Method.DeclaringType?.Name}.{invocation.Method.Name} finished", LogLevel.Info);
        }
    }
}
