using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.AuditLogging.EntityFrameworkCore
{
    [DependsOn(typeof(MoAuditLoggingDomainModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class MoAuditLoggingEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MoAuditLoggingDbContext>(options =>
            {
                options.AddRepository<AuditLog, EfCoreAuditLogRepository>();
            });
        }
    }
}
