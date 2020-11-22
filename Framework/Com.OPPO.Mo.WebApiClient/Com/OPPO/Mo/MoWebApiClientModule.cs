using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo
{
    [DependsOn(typeof(MoCoreModule))]
    public class MoWebApiClientModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
           // context.Services.AddConventionalRegistrar(new MoWebApiClientConventionalRegistrar());
        }
    }
}
