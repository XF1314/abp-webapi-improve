using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.FeatureManagement
{
    [DependsOn(
    typeof(MoFeatureManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
    public class MoFeatureManagementHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MoFeatureManagementApplicationContractsModule).Assembly,
                FeatureManagementRemoteServiceConsts.RemoteServiceName
            );
        }
    }
}
