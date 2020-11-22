using System;
using ExceptionlessLogLevel = Exceptionless.Logging.LogLevel;
using Microsoft.Extensions.Logging;
using Exceptionless;

namespace Com.OPPO.Mo.ExceptionlessExtensions
{
    public static class ExceptionlessLoggerExtension {
        public static ExceptionlessLogLevel ToLogLevel(this LogLevel level) {
            if (level == LogLevel.Trace)
                return ExceptionlessLogLevel.Trace;
            if (level == LogLevel.Debug)
                return ExceptionlessLogLevel.Debug;
            if (level == LogLevel.Information)
                return ExceptionlessLogLevel.Info;
            if (level == LogLevel.Warning)
                return ExceptionlessLogLevel.Warn;
            if (level == LogLevel.Error)
                return ExceptionlessLogLevel.Error;
            if (level == LogLevel.Critical)
                return ExceptionlessLogLevel.Fatal;
            if (level == LogLevel.None)
                return ExceptionlessLogLevel.Off;

            return ExceptionlessLogLevel.Off;
        }

        public static ILoggingBuilder AddExceptionless(this ILoggingBuilder builder, ExceptionlessClient client = null) {
            builder.AddProvider(new ExceptionlessLoggerProvider(client ?? ExceptionlessClient.Default));
            return builder;
        }

        public static ILoggingBuilder AddExceptionless(this ILoggingBuilder builder, string apiKey, string serverUrl = null) {
            if (String.IsNullOrEmpty(apiKey) && String.IsNullOrEmpty(serverUrl))
                return builder.AddExceptionless();

            builder.AddProvider(new ExceptionlessLoggerProvider(config => {
                if (!String.IsNullOrEmpty(apiKey) && apiKey != "API_KEY_HERE")
                    config.ApiKey = apiKey;
                if (!String.IsNullOrEmpty(serverUrl))
                    config.ServerUrl = serverUrl;

                config.UseInMemoryStorage();
            }));

            return builder;
        }

        public static ILoggingBuilder AddExceptionless(this ILoggingBuilder builder, Action<ExceptionlessConfiguration> configure) {
            builder.AddProvider(new ExceptionlessLoggerProvider(configure));
            return builder;
        }

        [Obsolete("Use ExceptionlessLoggerExtensions.AddExceptionless(ILoggingBuilder,ExceptionlessClient) instead.")]
        public static ILoggerFactory AddExceptionless(this ILoggerFactory factory, ExceptionlessClient client = null) {
            factory.AddProvider(new ExceptionlessLoggerProvider(client ?? ExceptionlessClient.Default));
            return factory;
        }

        [Obsolete("Use ExceptionlessLoggerExtensions.AddExceptionless(ILoggingBuilder,string,string) instead.")]
        public static ILoggerFactory AddExceptionless(this ILoggerFactory factory, string apiKey, string serverUrl = null) {
            if (String.IsNullOrEmpty(apiKey) && String.IsNullOrEmpty(serverUrl))
                return factory.AddExceptionless();

            factory.AddProvider(new ExceptionlessLoggerProvider(config => {
                if (!String.IsNullOrEmpty(apiKey) && apiKey != "API_KEY_HERE")
                    config.ApiKey = apiKey;
                if (!String.IsNullOrEmpty(serverUrl))
                    config.ServerUrl = serverUrl;

                config.UseInMemoryStorage();
            }));

            return factory;
        }


        [Obsolete("Use ExceptionlessLoggerExtensions.AddExceptionless(ILoggingBuilder,Action<ExceptionlessConfiguration>) instead.")]
        public static ILoggerFactory AddExceptionless(this ILoggerFactory factory, Action<ExceptionlessConfiguration> configure) {
            factory.AddProvider(new ExceptionlessLoggerProvider(configure));
            return factory;
        }
    }
}