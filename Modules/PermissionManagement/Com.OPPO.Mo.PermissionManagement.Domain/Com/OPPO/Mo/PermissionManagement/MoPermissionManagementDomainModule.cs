using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.PermissionManagement
{
    [DependsOn(typeof(AbpAuthorizationModule))]
    [DependsOn(typeof(AbpDddDomainModule))]
    //[DependsOn(typeof(MoIdentityDomainSharedModule))]
    [DependsOn(typeof(MoPermissionManagementDomainSharedModule))]
    [DependsOn(typeof(AbpCachingModule))]
    [DependsOn(typeof(AbpJsonModule))]
    public class MoPermissionManagementDomainModule : AbpModule
    {
        
    }
}
