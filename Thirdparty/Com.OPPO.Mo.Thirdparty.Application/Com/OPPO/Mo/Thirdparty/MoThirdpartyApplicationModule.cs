using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Thirdparty
{
    [DependsOn(
    typeof(AbpCachingModule),
    typeof(AbpAutoMapperModule),
    typeof(MoThirdpartyApplicationContractsModule))]
    public class MoThirdpartyApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoThirdpartyApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoThirdpartyApplicationAutoMapperProfile>(validate: true);
            });
        }

    }
}
