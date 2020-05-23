using Volo.Abp.Caching;
using Com.OPPO.Mo.FeatureManagement.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Com.OPPO.Mo.FeatureManagement
{
    [DependsOn(
    typeof(MoFeatureManagementDomainSharedModule),
    typeof(AbpFeaturesModule),
    typeof(AbpCachingModule))]
    public class MoFeatureManagementDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<FeatureManagementOptions>(options =>
            {
                options.Providers.Add<DefaultValueFeatureManagementProvider>();
                options.Providers.Add<EditionFeatureManagementProvider>();

                //TODO: Should be moved to the Tenant Management module
                options.Providers.Add<TenantFeatureManagementProvider>();
                options.ProviderPolicies[TenantFeatureValueProvider.ProviderName] = "MoTenantManagement.Tenants.ManageFeatures";
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("MoFeatureManagement", typeof(MoFeatureManagementResource));
            });
        }
    }
}
