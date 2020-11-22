using Com.OPPO.Mo.Bpm;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Bpm
{
    [DependsOn(
    typeof(AbpHttpClientModule),
    typeof(MoBpmApplicationContractsModule))]
    public class MoBpmHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(MoBpmHttpApiClientModule).Assembly,
               BpmRemoteServiceConsts.RemoteServiceName);
        }
    }
}
