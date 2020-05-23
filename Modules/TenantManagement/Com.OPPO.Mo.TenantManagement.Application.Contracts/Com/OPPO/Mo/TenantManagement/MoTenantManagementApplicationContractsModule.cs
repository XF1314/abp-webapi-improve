using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.TenantManagement
{
    [DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(MoTenantManagementDomainSharedModule))]
    public class MoTenantManagementApplicationContractsModule : AbpModule
    {

    }
}