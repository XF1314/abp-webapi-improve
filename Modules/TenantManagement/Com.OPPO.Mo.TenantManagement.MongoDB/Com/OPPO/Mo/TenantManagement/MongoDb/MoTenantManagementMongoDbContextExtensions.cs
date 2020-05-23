using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.TenantManagement.MongoDB
{
    public static class MoTenantManagementMongoDbContextExtensions
    {
        public static void ConfigureTenantManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new TenantManagementMongoModelBuilderConfigurationOptions(
                MoTenantManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<Tenant>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Tenants";
            });
        }
    }
}