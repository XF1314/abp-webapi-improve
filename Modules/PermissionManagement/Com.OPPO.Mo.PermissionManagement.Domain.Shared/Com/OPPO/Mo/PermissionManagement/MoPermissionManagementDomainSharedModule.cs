using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Com.OPPO.Mo.PermissionManagement.Localization;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Com.OPPO.Mo.PermissionManagement
{
    [DependsOn(
    typeof(AbpValidationModule))]
    public class MoPermissionManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoPermissionManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MoPermissionManagementResource>("en")
                    .AddBaseTypes(
                        typeof(AbpValidationResource)
                    ).AddVirtualJson("/Com/OPPO/Mo/PermissionManagement/Localization/Resources");
            });
        }
    }
}
