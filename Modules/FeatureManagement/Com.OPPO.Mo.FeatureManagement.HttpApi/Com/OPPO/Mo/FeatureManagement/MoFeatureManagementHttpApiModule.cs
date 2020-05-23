using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Com.OPPO.Mo.FeatureManagement.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Com.OPPO.Mo.FeatureManagement
{
    [DependsOn(
    typeof(MoFeatureManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
    public class MoFeatureManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MoFeatureManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MoFeatureManagementResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
