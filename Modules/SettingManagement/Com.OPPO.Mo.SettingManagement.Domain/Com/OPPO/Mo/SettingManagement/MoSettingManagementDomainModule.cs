using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.SettingManagement
{
    [DependsOn(
    typeof(AbpSettingsModule),
    typeof(AbpDddDomainModule),
    typeof(MoSettingManagementDomainSharedModule),
    typeof(AbpCachingModule))]
    public class MoSettingManagementDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<SettingManagementOptions>(options =>
            {
                options.Providers.Add<DefaultValueSettingManagementProvider>();
                options.Providers.Add<ConfigurationSettingManagementProvider>();
                options.Providers.Add<GlobalSettingManagementProvider>();
                options.Providers.Add<TenantSettingManagementProvider>();
                options.Providers.Add<UserSettingManagementProvider>();
            });
        }
    }
}
