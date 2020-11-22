using Com.OPPO.Mo.Account.Web;
using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Com.OPPO.Mo.FeatureManagement.MongoDB;
using Com.OPPO.Mo.Identity.MongoDB;
using Com.OPPO.Mo.IdentityServer.MongoDB;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.Settings.Apollo;
using Exceptionless;
using Exceptionless.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;

namespace Com.OPPO.Mo.AuthServer
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(MoExceptionlessModule),
    typeof(MoFeatureManagementMongoDbModule),
    typeof(MoAuditLoggingMongoDbModule),
    typeof(MoSettingManagementMongoDbModule),
    typeof(MoIdentityMongoDbModule),
    typeof(MoIdentityServerMongoDbModule),
    typeof(MoAccountWebModule),
    typeof(MoAccountWebIdentityServerModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(MoPermissionManagementMongoDbModule),
    typeof(MoSettinsApolloModule),
    typeof(MoCoreModule))]
    public class MoAuthServerHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            ExceptionlessClient.Default.Configuration.Enabled = bool.Parse(configuration["oppo-mo-auth-server-log-exceptionless-enabled"]);
            ExceptionlessClient.Default.Configuration.ServerUrl = configuration["oppo-mo-auth-server-log-exceptionless-server-host"];
            ExceptionlessClient.Default.Configuration.ApiKey = configuration["oppo-mo-auth-server-log-exceptionless-api-key"];
            ExceptionlessClient.Default.Configuration.SetDefaultMinLogLevel(minLogLevel: LogLevel.Warn);
            if (!string.IsNullOrWhiteSpace(configuration["oppo-mo-auth-server-log-exceptionless-folder-storage"]))
                ExceptionlessClient.Default.Configuration.UseFolderStorage(configuration["oppo-mo-auth-server-log-exceptionless-folder-storage"]);
            
            AbpCommonDbProperties.DbTablePrefix = MoBpmConsts.ProjectCode;
            context.Services.AddMongoDbContext<AuthServerMongoDbContext>(options => options.AddDefaultRepositories());
            Configure<AbpDbConnectionOptions>(x => x.ConnectionStrings.TryAdd("Default", configuration["oppo-mo-auth-server-data-storeage-mongo-connection-string"]));
            Configure<AbpMultiTenancyOptions>(options => options.IsEnabled = MoBpmConsts.IsMultiTenancyEnabled);
            Configure<AbpLocalizationOptions>(options => options.Languages.Add(new LanguageInfo("en", "en", "English")));
            context.Services.AddStackExchangeRedisCache(options => options.Configuration = configuration["oppo-mo-auth-server-data-cache-redis-connection-string"]);
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = configuration["oppo-mo-auth-server-app-name"];
            });

            var redis = ConnectionMultiplexer.Connect(configuration["oppo-mo-auth-server-data-protection-redis-connection-string"]);
            context.Services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "oppo-mo-data-protection-auth-server");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            IdentityModelEventSource.ShowPII = true;
            var app = context.GetApplicationBuilder();
            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            if (MoBpmConsts.IsMultiTenancyEnabled)
                app.UseMultiTenancy();

            app.UseExceptionless();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAbpRequestLocalization();
            app.UseAuditing();
            app.UseMvcWithDefaultRouteAndArea();
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:60549", "http://127.0.0.1"); // ÔÊÐíÌØ¶¨ip¿çÓò
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowCredentials();
            });
            //TODO: Problem on a clustered environment
            AsyncHelper.RunSync(async () =>
            {
                using (var scope = context.ServiceProvider.CreateScope())
                {
                    await scope.ServiceProvider
                        .GetRequiredService<IDataSeeder>()
                        .SeedAsync();
                }
            });
        }
    }
}
