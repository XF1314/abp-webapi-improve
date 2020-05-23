using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Blogging.MongoDB
{
    public class BloggingMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public BloggingMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
