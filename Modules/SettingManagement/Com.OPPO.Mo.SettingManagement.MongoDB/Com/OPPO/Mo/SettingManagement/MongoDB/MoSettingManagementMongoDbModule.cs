using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.SettingManagement.MongoDB
{
    [DependsOn(
    typeof(MoSettingManagementDomainModule),
    typeof(AbpMongoDbModule))]
    public class MoSettingManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<SettingManagementMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<ISettingManagementMongoDbContext>();

                options.AddRepository<Setting, MongoSettingRepository>();
            });
        }
    }
}
