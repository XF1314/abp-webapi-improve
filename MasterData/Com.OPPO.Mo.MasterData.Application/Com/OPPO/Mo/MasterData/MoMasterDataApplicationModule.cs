using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.MasterData
{
    [DependsOn(typeof(AbpCachingModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(MoMasterDataDomainSharedModule))]
    [DependsOn(typeof(MoMasterDataApplicationContractsModule))]
    public class MoMasterDataApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoMasterDataApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoMasterDataApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
