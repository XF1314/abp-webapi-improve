using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.PermissionManagement
{
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(MoPermissionManagementDomainSharedModule))]
    public class MoPermissionManagementApplicationContractsModule : AbpModule
    {
        
    }
}
