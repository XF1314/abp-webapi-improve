using Com.OPPO.Mo.Identity;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.PermissionManagement.Identity
{
    [DependsOn(
    typeof(MoIdentityDomainModule),
    typeof(MoPermissionManagementDomainModule))]
    public class MoPermissionManagementDomainIdentityModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionManagementOptions>(options =>
            {
                options.ManagementProviders.Add<UserPermissionManagementProvider>();
                options.ManagementProviders.Add<RolePermissionManagementProvider>();

                //TODO: Can we prevent duplication of permission names without breaking the design and making the system complicated
                options.ProviderPolicies[UserPermissionValueProvider.ProviderName] = "MoIdentity.Users.ManagePermissions";
                options.ProviderPolicies[RolePermissionValueProvider.ProviderName] = "MoIdentity.Roles.ManagePermissions";
            });
        }
    }
}
