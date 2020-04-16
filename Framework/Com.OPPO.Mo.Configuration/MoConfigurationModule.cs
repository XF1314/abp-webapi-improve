using System;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Appllo
{
    //配置中心接入
    [DependsOn(typeof(MoCoreModule))]
    public class MoConfigurationModule : AbpModule
    {


    }
}
