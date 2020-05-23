using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.SettingManagement.MongoDB
{
    [ConnectionStringName(MoSettingManagementDbProperties.ConnectionStringName)]
    public interface ISettingManagementMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Setting> Settings { get; }
    }
}