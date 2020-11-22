using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.MasterData
{
    [DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(MoMasterDataApplicationContractsModule))]
    public class MoMasterDataHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MoMasterDataHttpApiModule).Assembly);
            });
        }
    }
}
