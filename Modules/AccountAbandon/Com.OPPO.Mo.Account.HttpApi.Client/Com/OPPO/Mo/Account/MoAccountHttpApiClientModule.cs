using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Account
{
    [DependsOn(
        typeof(MoAccountApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class MoAccountHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(MoAccountApplicationContractsModule).Assembly, 
                AccountRemoteServiceConsts.RemoteServiceName);
        }
    }
}