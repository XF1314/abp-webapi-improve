using Com.OPPO.Mo.PermissionManagement;
using Com.OPPO.Mo.Users;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Identity
{
    [DependsOn(
    typeof(MoIdentityDomainSharedModule),
    typeof(MoUsersAbstractionModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationModule),
    typeof(MoPermissionManagementApplicationContractsModule))]
    public class MoIdentityApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}