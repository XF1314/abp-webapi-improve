using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.TenantManagement.MongoDB
{
    [DependsOn(
    typeof(MoTenantManagementDomainModule),
    typeof(AbpMongoDbModule))]
    public class MoTenantManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<TenantManagementMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<ITenantManagementMongoDbContext>();

                options.AddRepository<Tenant, MongoTenantRepository>();
            });
        }
    }
}
