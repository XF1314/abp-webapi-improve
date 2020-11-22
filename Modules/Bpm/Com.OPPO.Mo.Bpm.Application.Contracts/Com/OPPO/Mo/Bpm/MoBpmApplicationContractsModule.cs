using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects;
using Com.OPPO.Mo.Bpm.ActionSoft.Extensions;
using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas;
using Com.OPPO.Mo.Bpm.ActionSoft.Notifications;
using Com.OPPO.Mo.Bpm.ActionSoft.Organiztion;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Com.OPPO.Mo.Bpm
{
    [DependsOn(typeof(MoCoreModule))]
    [DependsOn(typeof(MoWebApiClientModule))]
    [DependsOn(typeof(MoBpmDomainSharedModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    public class MoBpmApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options => options.FileSets.AddEmbedded<MoBpmApplicationContractsModule>());
            var configuration = context.Services.GetRequiredServiceLazy<IConfiguration>();
            var loggerFactory = context.Services.GetRequiredServiceLazy<ILoggerFactory>();
            var actionSoftWebApiParameterSignFilter = new ActionSoftWebApiParameterSignFilter(loggerFactory, configuration);
            var moWebApiClientLogFilter = new MoWebApiClientLogFilter(loggerFactory);
            context.Services.AddHttpApi<IActionSoftExtensionWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(actionSoftWebApiParameterSignFilter);
            });
            context.Services.AddHttpApi<IActionSoftOrganizationWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(actionSoftWebApiParameterSignFilter);
            });
            context.Services.AddHttpApi<IActionSoftNotificationWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(actionSoftWebApiParameterSignFilter);
            });
            context.Services.AddHttpApi<IActionSoftBusinessObjectWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(actionSoftWebApiParameterSignFilter);
            });
            context.Services.AddHttpApi<IActionSoftProcessWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(actionSoftWebApiParameterSignFilter);
            });
            context.Services.AddHttpApi<IActionSoftTaskWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(actionSoftWebApiParameterSignFilter);
            });
            context.Services.AddHttpApi<IBpmCallbackWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
            context.Services.AddHttpApi<IActionSoftMetadataWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(actionSoftWebApiParameterSignFilter);
            });
        }
    }
}
