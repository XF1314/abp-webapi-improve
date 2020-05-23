using Com.OPPO.Mo.Dapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Inmail.Dapper
{
    [DependsOn(typeof(MoDapperModule))]
    [DependsOn(typeof(MoInmailDomainModule))]
    public class MoInmailDapperModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<InmailDbContext>();
            context.Services.AddAbpDbContext<InmailReadonlyDbContext>();
        }
    }
}
