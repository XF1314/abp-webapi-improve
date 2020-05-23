using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.Inmail.Dapper
{
    [ConnectionStringName(MoInmailDbProperties.ReadonlyConnectionStringName)]
    public class InmailReadonlyDbContext : AbpDbContext<InmailReadonlyDbContext>, IInmailDbContext
    {
        public InmailReadonlyDbContext(DbContextOptions<InmailReadonlyDbContext> options) : base(options)
        {

        }
    }
}
