using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.AuditLogging.EntityFrameworkCore
{
    [ConnectionStringName(MoAuditLoggingDbProperties.ConnectionStringName)]
    public class MoAuditLoggingDbContext : AbpDbContext<MoAuditLoggingDbContext>, IAuditLoggingDbContext
    {
        public DbSet<AuditLog> AuditLogs { get; set; }

        public MoAuditLoggingDbContext(DbContextOptions<MoAuditLoggingDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAuditLogging();
        }
    }
}
