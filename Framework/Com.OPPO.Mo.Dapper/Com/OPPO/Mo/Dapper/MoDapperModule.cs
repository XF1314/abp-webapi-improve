using Volo.Abp.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Dapper
{
    [DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpEntityFrameworkCoreModule))]
    public class MoDapperModule : AbpModule
    {

    }
}