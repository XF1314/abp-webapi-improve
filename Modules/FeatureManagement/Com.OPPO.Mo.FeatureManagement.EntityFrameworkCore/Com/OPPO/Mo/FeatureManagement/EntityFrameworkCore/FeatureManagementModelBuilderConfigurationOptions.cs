using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Com.OPPO.Mo.FeatureManagement.EntityFrameworkCore
{
    public class FeatureManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public FeatureManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}