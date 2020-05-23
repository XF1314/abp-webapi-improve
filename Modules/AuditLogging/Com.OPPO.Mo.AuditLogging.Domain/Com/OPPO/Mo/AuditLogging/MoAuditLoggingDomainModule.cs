using Volo.Abp.Auditing;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.AuditLogging
{
    [DependsOn(typeof(AbpAuditingModule))]
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(MoAuditLoggingDomainSharedModule))]
    public class MoAuditLoggingDomainModule : AbpModule
    {

    }
}
