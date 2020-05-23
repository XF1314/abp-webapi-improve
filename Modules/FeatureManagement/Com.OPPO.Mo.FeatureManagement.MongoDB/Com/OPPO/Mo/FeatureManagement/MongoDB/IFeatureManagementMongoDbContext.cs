using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.FeatureManagement.MongoDB
{
    [ConnectionStringName(FeatureManagementDbProperties.ConnectionStringName)]
    public interface IFeatureManagementMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<FeatureValue> FeatureValues { get; }
    }
}
