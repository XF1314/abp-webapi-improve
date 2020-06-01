using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Auditing;
using Volo.Abp.EventBus.RabbitMq;
using Com.OPPO.Mo.IdentityServer.MongoDB;
using  Com.OPPO.Mo.SettingManagement.MongoDB;
using  Com.OPPO.Mo.TenantManagement;
using  Com.OPPO.Mo.TenantManagement.MongoDB;
using Microsoft.IdentityModel.Logging;
using Volo.Abp.MongoDB;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.Identity.MongoDB;
using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.FeatureManagement.MongoDB;
using Com.OPPO.Mo.Account.Web;
using Microsoft.OpenApi.Models;

namespace Com.OPPO.Mo.AuthServer
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(MoFeatureManagementMongoDbModule),
    typeof(MoAuditLoggingMongoDbModule),
    typeof(MoSettingManagementMongoDbModule),
    typeof(MoIdentityMongoDbModule),
    //typeof(MoIdentityApplicationModule),
    //typeof(MoIdentityWebModule),
    typeof(MoIdentityServerMongoDbModule),
    typeof(MoAccountWebModule),
    typeof(MoAccountWebIdentityServerModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(MoTenantManagementMongoDbModule),
    typeof(MoTenantManagementApplicationContractsModule),
    //typeof(MoInmailApplicationContractsModule),
    //typeof(MoPermissionManagementDomainIdentityModule),
    //typeof(MoPermissionManagementDomainIdentityServerModule),
    typeof(MoPermissionManagementMongoDbModule),
    //typeof(MoPermissionManagementApplicationModule),
    //typeof(MoPermissionManagementWebModule),
    typeof(MoCoreModule))]
    public class MoAuthServerHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            AbpCommonDbProperties.DbTablePrefix = MoConsts.ProjectCode;
            context.Services.AddMongoDbContext<AuthServerDbContext>(options =>
            {
                options.AddDefaultRepositories();
            });
            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Mo Auth Server API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MoConsts.IsMultiTenancyEnabled;
            });
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
            });
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = configuration["AppName"];
            });

            //TODO: ConnectionMultiplexer.Connect call has problem since redis may not be ready when this service has started!
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "Mo-DataProtection-Keys-AuthServer");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            IdentityModelEventSource.ShowPII = true;
            var app = context.GetApplicationBuilder();
            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            if (MoConsts.IsMultiTenancyEnabled)
                app.UseMultiTenancy();

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
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var configuration = context.GetConfiguration();
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mo Backend Admin Application API");
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
