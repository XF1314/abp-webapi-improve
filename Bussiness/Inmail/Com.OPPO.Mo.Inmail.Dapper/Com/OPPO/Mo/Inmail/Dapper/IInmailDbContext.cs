using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.Inmail.Dapper
{
    [ConnectionStringName(MoInmailDbProperties.ConnectionStringName)]
    public interface IInmailDbContext : IEfCoreDbContext
    {

    }
}
