using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Inmail
{
    [DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(MoInmailApplicationContractsModule))]
    public class MoInmailHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MoInmailHttpApiModule).Assembly);
            });
        }
    }
}
