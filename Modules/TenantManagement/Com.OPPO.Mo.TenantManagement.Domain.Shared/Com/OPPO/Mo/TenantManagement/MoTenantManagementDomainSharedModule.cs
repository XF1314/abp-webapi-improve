using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Com.OPPO.Mo.TenantManagement.Localization;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Com.OPPO.Mo.TenantManagement
{
    [DependsOn(typeof(AbpValidationModule))]
    public class MoTenantManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoTenantManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MoTenantManagementResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Com/OPPO/Mo/TenantManagement/Localization/Resources");
            });
        }
    }
}
