using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.FeatureManagement
{
    [DependsOn(
    typeof(MoFeatureManagementDomainModule),
    typeof(MoFeatureManagementApplicationContractsModule),
    typeof(AbpAutoMapperModule)        )]
    public class MoFeatureManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoFeatureManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<FeatureManagementApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
