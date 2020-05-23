using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.BackgroundJobs.MongoDB
{
    [DependsOn(
    typeof(MoBackgroundJobsDomainModule),
    typeof(AbpMongoDbModule)        )]
    public class MoBackgroundJobsMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<BackgroundJobsMongoDbContext>(options =>
            {
                 options.AddRepository<BackgroundJobRecord, MongoBackgroundJobRepository>();
            });
        }
    }
}
