using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Com.OPPO.Mo.PermissionManagement.EntityFrameworkCore
{
    public class MoPermissionManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MoPermissionManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}