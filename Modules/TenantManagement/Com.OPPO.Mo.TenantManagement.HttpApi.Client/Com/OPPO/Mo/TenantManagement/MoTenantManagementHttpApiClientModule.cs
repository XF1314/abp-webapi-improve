using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.TenantManagement
{
    [DependsOn(
    typeof(MoTenantManagementApplicationContractsModule), 
    typeof(AbpHttpClientModule))]
    public class MoTenantManagementHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MoTenantManagementApplicationContractsModule).Assembly,
                TenantManagementRemoteServiceConsts.RemoteServiceName
            );
        }
    }
}