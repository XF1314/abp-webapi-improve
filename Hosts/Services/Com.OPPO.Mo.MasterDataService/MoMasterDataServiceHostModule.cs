using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Com.OPPO.Mo.MasterData;
using Com.OPPO.Mo.MasterData.Dapper;
using Com.OPPO.Mo.MasterDataService.Filters;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.Settings.Apollo;
using Exceptionless;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;

namespace Com.OPPO.Mo.MasterDataService
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(MoSettinsApolloModule),
    typeof(MoExceptionlessModule),
    typeof(MoAuditLoggingMongoDbModule),
    typeof(MoPermissionManagementMongoDbModule),
    typeof(MoSettingManagementMongoDbModule),
    typeof(MoMasterDataDapperModule),
    typeof(MoMasterDataApplicationModule),
    typeof(MoMasterDataHttpApiModule))]
    public class MoMasterDataServiceHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AbpCommonDbProperties.DbTablePrefix = MoBpmConsts.ProjectCode;
            var configuration = context.Services.GetConfiguration();
            ExceptionlessClient.Default.Configuration.Enabled = bool.Parse(configuration["oppo-mo-masterdata-service-log-exceptionless-enabled"]);
            ExceptionlessClient.Default.Configuration.ServerUrl = configuration["oppo-mo-masterdata-service-log-exceptionless-server-host"];
            ExceptionlessClient.Default.Configuration.ApiKey = configuration["oppo-mo-masterdata-service-log-exceptionless-api-key"];
            if (!string.IsNullOrWhiteSpace(configuration["oppo-mo-masterdata-service-log-exceptionless-folder-storage"]))
                ExceptionlessClient.Default.Configuration.UseFolderStorage(configuration["oppo-mo-masterdata-service-log-exceptionless-folder-storage"]);

            Configure<AbpMultiTenancyOptions>(options => options.IsEnabled = MoBpmConsts.IsMultiTenancyEnabled);
            Configure<AbpDbConnectionOptions>(x =>
            {
                x.ConnectionStrings.TryAdd("Default", configuration["oppo-mo-masterdata-service-data-storeage-mongo-connection-string"]);
                x.ConnectionStrings.TryAdd(MoMasterDataDbProperties.MasterConnectionStringName, configuration["oppo-mo-masterdata-service-data-storeage-sqlsever-master-connection-string"]);
                x.ConnectionStrings.TryAdd(MoMasterDataDbProperties.SlaveConnectionStringName, configuration["oppo-mo-masterdata-service-data-storeage-sqlsever-slave-connection-string"]);
            });

            context.Services
            .AddAuthentication(configuration["oppo-mo-masterdata-service-auth-scheme"])
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = configuration["oppo-mo-masterdata-service-auth-host"];
                options.ApiName = configuration["oppo-mo-masterdata-service-app-id"];
                options.RequireHttpsMetadata = false;
            });
            context.Services.AddSwaggerGen(options =>
            {
                var scopes = JsonConvert.DeserializeObject<Dictionary<string, string>>(configuration["oppo-mo-masterdata-service-scopes"]);
                options.SwaggerDoc("v1", new OpenApiInfo { Title = $"{configuration["oppo-mo-masterdata-service-app-name"]} API", Version = "v1" });
                options.DocumentFilter<SwaggerIgnoreFilter>();
                options.DocumentFilter<SwaggerEnumDocumentFilter>();
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Core.xml");
                options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Masterdata.HttpApi.xml");
                options.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Masterdata.Application.Contracts.xml");
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{configuration["oppo-mo-masterdata-service-auth-host"]}/connect/authorize", UriKind.Absolute),
                            TokenUrl = new Uri($"{configuration["oppo-mo-masterdata-service-auth-host"]}/connect/token"),
                            Scopes = scopes
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        scopes.Keys.ToArray()
                    }
                });
            });

            Configure<AbpLocalizationOptions>(options => options.Languages.Add(new LanguageInfo("en", "en", "English")));
            Configure<AbpDbContextOptions>(options => options.UseSqlServer());
            context.Services.AddStackExchangeRedisCache(options => options.Configuration = configuration["oppo-mo-masterdata-service-data-cache-redis-connection-string"]);
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = configuration["oppo-mo-masterdata-service-app-name"];
            });

            var redis = ConnectionMultiplexer.Connect(configuration["oppo-mo-masterdata-service-data-protection-redis-connection-string"]);
            context.Services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "oppo-mo-data-protection-masterdata-service");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var configuration = context.GetConfiguration();
            IdentityModelEventSource.ShowPII = true;
            var app = context.GetApplicationBuilder();
            app.UseExceptionless();
            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            if (MoBpmConsts.IsMultiTenancyEnabled)
                app.UseMultiTenancy();

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

            app.UseAbpRequestLocalization(); //TODO: localization?
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                string temp = options.ConfigObject.OAuth2RedirectUrl;
                options.SwaggerEndpoint("/swagger/v1/swagger.json", configuration["oppo-mo-masterdata-service-app-name"]);
                options.OAuthAppName(configuration["oppo-mo-masterdata-service-app-name"]);
                options.OAuthClientId(configuration["oppo-mo-masterdata-service-client-id"]);
                options.OAuthClientSecret(configuration["oppo-mo-masterdata-service-client-secret"]);
                options.OAuthUsePkce();
            });
            app.UseAuditing();
            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
