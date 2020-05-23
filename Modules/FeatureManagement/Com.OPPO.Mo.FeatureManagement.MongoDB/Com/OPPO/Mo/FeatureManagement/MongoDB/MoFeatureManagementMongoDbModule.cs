using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.FeatureManagement.MongoDB
{
    [DependsOn(
    typeof(MoFeatureManagementDomainModule),
    typeof(AbpMongoDbModule))]
    public class MoFeatureManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<FeatureManagementMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<IFeatureManagementMongoDbContext>();

                options.AddRepository<FeatureValue, MongoFeatureValueRepository>();
            });
        }
    }
}
