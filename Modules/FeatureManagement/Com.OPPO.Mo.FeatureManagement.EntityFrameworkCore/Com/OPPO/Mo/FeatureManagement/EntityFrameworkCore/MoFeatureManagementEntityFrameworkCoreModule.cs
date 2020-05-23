using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.FeatureManagement.EntityFrameworkCore
{
    [DependsOn(
    typeof(MoFeatureManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule))]
    public class MoFeatureManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<FeatureManagementDbContext>(options =>
            {
                options.AddDefaultRepositories<IFeatureManagementDbContext>();

                options.AddRepository<FeatureValue, EfCoreFeatureValueRepository>();
            });
        }
    }
}