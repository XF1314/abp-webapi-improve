using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.MasterData.Dapper
{
    [ConnectionStringName(MoMasterDataDbProperties.MasterConnectionStringName)]
    public class MoDbContext : AbpDbContext<MoDbContext>, IMoDbContext
    {
        public MoDbContext(DbContextOptions<MoDbContext> options) : base(options)
        {

        }
    }
}
