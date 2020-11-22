using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.MasterData
{
    [DependsOn(typeof(AbpHttpClientModule))]
    [DependsOn(typeof(MoMasterDataApplicationContractsModule))]
    public class MoMasterDataHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MoMasterDataApplicationContractsModule).Assembly,
                MasterDataRemoteServiceConsts.RemoteServiceName
            );
        }
    }
}
