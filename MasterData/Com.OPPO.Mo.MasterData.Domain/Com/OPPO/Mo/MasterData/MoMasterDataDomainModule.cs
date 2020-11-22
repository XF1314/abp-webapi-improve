using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.MasterData
{
    [DependsOn(
    typeof(MoMasterDataDomainSharedModule),
    typeof(AbpDddDomainModule),
    typeof(AbpAutoMapperModule))]
    public class MoMasterDataDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoMasterDataDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<InmailDomainMappingProfile>(validate: true);
            });
        }
    }
}
