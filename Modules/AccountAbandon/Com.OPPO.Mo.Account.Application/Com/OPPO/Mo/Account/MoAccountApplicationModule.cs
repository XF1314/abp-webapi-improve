using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Com.OPPO.Mo.Identity;

namespace Com.OPPO.Mo.Account
{
    [DependsOn(
    typeof(MoAccountApplicationContractsModule),
    typeof(MoIdentityApplicationModule),
    typeof(AbpUiNavigationModule)    )]
    public class MoAccountApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoAccountApplicationModule>();
            });
        }
    }
}