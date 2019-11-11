using HardwareInventoryService.Models.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.ServicesReferences.Contracts
{
    public interface ILoggerService
    {
        Logger GetLogger();

        void LogMessage(LogMessage logMessage, LogLevel logLevel);

        void LogMessage(string message, LogLevel messageType);

        void FatalException(string className, string methodName, Exception exception);

        void OtherException(string className, string methodName, Exception exception);
    }
}
