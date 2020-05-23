using Microsoft.Extensions.DependencyInjection;
using Com.OPPO.Mo.IdentityServer.Devices;
using Com.OPPO.Mo.IdentityServer.Grants;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using ApiResource = Com.OPPO.Mo.IdentityServer.ApiResources.ApiResource;
using Client = Com.OPPO.Mo.IdentityServer.Clients.Client;
using IdentityResource = Com.OPPO.Mo.IdentityServer.IdentityResources.IdentityResource;

namespace Com.OPPO.Mo.IdentityServer.MongoDB
{
    [DependsOn(
    typeof(MoIdentityServerDomainModule),
    typeof(AbpMongoDbModule))]
    public class MoIdentityServerMongoDbModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<IIdentityServerBuilder>(
                builder =>
                {
                    builder.AddAbpStores();
                }
            );
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<MoIdentityServerMongoDbContext>(options =>
            {
                options.AddRepository<ApiResource, MongoApiResourceRepository>();
                options.AddRepository<IdentityResource, MongoIdentityResourceRepository>();
                options.AddRepository<Client, MongoClientRepository>();
                options.AddRepository<PersistedGrant, MongoPersistentGrantRepository>();
                options.AddRepository<DeviceFlowCodes, MongoDeviceFlowCodesRepository>();
            });
        }
    }
}
