using Castle.DynamicProxy;
using HardwareInventoryService.ServicesReferences.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.ServicesReferences.Interceptors
{
    public class TimeMeasuringInterceptor : IInterceptor
    {
        private readonly ILoggerService _loggerService;

        public TimeMeasuringInterceptor(ILoggerService loggerService)
        {
            this._loggerService = loggerService;
        }

        public void Intercept(IInvocation invocation)
        {
            var executionWatch = Stopwatch.StartNew();
            executionWatch.Start();

            invocation.Proceed();

            executionWatch.Stop();
            this._loggerService.LogMessage($"Method {invocation.Method.DeclaringType?.Name}.{invocation.Method.Name} execution time {executionWatch.ElapsedMilliseconds}ms.", LogLevel.Debug);

        }
    }
}
