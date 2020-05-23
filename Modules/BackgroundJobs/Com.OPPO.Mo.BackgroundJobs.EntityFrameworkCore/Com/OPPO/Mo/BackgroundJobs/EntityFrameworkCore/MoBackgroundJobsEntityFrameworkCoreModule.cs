using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.BackgroundJobs.EntityFrameworkCore
{
    [DependsOn(
    typeof(MoBackgroundJobsDomainModule),
    typeof(AbpEntityFrameworkCoreModule)    )]
    public class MoBackgroundJobsEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BackgroundJobsDbContext>(options =>
            {
                 options.AddRepository<BackgroundJobRecord, EfCoreBackgroundJobRepository>();
            });
        }
    }
}