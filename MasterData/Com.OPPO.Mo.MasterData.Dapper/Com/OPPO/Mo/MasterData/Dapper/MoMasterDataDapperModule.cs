using Com.OPPO.Mo.Dapper;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.MasterData.Dapper
{
    [DependsOn(typeof(MoDapperModule))]
    [DependsOn(typeof(MoMasterDataDomainModule))]
    public class MoMasterDataDapperModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MoDbContext>();
            context.Services.AddAbpDbContext<MoReadonlyDbContext>();
            context.Services.AddAbpDbContext<ProcessDbContext>();
        }
    }
}