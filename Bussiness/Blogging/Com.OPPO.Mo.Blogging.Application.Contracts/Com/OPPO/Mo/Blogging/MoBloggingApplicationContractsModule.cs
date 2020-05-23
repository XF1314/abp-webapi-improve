using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Com.OPPO.Mo.Blogging.Localization;

namespace Com.OPPO.Mo.Blogging
{
    [DependsOn(typeof(MoBloggingDomainSharedModule))]
    public class MoBloggingApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoBloggingApplicationContractsModule>();
            });
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BloggingResource>()
                    .AddVirtualJson("/Com/OPPO/Mo/Blogging/Contract/Localization/Resources");
            });
        }
    }
}
