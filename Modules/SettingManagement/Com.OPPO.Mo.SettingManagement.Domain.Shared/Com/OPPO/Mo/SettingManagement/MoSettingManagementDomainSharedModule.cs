using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Com.OPPO.Mo.SettingManagement.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Com.OPPO.Mo.SettingManagement
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class MoSettingManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoSettingManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MoSettingManagementResource>("en")
                    .AddVirtualJson("/Com/OPPO/Mo/SettingManagement/Localization/Resources");
            });
        }
    }
}
