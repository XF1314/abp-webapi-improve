using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Inmail
{
    [DependsOn(typeof(AbpAuthorizationModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(MoInmailDomainSharedModule))]
    public class MoInmailApplicationContractsModule : AbpModule
    {

    }
}
