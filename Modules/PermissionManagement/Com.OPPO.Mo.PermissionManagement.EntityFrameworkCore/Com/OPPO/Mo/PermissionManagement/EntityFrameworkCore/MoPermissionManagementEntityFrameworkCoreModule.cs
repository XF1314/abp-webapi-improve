using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.PermissionManagement.EntityFrameworkCore
{
    [DependsOn(typeof(MoPermissionManagementDomainModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class MoPermissionManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PermissionManagementDbContext>(options =>
            {
                options.AddDefaultRepositories<IPermissionManagementDbContext>();

                options.AddRepository<PermissionGrant, EfCorePermissionGrantRepository>();
            });
        }
    }
}
