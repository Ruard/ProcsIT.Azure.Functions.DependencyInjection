using Microsoft.Extensions.Logging;
using System;

namespace ProcsIT.Azure.Functions.SampleFunctionApp.Services
{
    public class LoggingService : ILogger
    {
        private ILogger _logger;

        public LoggingService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(ILogger));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger?.IsEnabled(logLevel) ?? false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (_logger != null)
                _logger.Log(logLevel, eventId, state, exception, MyFormatter);
        }

        public string MyFormatter<TState>(TState state, Exception exception)
        {
            // create some string
            return state.ToString();
        }

        private static string GetLoggerName()
        {
            // why this is necessary: https://www.neovolve.com/2018/04/05/dependency-injection-and-ilogger-in-azure-functions/
            return "Function." + typeof(ILogger).FullName + ".User";
        }

    }
}
