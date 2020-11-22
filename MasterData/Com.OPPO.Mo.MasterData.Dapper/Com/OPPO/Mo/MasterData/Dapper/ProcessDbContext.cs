using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.MasterData.Dapper
{
    public class ProcessDbContext : AbpDbContext<ProcessDbContext>, IProcessDbContext
    {
        public ProcessDbContext(DbContextOptions<ProcessDbContext> options) : base(options)
        {
        }
    }
}