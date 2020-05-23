using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Com.OPPO.Mo.TenantManagement.Localization;
using Microsoft.Extensions.DependencyInjection;
using Com.OPPO.Mo.FeatureManagement;
using Com.OPPO.Mo.FeatureManagement.Localization;

namespace Com.OPPO.Mo.TenantManagement
{
    [DependsOn(
    typeof(MoTenantManagementApplicationContractsModule),
    typeof(MoFeatureManagementHttpApiModule),
    typeof(AbpAspNetCoreMvcModule))]
    public class MoTenantManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MoTenantManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MoTenantManagementResource>()
                    .AddBaseTypes(
                        typeof(MoFeatureManagementResource),
                        typeof(AbpUiResource));
            });
        }
    }
}