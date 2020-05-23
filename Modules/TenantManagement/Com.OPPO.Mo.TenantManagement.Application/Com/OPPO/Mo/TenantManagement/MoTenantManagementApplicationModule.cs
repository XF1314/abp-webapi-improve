using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.TenantManagement
{
    [DependsOn(typeof(MoTenantManagementDomainModule))]
    [DependsOn(typeof(MoTenantManagementApplicationContractsModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class MoTenantManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoTenantManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoTenantManagementApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}