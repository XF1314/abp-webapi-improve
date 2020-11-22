using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Bpm
{
    [DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpEventBusModule),
    typeof(MoBpmDomainSharedModule))]
    public class MoBpmDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoBpmDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BpmDomainMappingProfile>(validate: true);
            });
        }
    }
}
