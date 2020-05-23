using MongoDB.Driver;
using Volo.Abp.Data;
using Com.OPPO.Mo.IdentityServer.Clients;
using Com.OPPO.Mo.IdentityServer.Devices;
using Com.OPPO.Mo.IdentityServer.Grants;
using Com.OPPO.Mo.IdentityServer.IdentityResources;
using Volo.Abp.MongoDB;
using ApiResource = Com.OPPO.Mo.IdentityServer.ApiResources.ApiResource;

namespace Com.OPPO.Mo.IdentityServer.MongoDB
{
    [ConnectionStringName(MoIdentityServerDbProperties.ConnectionStringName)]
    public interface IMoIdentityServerMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<ApiResource> ApiResources { get; }

        IMongoCollection<Client> Clients { get; }

        IMongoCollection<IdentityResource> IdentityResources { get; }

        IMongoCollection<PersistedGrant> PersistedGrants { get; }

        IMongoCollection<DeviceFlowCodes> DeviceFlowCodes { get; }
    }
}
