using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Blogging.EntityFrameworkCore
{
    [DependsOn(
    typeof(MoBloggingDomainModule),
    typeof(AbpEntityFrameworkCoreModule))]
    public class MoBloggingEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BloggingDbContext>();
        }
    }
}
