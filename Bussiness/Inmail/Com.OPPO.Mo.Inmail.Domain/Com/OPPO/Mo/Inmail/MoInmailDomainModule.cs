using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Inmail
{
    [DependsOn(
    typeof(MoInmailDomainSharedModule),
    typeof(AbpDddDomainModule),
    typeof(AbpAutoMapperModule))]
    public class MoInmailDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoInmailDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<InmailDomainMappingProfile>(validate: true);
            });
        }
    }
}
