using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.PermissionManagement.MongoDB
{
    [DependsOn(
    typeof(MoPermissionManagementDomainModule),
    typeof(AbpMongoDbModule))]
    public class MoPermissionManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<PermissionManagementMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<IPermissionManagementMongoDbContext>();

                options.AddRepository<PermissionGrant, MongoPermissionGrantRepository>();
            });
        }
    }
}
