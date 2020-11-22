using Com.OPPO.Mo.Bpm;
using Exceptionless;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.BpmService
{
    [AllowAnonymous]
    public class HomeController : AbpController
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly ISettingProvider _settingProvider;
        private readonly IOptions<AbpSettingOptions> _options;
        private readonly ISettingDefinitionManager _settingDefinitionManager;

        public HomeController(
            IConfiguration configuration,
            ILogger<HomeController> logger,
            IServiceProvider serviceProvider,
            ISettingProvider settingProvider,
            IOptions<AbpSettingOptions> options,
            ISettingDefinitionManager settingDefinitionManager)
        {
            _logger = logger;
            _options = options;
            _configuration = configuration;
            _settingProvider = settingProvider;
            _serviceProvider = serviceProvider;
            _settingDefinitionManager = settingDefinitionManager;
        }


        public async Task<ActionResult> Index()
        {
            var kk = _configuration.GetValue<string>("TestKey");
            var ks = _configuration.GetValue<string>("WebApiHost");
            var ss = _configuration.GetValue<string>(BpmSettingNames.ActiontSoftWebApiHost);
            var settingDefinition = _settingDefinitionManager.Get(BpmSettingNames.ActiontSoftWebApiHost);
            //var settingDefinition = _settingDefinitionManager.Get(LocalizationSettingNames.DefaultLanguage);
            var providers = _options.Value.ValueProviders;
            var settingValueProviders = providers.Select(x => _serviceProvider.GetRequiredService(x) as ISettingValueProvider).Reverse();
            if (settingDefinition.Providers.Any())
            {
                settingValueProviders = settingValueProviders.Where(p => settingDefinition.Providers.Contains(p.Name));
            }
            //var value = await GetOrNullValueFromProvidersAsync(settingValueProviders, settingDefinition);
            //var ss = await _settingProvider.GetOrNullAsync(LocalizationSettingNames.DefaultLanguage);
            var all = _settingDefinitionManager.GetAll();

            return Redirect("/swagger");
        }

        protected virtual async Task<string> GetOrNullValueFromProvidersAsync(
            IEnumerable<ISettingValueProvider> providers,
            SettingDefinition setting)
        {
            foreach (var provider in providers)
            {
                var value = await provider.GetOrNullAsync(setting);
                if (value != null)
                {
                    return value;
                }
            }

            return null;
        }
    }
}
