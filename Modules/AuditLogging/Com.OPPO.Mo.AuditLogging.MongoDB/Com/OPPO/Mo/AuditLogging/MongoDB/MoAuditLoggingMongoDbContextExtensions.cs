using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.AuditLogging.MongoDB
{
    public static class MoAuditLoggingMongoDbContextExtensions
    {
        public static void ConfigureAuditLogging(
            this IMongoModelBuilder builder,
            Action<AuditLoggingMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AuditLoggingMongoModelBuilderConfigurationOptions(
                MoAuditLoggingDbProperties.DbTablePrefix
                );

            optionsAction?.Invoke(options);

            builder.Entity<AuditLog>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "AuditLogs";
            });
        }
    }
}
