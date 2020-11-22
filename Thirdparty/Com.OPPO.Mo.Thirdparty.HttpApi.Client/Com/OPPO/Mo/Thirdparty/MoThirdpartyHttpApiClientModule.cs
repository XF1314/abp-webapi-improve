using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Thirdparty
{
    [DependsOn(
    typeof(AbpHttpClientModule),
    typeof(MoThirdpartyApplicationContractsModule))]
    public class MoThirdpartyHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(MoThirdpartyHttpApiClientModule).Assembly,
               ThirdpartyRemoteServiceConsts.RemoteServiceName);
        }
    }
}
