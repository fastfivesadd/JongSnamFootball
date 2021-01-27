using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace JongSnamFootball.Repositories
{
    public abstract class BaseLogger
    {
        protected readonly ILogger _logger;

        protected BaseLogger(ILogger logger)
        {
            _logger = logger;
        }

        protected virtual void LogStart([CallerMemberName] string methodName = "")
        {
            _logger.LogDebug("The method {0} was started.", methodName);
        }

        protected virtual void LogEnd([CallerMemberName] string methodName = "")
        {
            _logger.LogDebug("The method {0} was end.", methodName);
        }

        protected virtual void LogError(Exception exception, [CallerMemberName] string methodName = "")
        {
            _logger.LogError(exception, "The method {0} got an error.", methodName);
        }

    }
}
