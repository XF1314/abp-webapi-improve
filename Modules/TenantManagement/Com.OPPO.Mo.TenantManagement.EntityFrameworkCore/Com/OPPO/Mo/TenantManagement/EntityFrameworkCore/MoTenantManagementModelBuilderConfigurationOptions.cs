using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Com.OPPO.Mo.TenantManagement.EntityFrameworkCore
{
    public class MoTenantManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MoTenantManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}