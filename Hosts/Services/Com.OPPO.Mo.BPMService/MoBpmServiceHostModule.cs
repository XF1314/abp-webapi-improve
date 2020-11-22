using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.Bpm;
using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.BpmService.Filters;
using Com.OPPO.Mo.BpmService.Middlewares;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.Settings.Apollo;
using Com.OPPO.MO.ExceptionlessExtensions;
using Exceptionless;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;

namespace Com.OPPO.Mo.BpmService
{
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(MoSettinsApolloModule))]
    [DependsOn(typeof(MoExceptionlessModule))]
    [DependsOn(typeof(MoAuditLoggingMongoDbModule))]
    [DependsOn(typeof(MoSettingManagementMongoDbModule))]
    [DependsOn(typeof(MoPermissionManagementMongoDbModule))]
    [DependsOn(typeof(MoBpmHttpApiModule))]
    [DependsOn(typeof(MoBpmApplicationModule))]
    [DependsOn(typeof(MoBpmMongoDbModule))]
    public class MoBpmServiceHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            ExceptionlessClient.Default.Configuration.Enabled = bool.Parse(configuration["oppo-mo-bpm-service-log-exceptionless-enabled"]);
            ExceptionlessClient.Default.Configuration.ServerUrl = configuration["oppo-mo-bpm-service-log-exceptionless-server-host"];
            ExceptionlessClient.Default.Configuration.ApiKey = configuration["oppo-mo-bpm-service-log-exceptionless-api-key"];
            if (!string.IsNullOrWhiteSpace(configuration["oppo-mo-bpm-service-log-exceptionless-folder-storage"]))
                ExceptionlessClient.Default.Configuration.UseFolderStorage(configuration["oppo-mo-bpm-service-log-exceptionless-folder-storage"]);

            Configure<AbpMultiTenancyOptions>(options => options.IsEnabled = MoBpmConsts.IsMultiTenancyEnabled);
            Configure<AbpDbConnectionOptions>(x =>
            x.ConnectionStrings.TryAdd("Default", configuration["oppo-mo-bpm-service-data-storeage-mongo-connection-string"]));
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            context.Services
                .AddAuthentication(configuration["oppo-mo-bpm-service-auth-scheme"])
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["oppo-mo-bpm-service-auth-host"];
                    options.ApiName = configuration["oppo-mo-bpm-service-app-id"];
                    options.RequireHttpsMetadata = false;
                });
            context.Services.AddSwaggerGen(options =>
            {
                var scopes = JsonConvert.DeserializeObject<Dictionary<string, string>>(configuration["oppo-mo-bpm-service-scopes"]);
                options.SwaggerDoc("v1", new OpenApiInfo { Title = $"{configuration["oppo-mo-bpm-service-app-name"]} API", Version = "v1" });
                options.DocumentFilter<SwaggerIgnoreFilter>();
                options.DocumentFilter<SwaggerEnumDocumentFilter>();
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Core.xml");
                options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Bpm.HttpApi.xml");
                options.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Bpm.Application.Contracts.xml");
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{configuration["oppo-mo-bpm-service-auth-host"]}/connect/authorize", UriKind.Absolute),
                            TokenUrl = new Uri($"{configuration["oppo-mo-bpm-service-auth-host"]}/connect/token"),
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
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = configuration["oppo-mo-bpm-service-app-name"];
            });
            Configure<AbpLocalizationOptions>(options => options.Languages.Add(new LanguageInfo("en", "en", "English")));
            context.Services.AddStackExchangeRedisCache(options => options.Configuration = configuration["oppo-mo-bpm-service-data-cache-redis-connection-string"]);
            context.Services.AddCap(x =>
            {
                x.UseDashboard();
                x.UseMongoDB(y =>
                {
                    y.DatabaseConnection = configuration["oppo-mo-bpm-service-data-storeage-mongo-connection-string"];
                    y.DatabaseName = "BpmOpenApi";
                });
                x.UseKafka(configuration["oppo-mo-bpm-service-mq-kafka-connection-string"]);
                x.FailedRetryCount = int.Parse(configuration["oppo-mo-bpm-service-cap-failed-retry-count"]);
                x.FailedRetryInterval = int.Parse(configuration["oppo-mo-bpm-service-cap-failed-retry-interval"]);
                x.SucceedMessageExpiredAfter = int.Parse(configuration["oppo-mo-bpm-service-cap-succeed-message-expire-after"]);
            });

            var redis = ConnectionMultiplexer.Connect(configuration["oppo-mo-bpm-service-data-protection-redis-connection-string"]);
            context.Services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "oppo-mo-data-protection-bpm-service");
            context.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;// 60000000; 
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                //日期类型默认格式化处理
                jsonSerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                jsonSerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                //jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
#if DEBUG
                jsonSerializerSettings.Formatting = Formatting.Indented;
#else
jsonSerializerSettings.Formatting = Formatting.None;
#endif
                //jsonSerializerSettings.NullValueHandling = NullValueHandling.Include;
                return jsonSerializerSettings;
            });
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
            app.UseAuthorization();
            app.Use(async (ctx, next) =>
            {
                var currentPrincipalAccessor = ctx.RequestServices.GetRequiredService<ICurrentPrincipalAccessor>();
                var appId = ctx.Request.Headers.GetOrDefault("appId");//兼容统一开放平台的接口管理，可绕过本身认证和授权
                var thirdAppId = ctx.Request.Headers.GetOrDefault("thirdAppId");
                appId = !string.IsNullOrWhiteSpace(appId) ? appId : thirdAppId;
                if (!string.IsNullOrWhiteSpace(appId))
                {
                    var claim = new Claim(AbpClaimTypes.ClientId, appId);
                    currentPrincipalAccessor.Principal.Identities.First().AddClaim(claim);
                }

                await next();
            });
            app.UseMiddleware<ExceptionLessWebhookMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{configuration["oppo-mo-bpm-service-app-name"]} API");
                //options.OAuth2RedirectUrl($"{configuration["AppSelfUrl"]}/swagger/oauth2-redirect.html");
                options.OAuthAppName(configuration["oppo-mo-bpm-service-app-name"]);
                options.OAuthClientId(configuration["oppo-mo-bpm-service-client-id"]);
                options.OAuthClientSecret(configuration["oppo-mo-bpm-service-client-secret"]);
            });
            app.UseAuditing();
            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
