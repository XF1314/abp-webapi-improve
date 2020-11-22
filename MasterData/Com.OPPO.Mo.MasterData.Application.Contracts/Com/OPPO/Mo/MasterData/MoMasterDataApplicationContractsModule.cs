using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.MasterData
{
    [DependsOn(typeof(AbpAuthorizationModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(MoMasterDataDomainSharedModule))]
    public class MoMasterDataApplicationContractsModule : AbpModule
    {

    }
}
