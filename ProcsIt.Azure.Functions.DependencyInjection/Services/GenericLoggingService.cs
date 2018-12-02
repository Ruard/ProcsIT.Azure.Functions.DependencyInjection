using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcsIT.Azure.Functions.DependencyInjection.Services
{
    public class GenericLoggingService<T> : ILogger<T>
    {
        private ILogger _logger;

        public GenericLoggingService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetLoggerName());
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (_logger == null)
                return false;

            return _logger.IsEnabled(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var jsonLine = JsonConvert.SerializeObject(new
            {
                logLevel,
                eventId,
                parameters = (state as IEnumerable<KeyValuePair<string, object>>)?.ToDictionary(i => i.Key, i => i.Value),
                message = formatter(state, exception),
                exception = exception?.GetType().Name
            });

            _logger.Log(logLevel, eventId, state, exception, MyFormatter);

        }

        public string MyFormatter<TState>(TState state, Exception exception)
        {
            // create some string
            return state.ToString();
        }

        private static string GetLoggerName() // (Type declaringType)
        {
            // why this is necessary: https://www.neovolve.com/2018/04/05/dependency-injection-and-ilogger-in-azure-functions/
            return "Function." + typeof(T).FullName + ".User";
        }

    }
}
