using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Inmail
{
    [DependsOn(typeof(AbpHttpClientModule))]
    [DependsOn(typeof(MoInmailApplicationContractsModule))]
    public class MoInmailHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MoInmailApplicationContractsModule).Assembly,
                InmailRemoteServiceConsts.RemoteServiceName
            );
        }
    }
}
