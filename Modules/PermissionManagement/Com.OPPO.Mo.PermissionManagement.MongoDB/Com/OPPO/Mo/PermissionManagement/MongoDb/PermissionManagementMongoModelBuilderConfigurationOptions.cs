using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.PermissionManagement.MongoDB
{
    public class PermissionManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public PermissionManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "")
            : base(tablePrefix)
        {
        }
    }
}