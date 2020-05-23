using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.AuditLogging.MongoDB
{
    public class AuditLoggingMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public AuditLoggingMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
