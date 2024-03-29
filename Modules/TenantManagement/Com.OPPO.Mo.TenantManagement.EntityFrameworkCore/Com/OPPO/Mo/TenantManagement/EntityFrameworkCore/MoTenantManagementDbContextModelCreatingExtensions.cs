using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Com.OPPO.Mo.TenantManagement.EntityFrameworkCore
{
    public static class MoTenantManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureTenantManagement(
            this ModelBuilder builder,
            [CanBeNull] Action<MoTenantManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MoTenantManagementModelBuilderConfigurationOptions(
                MoTenantManagementDbProperties.DbTablePrefix,
                MoTenantManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<Tenant>(b =>
            {
                b.ToTable(options.TablePrefix + "Tenants", options.Schema);

                b.ConfigureByConvention();

                b.Property(t => t.Name).IsRequired().HasMaxLength(TenantConsts.MaxNameLength);

                b.HasMany(u => u.ConnectionStrings).WithOne().HasForeignKey(uc => uc.TenantId).IsRequired();

                b.HasIndex(u => u.Name);
            });

            builder.Entity<TenantConnectionString>(b =>
            {
                b.ToTable(options.TablePrefix + "TenantConnectionStrings", options.Schema);

                b.ConfigureByConvention();

                b.HasKey(x => new { x.TenantId, x.Name });

                b.Property(cs => cs.Name).IsRequired().HasMaxLength(TenantConnectionStringConsts.MaxNameLength);
                b.Property(cs => cs.Value).IsRequired().HasMaxLength(TenantConnectionStringConsts.MaxValueLength);
            });
        }
    }
}