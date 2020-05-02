using Castle.DynamicProxy;
using HardwareInventoryService.Models;
using HardwareInventoryService.Models.Exceptions;
using HardwareInventoryService.Models.Models;
using HardwareInventoryService.Models.Models.Enums;
using HardwareInventoryService.ServicesReferences.Contracts;
using NLog;
using System;
using ExceptionDetail = HardwareInventoryService.Models.Models.ExceptionDetail;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.ServicesReferences.Interceptors
{
    public class ExceptionLoggingInterceptor : IInterceptor
    {
        private readonly ILoggerService _loggerService;

        public ExceptionLoggingInterceptor(ILoggerService loggerService)
        {
            this._loggerService = loggerService;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.DeclaringType?.Name}.{invocation.Method.Name}";
            try
            {
                invocation.Proceed();
            }
            catch (SessionException exception)
            {
                this.SessionExceptionHandler(invocation, exception);
            }
            catch (FaultException<ExceptionDetail> exception)
            {
                this.FaultExceptionHandler(invocation, exception);
            }
            catch (FaultException exception)
            {
                this.FaultExceptionHandler(invocation, exception);
            }
            catch (NotFoundException exception)
            {
                this.NotFoundExceptionHandler(invocation, exception);
            }
            catch (ArgumentNullException exception)
            {
                this.ArgumentNullExceptionHandler(invocation, exception);
            }
            catch (EndpointNotFoundException exception)
            {
                this.EndpointNotFoundExceptionHandler(invocation, exception);
            }
            catch (AggregateException exception)
            {
                foreach (Exception ex in exception.InnerExceptions)
                {
                    if (ex is SessionException)
                        this.SessionExceptionHandler(invocation, (SessionException)ex);
                    if (ex is ArgumentNullException)
                        this.ArgumentNullExceptionHandler(invocation, (ArgumentNullException)ex);
                    else if (ex is EndpointNotFoundException)
                        this.EndpointNotFoundExceptionHandler(invocation, (EndpointNotFoundException)ex);
                    else this.ExceptionHandler(invocation, ex);
                }
            }
            catch (Exception exception)
            {
                this.ExceptionHandler(invocation, exception);
            }
        }

        private void ArgumentNullExceptionHandler(IInvocation invocation, ArgumentNullException exception)
        {
            var methodName = invocation.Method.Name;
            var message = $"Parameter in method {methodName} is not valid.";
            this._loggerService.LogMessage(message, LogLevel.Error);

            this._loggerService.LogMessage(
                new LogMessage
                {
                    ClassName = this.ToString(),
                    Message = exception.Message,
                    MethodName = invocation.Method.Name
                },
                LogLevel.Debug);

            throw new System.ServiceModel.FaultException<ExceptionDetail>(
                new ExceptionDetail(
                    false,
                    exception.Message,
                    methodName,
                    status: ErrorCode.ArgumentNullError,
                    exceptionType: exception.GetType()),
                message
            );
        }

        private void SessionExceptionHandler(IInvocation invocation, SessionException exception)
        {
            var methodName = invocation.Method.Name;
            var message = $"{exception.Message} error in method {methodName}.";
            this._loggerService.LogMessage(message, LogLevel.Error);

            this._loggerService.LogMessage(
                new LogMessage
                {
                    ClassName = this.ToString(),
                    Message = exception.Message,
                    MethodName = invocation.Method.Name
                },
                LogLevel.Debug);

            throw new System.ServiceModel.FaultException<ExceptionDetail>(
                new ExceptionDetail(
                    false,
                    exception.Message,
                    description: methodName,
                    status: exception.errorCode != 0 ? exception.errorCode : ErrorCode.SessionError,
                    exceptionType: exception.GetType(),
                    loginAttempts: exception.attemptsLeft,
                    blockedTill: exception.blockedTill
                    ),
                message
            );
        }

        private void ExceptionHandler(IInvocation invocation, Exception exception)
        {
            var methodName = invocation.Method.Name;
            this._loggerService.LogMessage($"Fatal error {exception.InnerException?.GetType() ?? exception.GetType()} occurred in method {methodName}",
                LogLevel.Fatal);

            this._loggerService.LogMessage(
                new LogMessage
                {
                    ClassName = invocation.Method.ReflectedType?.FullName,
                    Message = exception.InnerException?.StackTrace ?? exception.StackTrace,
                    MethodName = methodName
                },
                LogLevel.Trace);

            throw new System.ServiceModel.FaultException<ExceptionDetail>(
                new ExceptionDetail(
                    false,
                    message: exception.InnerException?.Message ?? exception.Message,
                    description: methodName,
                    status: ErrorCode.Undefined,
                    exceptionType: exception.InnerException?.GetType() ?? exception.GetType()),
                exception.Message
                );
        }

        private void NotFoundExceptionHandler(IInvocation invocation, NotFoundException exception)
        {
            var methodName = invocation.Method.Name;
            var message = $"Not found error in method {methodName}. {exception.Message}";
            this._loggerService.LogMessage(message, LogLevel.Error);

            this._loggerService.LogMessage(
                new LogMessage
                {
                    ClassName = this.ToString(),
                    Message = exception.Message,
                    MethodName = invocation.Method.Name
                },
                LogLevel.Debug);

            throw new System.ServiceModel.FaultException<ExceptionDetail>(
                new ExceptionDetail(
                    false,
                    message,
                    methodName,
                    status: ErrorCode.NotFoundInCache,
                    exceptionType: exception.GetType()),
                message
            );
        }

        private void FaultExceptionHandler(IInvocation invocation, FaultException<ExceptionDetail> exception)
        {
            var methodName = invocation.Method.Name;
            this._loggerService.LogMessage($"Warning in method {methodName}: {exception.Detail.Message}", LogLevel.Error);

            this._loggerService.LogMessage(
                new LogMessage
                {
                    ClassName = this.ToString(),
                    Message = exception.Detail.Message,
                    MethodName = methodName
                },
                LogLevel.Debug);

            throw exception;
        }

        private void FaultExceptionHandler(IInvocation invocation, FaultException exception)
        {
            //FaultException from OBCInterface
            var methodName = invocation.Method.Name;
            this._loggerService.LogMessage($"Warning in method {methodName}: {exception.Message}", LogLevel.Error);

            this._loggerService.LogMessage(
                new LogMessage
                {
                    ClassName = this.ToString(),
                    Message = exception.Message,
                    MethodName = methodName
                },
                LogLevel.Debug);
            throw exception;
        }

        private void EndpointNotFoundExceptionHandler(IInvocation invocation, EndpointNotFoundException exception)
        {
            var methodName = invocation.Method.Name;
            var message = $"{exception.Message} error in method {methodName}.";
            this._loggerService.LogMessage(message, LogLevel.Error);

            this._loggerService.LogMessage(
                new LogMessage
                {
                    ClassName = this.ToString(),
                    Message = exception.Message,
                    MethodName = invocation.Method.Name
                },
                LogLevel.Debug);

            throw new System.ServiceModel.FaultException<ExceptionDetail>(
                new ExceptionDetail(
                    false,
                    $"{exception.Message} error in method {methodName}.",
                    methodName,
                    status: ErrorCode.ConnectionError,
                    exceptionType: exception.GetType()),
                message
            );
        }
    }
}
