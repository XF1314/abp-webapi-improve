using Com.OPPO.Mo.IdentityServer;
using Com.OPPO.Mo.PermissionManagement;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.PermissionManagement.IdentityServer
{
    [DependsOn(
    typeof(MoIdentityServerDomainSharedModule),
    typeof(MoPermissionManagementDomainModule))]
    public class MoPermissionManagementDomainIdentityServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionManagementOptions>(options =>
            {
                options.ManagementProviders.Add<ClientPermissionManagementProvider>();

                options.ProviderPolicies[ClientPermissionValueProvider.ProviderName] = "IdentityServer.Client.ManagePermissions";
            });
        }
    }
}
