using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.AuditLogging.MongoDB
{
    [ConnectionStringName(MoAuditLoggingDbProperties.ConnectionStringName)]
    public class AuditLoggingMongoDbContext : AbpMongoDbContext, IAuditLoggingMongoDbContext
    {
        public IMongoCollection<AuditLog> AuditLogs => Collection<AuditLog>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAuditLogging();
        }
    }
}
