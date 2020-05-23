using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Blogging
{
    [DependsOn(
    typeof(MoBloggingApplicationContractsModule),
    typeof(AbpHttpClientModule))]
    public class MoBloggingHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(MoBloggingApplicationContractsModule).Assembly, 
                BloggingRemoteServiceConsts.RemoteServiceName);
        }

    }
}
