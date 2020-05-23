using Volo.Abp.AspNetCore.Mvc;
using Com.OPPO.Mo.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;

namespace Com.OPPO.Mo.Identity
{
    [DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(MoIdentityApplicationContractsModule))]
    public class MoIdentityHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MoIdentityHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<IdentityResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}