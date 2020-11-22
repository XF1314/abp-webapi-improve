using Exceptionless;
using Exceptionless.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.MO.ExceptionlessExtensions
{
    public static class ExceptionlessConfigurationExtension
    {
        public static void ReadFromConfiguration(this ExceptionlessConfiguration config, IConfiguration settings)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var section = settings.GetSection("Exceptionless");

            string apiKey = section["ApiKey"];
            if (!string.IsNullOrEmpty(apiKey) && apiKey != "API_KEY_HERE")
                config.ApiKey = apiKey;

            foreach (var data in section.GetSection("DefaultData").GetChildren())
                if (data.Value != null)
                    config.DefaultData[data.Key] = data.Value;

            foreach (var tag in section.GetSection("DefaultTags").GetChildren())
                config.DefaultTags.Add(tag.Value);

            if (bool.TryParse(section["Enabled"], out bool enabled) && !enabled)
                config.Enabled = false;

            if (bool.TryParse(section["IncludePrivateInformation"], out bool includePrivateInformation) && !includePrivateInformation)
                config.IncludePrivateInformation = false;

            string serverUrl = section["ServerUrl"];
            if (!string.IsNullOrEmpty(serverUrl))
                config.ServerUrl = serverUrl;

            string storagePath = section["StoragePath"];
            if (!string.IsNullOrEmpty(storagePath))
                config.Resolver.Register(typeof(IObjectStorage), () => new FolderObjectStorage(config.Resolver, storagePath));

            foreach (var setting in section.GetSection("Settings").GetChildren())
                if (setting.Value != null)
                    config.Settings[setting.Key] = setting.Value;
        }
    }
}
