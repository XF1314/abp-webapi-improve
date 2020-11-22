using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.MasterData.Dapper
{
    [ConnectionStringName(MoMasterDataDbProperties.ProcessConnectionStringName)]
    public interface IProcessDbContext : IEfCoreDbContext
    {
        
    }
}