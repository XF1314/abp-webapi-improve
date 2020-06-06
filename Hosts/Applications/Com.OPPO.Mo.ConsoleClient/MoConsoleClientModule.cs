using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.Inmail;
using Com.OPPO.Mo.TenantManagement;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.ConsoleClient
{
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpHttpClientIdentityModelModule))]
    [DependsOn(typeof(MoInmailHttpApiClientModule))]
    [DependsOn(typeof(MoIdentityHttpApiClientModule))]
    [DependsOn(typeof(MoTenantManagementHttpApiClientModule))]
    public class MoConsoleClientModule : AbpModule
    {


    }
}
