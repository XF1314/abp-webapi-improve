using Com.OPPO.Mo.PermissionManagement;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Identity
{
    [DependsOn(
    typeof(MoIdentityDomainModule),
    typeof(MoIdentityApplicationContractsModule),
    typeof(AbpAutoMapperModule),
    typeof(MoPermissionManagementApplicationModule))]
    public class MoIdentityApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoIdentityApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoIdentityApplicationModuleAutoMapperProfile>(validate: true);
            });
        }
    }
}