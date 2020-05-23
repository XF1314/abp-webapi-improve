using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.PermissionManagement
{
    [DependsOn(
    typeof(MoPermissionManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
    public class MoPermissionManagementHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MoPermissionManagementApplicationContractsModule).Assembly,
                PermissionManagementRemoteServiceConsts.RemoteServiceName
            );
        }
    }
}
