using System;
using System.Collections.Generic;
using Exceptionless;
using Microsoft.Extensions.Logging;

namespace Com.OPPO.Mo.ExceptionlessExtensions
{
    public class ExceptionlessLogger : ILogger
    {
        private readonly ExceptionlessClient _client;
        private readonly string _source;

        public ExceptionlessLogger(ExceptionlessClient client, string source)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _source = source;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            // Typically a string will be used as the state for a scope, but the BeginScope extension provides
            // a FormattedLogValues and ASP.NET provides multiple scope objects, so just use ToString()
            string description = state.ToString();

            var scope = new ExceptionlessLoggingScope(description);

            // Add to stack to support nesting within execution context
            ExceptionlessLoggingScope.Push(scope);
            return scope;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel == LogLevel.None || !_client.Configuration.IsValid)
                return false;

            var minLogLevel = _client.Configuration.Settings.GetMinLogLevel(_source);
            return logLevel.ToLogLevel() >= minLogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            string message = formatter is null ? exception.Message : formatter(state, exception);
            if (string.IsNullOrEmpty(message) && exception == null)
                return;

            var builder = exception == null ? _client.CreateLog(_source, message, logLevel.ToLogLevel()) : _client.CreateException(exception);
            builder.Target.Date = DateTimeOffset.Now;

            if (!string.IsNullOrEmpty(message))
                builder.SetMessage(message);

            if (exception != null)
                builder.SetSource(_source);

            // Add event id, if available
            if (eventId.Id != 0)
                builder.SetProperty("EventId", eventId.Id);

            // If within a scope, add scope's reference id
            if (ExceptionlessLoggingScope.Current != null)
                builder.SetEventReference("Parent", ExceptionlessLoggingScope.Current.Id);

            // The logging framework passes in FormattedLogValues, which implements IEnumerable<KeyValuePair<string, object>>;
            // add each property and value as individual objects for proper visibility in Exceptionless
            if (state is IEnumerable<KeyValuePair<string, object>> stateProps)
            {
                foreach (var prop in stateProps)
                {
                    // Logging the message template is superfluous
                    if (prop.Key != "{OriginalFormat}")
                        builder.SetProperty(prop.Key, prop.Value);
                }
            }
            else
            {
                // Otherwise, attach the entire object, using its type as the name
                builder.AddObject(state);
            }

            builder.Submit();
        }
    }
}