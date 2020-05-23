using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Inmail
{
    [DependsOn(typeof(AbpCachingModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(MoInmailDomainSharedModule))]
    [DependsOn(typeof(MoInmailApplicationContractsModule))]
    public class MoInmailApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoInmailApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoInmailApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
