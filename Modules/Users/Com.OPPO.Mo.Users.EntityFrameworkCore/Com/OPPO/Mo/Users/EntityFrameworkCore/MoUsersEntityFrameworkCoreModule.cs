using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Users.EntityFrameworkCore
{
    [DependsOn(
    typeof(MoUsersDomainModule),
    typeof(AbpEntityFrameworkCoreModule))]
    public class MoUsersEntityFrameworkCoreModule : AbpModule
    {

    }
}
