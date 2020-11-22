using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.MasterData.Dapper
{
    [ConnectionStringName(MoMasterDataDbProperties.SlaveConnectionStringName)]
    public class MoReadonlyDbContext : AbpDbContext<MoReadonlyDbContext>, IMoDbContext
    {
        public MoReadonlyDbContext(DbContextOptions<MoReadonlyDbContext> options) : base(options)
        {

        }
    }
}
