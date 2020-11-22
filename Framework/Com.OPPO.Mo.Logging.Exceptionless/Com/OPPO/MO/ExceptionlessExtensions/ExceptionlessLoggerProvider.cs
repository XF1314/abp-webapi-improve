using Exceptionless;
using Microsoft.Extensions.Logging;
using System;

namespace Com.OPPO.Mo.ExceptionlessExtensions
{
    public class ExceptionlessLoggerProvider : ILoggerProvider
    {
        private readonly ExceptionlessClient _client;
        private readonly bool _shouldDispose;

        public ExceptionlessLoggerProvider(ExceptionlessClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <param name="configure">An <see cref="Action{ExceptionlessConfiguration}"/> which will be used to configure created loggers.</param>
        public ExceptionlessLoggerProvider(Action<ExceptionlessConfiguration> configure)
        {
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            _client = new ExceptionlessClient(configure);
            _shouldDispose = true;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ExceptionlessLogger(_client, categoryName);
        }

        public void Dispose()
        {
            _client.ProcessQueue();
            if (_shouldDispose)
                ((IDisposable)_client).Dispose();
        }
    }
}