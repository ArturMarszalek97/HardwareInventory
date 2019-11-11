using HardwareInventoryService.Models.Helpers;
using HardwareInventoryService.Models.Models;
using HardwareInventoryService.ServicesReferences.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ExceptionDetail = HardwareInventoryService.Models.Models.ExceptionDetail;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.ServicesReferences.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly string _applicationName;

        private readonly Logger _logger;

        public LoggerService()
        {
            this._applicationName = "wcfService";
            this._logger = LogManager.GetLogger("wcfService");
        }

        public LoggerService(string applicationName)
        {
            this._applicationName = applicationName;
            this._logger = LogManager.GetLogger(applicationName);
        }

        public void FatalException(string className, string methodName, Exception exception)
        {
            if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(className))
            {
                if (exception != null)
                {
                    this.LogMessage(string.Format(
                        CommonContainer.FatalStringGeneralWithArgument, exception.Message,
                        methodName), LogLevel.Fatal);

                    this.LogMessage(new LogMessage
                    {
                        ClassName = className,
                        Message = exception.StackTrace,
                        MethodName = methodName
                    }, LogLevel.Trace);
                }
            }
        }

        public Logger GetLogger()
        {
            return this._logger;
        }

        public void LogMessage(LogMessage message, LogLevel logLevel)
        {
            if (message != null)
            {
                message.Application = this._applicationName;
                this._logger.Log(logLevel, "{@LogMessage}", message);
            }
        }

        public void LogMessage(string message, LogLevel logLevel)
        {
            if (!string.IsNullOrEmpty(message)) 
                this._logger.Log(logLevel, message);
        }

        public void OtherException(string className, string methodName, Exception exception)
        {
            if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(className))
            {
                if (exception != null)
                {
                    var message = exception.Message;
                    if (exception is FaultException<ExceptionDetail>)
                    {
                        var faultEx = (FaultException<ExceptionDetail>)exception;
                        message = faultEx.Detail != null ? faultEx.Detail.Message : exception.Message;
                    }

                    this.LogMessage(string.Format(
                        CommonContainer.ErrorStringGeneralWithArgument, message,
                        methodName), LogLevel.Error);

                    this.LogMessage(new LogMessage
                    {
                        ClassName = className,
                        Message = message,
                        MethodName = methodName
                    }, LogLevel.Debug);
                }
            }
        }
    }
}
