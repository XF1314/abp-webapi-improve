﻿using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Com.OPPO.Mo.PermissionManagement.EntityFrameworkCore
{
    public static class MoPermissionManagementDbContextModelBuilderExtensions
    {
        public static void ConfigurePermissionManagement(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] Action<MoPermissionManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MoPermissionManagementModelBuilderConfigurationOptions(
                MoPermissionManagementDbProperties.DbTablePrefix,
                MoPermissionManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<PermissionGrant>(b =>
            {
                b.ToTable(options.TablePrefix + "PermissionGrants", options.Schema);

                b.ConfigureByConvention();

                b.Property(x => x.Name).HasMaxLength(PermissionGrantConsts.MaxNameLength).IsRequired();
                b.Property(x => x.ProviderName).HasMaxLength(PermissionGrantConsts.MaxProviderNameLength).IsRequired();
                b.Property(x => x.ProviderKey).HasMaxLength(PermissionGrantConsts.MaxProviderKeyLength).IsRequired();

                b.HasIndex(x => new {x.Name, x.ProviderName, x.ProviderKey});
            });
        }
    }
}