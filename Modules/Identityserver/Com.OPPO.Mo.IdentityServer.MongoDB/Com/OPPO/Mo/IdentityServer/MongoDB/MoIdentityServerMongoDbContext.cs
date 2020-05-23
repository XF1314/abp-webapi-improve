using MongoDB.Driver;
using Volo.Abp.Data;
using Com.OPPO.Mo.IdentityServer.ApiResources;
using Com.OPPO.Mo.IdentityServer.Clients;
using Com.OPPO.Mo.IdentityServer.Devices;
using Com.OPPO.Mo.IdentityServer.Grants;
using Volo.Abp.MongoDB;
using IdentityResource = Com.OPPO.Mo.IdentityServer.IdentityResources.IdentityResource;

namespace Com.OPPO.Mo.IdentityServer.MongoDB
{
    [ConnectionStringName(MoIdentityServerDbProperties.ConnectionStringName)]
    public class MoIdentityServerMongoDbContext : AbpMongoDbContext, IMoIdentityServerMongoDbContext
    {
        public IMongoCollection<ApiResource> ApiResources => Collection<ApiResource>();

        public IMongoCollection<Client> Clients => Collection<Client>();

        public IMongoCollection<IdentityResource> IdentityResources => Collection<IdentityResource>();

        public IMongoCollection<PersistedGrant> PersistedGrants => Collection<PersistedGrant>();

        public IMongoCollection<DeviceFlowCodes> DeviceFlowCodes => Collection<DeviceFlowCodes>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureIdentityServer();
        }
    }
}
