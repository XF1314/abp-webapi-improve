﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.Domain;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI;

namespace Com.OPPO.Mo.TenantManagement
{
    [DependsOn(typeof(AbpMultiTenancyModule))]
    [DependsOn(typeof(MoTenantManagementDomainSharedModule))]
    [DependsOn(typeof(AbpDataModule))]
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpUiModule))] //TODO: It's not good to depend on the UI module. However, UserFriendlyException is inside it!
    public class MoTenantManagementDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoTenantManagementDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoTenantManagementDomainMappingProfile>(validate: true);
            });

            Configure<AbpDistributedEventBusOptions>(options =>
            {
                options.EtoMappings.Add<Tenant, TenantEto>();
            });
        }
    }
}
