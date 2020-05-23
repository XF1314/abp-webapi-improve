using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.PermissionManagement.MongoDB
{
    [ConnectionStringName(MoPermissionManagementDbProperties.ConnectionStringName)]
    public interface IPermissionManagementMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<PermissionGrant> PermissionGrants { get; }
    }
}