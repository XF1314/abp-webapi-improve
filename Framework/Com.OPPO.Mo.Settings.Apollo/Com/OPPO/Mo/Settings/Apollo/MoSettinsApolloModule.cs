using System;
using System.Collections.Generic;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.Settings.Apollo
{
    //配置中心接入
    [DependsOn(typeof(MoCoreModule))]
    [DependsOn(typeof(AbpSettingsModule))]

    public class MoSettinsApolloModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpSettingOptions>(options =>
            {
                options.ValueProviders.Clear();
                options.ValueProviders.Add<DefaultValueSettingValueProvider>();
                options.ValueProviders.Add<ApolloSettingValueProvider>();
                options.ValueProviders.Add<ConfigurationSettingValueProvider>();
                options.ValueProviders.Add<GlobalSettingValueProvider>();
                options.ValueProviders.Add<TenantSettingValueProvider>();
                options.ValueProviders.Add<UserSettingValueProvider>();
            });
        }

    }
}
