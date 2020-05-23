using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.TenantManagement.MongoDB
{
    public class TenantManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public TenantManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "")
            : base(tablePrefix)
        {
        }
    }
}