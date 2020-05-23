using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.FeatureManagement.EntityFrameworkCore
{
    [ConnectionStringName(FeatureManagementDbProperties.ConnectionStringName)]
    public interface IFeatureManagementDbContext : IEfCoreDbContext
    {
        DbSet<FeatureValue> FeatureValues { get; set; }
    }
}