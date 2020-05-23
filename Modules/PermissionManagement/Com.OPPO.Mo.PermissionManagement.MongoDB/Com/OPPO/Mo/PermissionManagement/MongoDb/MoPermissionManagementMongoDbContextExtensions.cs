using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.PermissionManagement.MongoDB
{
    public static class MoPermissionManagementMongoDbContextExtensions
    {
        public static void ConfigurePermissionManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new PermissionManagementMongoModelBuilderConfigurationOptions(
                MoPermissionManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<PermissionGrant>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "PermissionGrants";
            });
        }
    }
}