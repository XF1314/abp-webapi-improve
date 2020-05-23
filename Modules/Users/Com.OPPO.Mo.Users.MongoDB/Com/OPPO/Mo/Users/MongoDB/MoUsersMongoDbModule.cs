using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Users.MongoDB
{
    [DependsOn(
    typeof(MoUsersDomainModule),
    typeof(AbpMongoDbModule))]
    public class MoUsersMongoDbModule : AbpModule
    {

    }
}
