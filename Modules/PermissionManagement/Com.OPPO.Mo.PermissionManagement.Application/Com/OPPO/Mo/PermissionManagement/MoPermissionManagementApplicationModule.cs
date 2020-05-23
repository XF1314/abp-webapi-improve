using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.PermissionManagement
{
    [DependsOn(
    typeof(MoPermissionManagementDomainModule),
    typeof(MoPermissionManagementApplicationContractsModule))]
    public class MoPermissionManagementApplicationModule : AbpModule
    {

    }
}
