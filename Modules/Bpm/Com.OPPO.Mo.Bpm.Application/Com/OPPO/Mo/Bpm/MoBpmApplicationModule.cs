using Com.OPPO.Mo.Thirdparty;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Bpm
{
    [DependsOn(
    typeof(AbpCachingModule),
    typeof(AbpAutoMapperModule),
    typeof(MoBpmDomainModule),
    typeof(MoThirdpartyApplicationContractsModule),
    typeof(MoBpmApplicationContractsModule))]
    public class MoBpmApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoBpmApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoBpmApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
