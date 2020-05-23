using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.PermissionManagement.EntityFrameworkCore
{
    [ConnectionStringName(MoPermissionManagementDbProperties.ConnectionStringName)]
    public interface IPermissionManagementDbContext : IEfCoreDbContext
    {
        DbSet<PermissionGrant> PermissionGrants { get; set; }
    }
}