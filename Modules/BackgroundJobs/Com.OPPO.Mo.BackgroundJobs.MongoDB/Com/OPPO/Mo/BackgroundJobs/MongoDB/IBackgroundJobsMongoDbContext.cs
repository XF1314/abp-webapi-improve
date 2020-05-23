using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.BackgroundJobs.MongoDB
{
    [ConnectionStringName(BackgroundJobsDbProperties.ConnectionStringName)]
    public interface IBackgroundJobsMongoDbContext : IAbpMongoDbContext
    {
         IMongoCollection<BackgroundJobRecord> BackgroundJobs { get; }
    }
}
