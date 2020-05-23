using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Users
{
    [DependsOn(
    typeof(MoUsersDomainSharedModule),
    typeof(MoUsersAbstractionModule),
    typeof(AbpDddDomainModule))]
    public class MoUsersDomainModule : AbpModule
    {

    }
}
