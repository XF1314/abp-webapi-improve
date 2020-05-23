using Localization.Resources.AbpUi;
using Com.OPPO.Mo.Account.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Com.OPPO.Mo.Identity;

namespace Com.OPPO.Mo.Account
{
    [DependsOn(
    typeof(MoAccountApplicationContractsModule),
    typeof(MoIdentityHttpApiModule),
    typeof(AbpAspNetCoreMvcModule))]
    public class MoAccountHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MoAccountHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AccountResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}