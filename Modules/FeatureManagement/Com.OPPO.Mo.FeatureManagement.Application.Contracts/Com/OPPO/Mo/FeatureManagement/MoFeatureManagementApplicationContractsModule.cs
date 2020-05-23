using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Com.OPPO.Mo.FeatureManagement
{
    [DependsOn(
    typeof(MoFeatureManagementDomainSharedModule),
    typeof(AbpDddApplicationModule)        )]
    public class MoFeatureManagementApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoFeatureManagementApplicationContractsModule>();
            });
        }
    }
}
