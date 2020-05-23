using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Com.OPPO.Mo.PermissionManagement.HttpApi;
using Com.OPPO.Mo.PermissionManagement.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Com.OPPO.Mo.PermissionManagement.Web
{
    [DependsOn(typeof(MoPermissionManagementHttpApiModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiBootstrapModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class MoPermissionManagementWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(MoPermissionManagementResource));
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MoPermissionManagementWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoPermissionManagementWebModule>("Com.OPPO.Mo.PermissionManagement.Web");
            });

            context.Services.AddAutoMapperObjectMapper<MoPermissionManagementWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoPermissionManagementWebAutoMapperProfile>(validate: true);
            });
        }
    }
}
