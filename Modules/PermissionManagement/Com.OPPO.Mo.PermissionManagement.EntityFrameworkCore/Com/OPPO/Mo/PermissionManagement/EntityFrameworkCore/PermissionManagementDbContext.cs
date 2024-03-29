﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.PermissionManagement.EntityFrameworkCore
{
    [ConnectionStringName(MoPermissionManagementDbProperties.ConnectionStringName)]
    public class PermissionManagementDbContext : AbpDbContext<PermissionManagementDbContext>, IPermissionManagementDbContext
    {
        public DbSet<PermissionGrant> PermissionGrants { get; set; }

        public PermissionManagementDbContext(DbContextOptions<PermissionManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigurePermissionManagement();
        }
    }
}
