using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Com.OPPO.Mo.Blogging.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Com.OPPO.Mo.Blogging
{
    [DependsOn(typeof(AbpValidationModule))]
    public class MoBloggingDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoBloggingDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<BloggingResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Com/OPPO/Mo/Blogging/Localization/Resources");
            });
        }
    }
}
