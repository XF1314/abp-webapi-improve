using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.AuditLogging.MongoDB
{
    [DependsOn(typeof(MoAuditLoggingDomainModule))]
    [DependsOn(typeof(AbpMongoDbModule))]
    public class MoAuditLoggingMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<AuditLoggingMongoDbContext>(options =>
            {
                options.AddRepository<AuditLog, MongoAuditLogRepository>();
            });
        }
    }
}
