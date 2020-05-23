using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.AuditLogging.MongoDB
{
    [ConnectionStringName(MoAuditLoggingDbProperties.ConnectionStringName)]
    public interface IAuditLoggingMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<AuditLog> AuditLogs { get; }
    }
}
