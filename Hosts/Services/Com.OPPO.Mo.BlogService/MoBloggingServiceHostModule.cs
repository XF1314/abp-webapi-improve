using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.Blogging;
using Com.OPPO.Mo.Blogging.EntityFrameworkCore;
using Com.OPPO.Mo.Blogging.Files;
using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Volo.Abp.Threading;
using Volo.Abp.EntityFrameworkCore.SqlServer;

namespace Com.OPPO.Mo.BloggingService
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpHttpClientIdentityModelWebModule),   
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(MoAuditLoggingMongoDbModule),
    typeof(MoPermissionManagementMongoDbModule),
    typeof(MoSettingManagementMongoDbModule),
    typeof(MoIdentityHttpApiClientModule),
    typeof(MoBloggingHttpApiModule),
    typeof(MoBloggingEntityFrameworkCoreModule),
    typeof(MoBloggingApplicationModule))]
    public class MoBloggingServiceHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AbpCommonDbProperties.DbTablePrefix = MoConsts.ProjectCode;
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = BloggingServiceConsts.IsMultiTenancyEnabled;
            });
            Configure<AbpMongoModelBuilderConfigurationOptions>(options =>
            {
                options.CollectionPrefix = MoConsts.ProjectCode;
            });

            context.Services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.ApiName = configuration["AuthServer:ApiName"];
                    options.RequireHttpsMetadata = false;
                });

            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Mo Blogging Service API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<BlogFileOptions>(options =>
            {
                options.FileUploadLocalFolder = Path.Combine(hostingEnvironment.WebRootPath, "files");
            });

            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });

            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = "MoBloggingService";
            });

            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "Mo-DataProtection-Keys-BloggingService");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            IdentityModelEventSource.ShowPII = true;
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();

            app.Use(async (ctx, next) =>
            {
                var currentPrincipalAccessor = ctx.RequestServices.GetRequiredService<ICurrentPrincipalAccessor>();
                var map = new Dictionary<string, string>()
                {
                    { "sub", AbpClaimTypes.UserId },
                    { "role", AbpClaimTypes.Role },
                    { "email", AbpClaimTypes.Email },
                    //any other map
                };
                var mapClaims = currentPrincipalAccessor.Principal.Claims.Where(p => map.Keys.Contains(p.Type)).ToList();
                currentPrincipalAccessor.Principal.AddIdentity(new ClaimsIdentity(mapClaims.Select(p => new Claim(map[p.Type], p.Value, p.ValueType, p.Issuer))));
                await next();
            });
            if (BloggingServiceConsts.IsMultiTenancyEnabled)
            {
                app.UseMultiTenancy();
            }
            app.UseAbpRequestLocalization(); //TODO: localization?
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mo Blogging Service API");
            });
            app.UseAuditing();
            app.UseMvcWithDefaultRouteAndArea();

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
