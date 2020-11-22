using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.Settings.Apollo;
using Com.OPPO.Mo.Thirdparty;
using Com.OPPO.Mo.ThirdpartyService.Filters;
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
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;

namespace Com.OPPO.Mo.ThirdpartyService
{
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(MoSettinsApolloModule))]
    [DependsOn(typeof(MoExceptionlessModule))]
    [DependsOn(typeof(MoAuditLoggingMongoDbModule))]
    [DependsOn(typeof(MoSettingManagementMongoDbModule))]
    [DependsOn(typeof(MoPermissionManagementMongoDbModule))]
    [DependsOn(typeof(MoThirdpartyHttpApiModule))]
    [DependsOn(typeof(MoThirdpartyApplicationModule))]
    public class MoThirdpartyServiceHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            ExceptionlessClient.Default.Configuration.Enabled = bool.Parse(configuration["oppo-mo-thirdparty-service-log-exceptionless-enabled"]);
            ExceptionlessClient.Default.Configuration.ServerUrl = configuration["oppo-mo-thirdparty-service-log-exceptionless-server-host"];
            ExceptionlessClient.Default.Configuration.ApiKey = configuration["oppo-mo-thirdparty-service-log-exceptionless-api-key"];
            if (!string.IsNullOrWhiteSpace(configuration["oppo-mo-thirdparty-service-log-exceptionless-folder-storage"]))
                ExceptionlessClient.Default.Configuration.UseFolderStorage(configuration["oppo-mo-thirdparty-service-log-exceptionless-folder-storage"]);

            Configure<AbpDbConnectionOptions>(x =>
            x.ConnectionStrings.TryAdd("Default", configuration["oppo-mo-thirdparty-service-storeage-mongo-connection-string"]));
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            context.Services
            .AddAuthentication(configuration["oppo-mo-thirdparty-service-auth-scheme"])
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = configuration["oppo-mo-thirdparty-service-auth-host"];
                options.ApiName = configuration["oppo-mo-thirdparty-service-app-id"];
                options.RequireHttpsMetadata = false;
            });
            context.Services.AddSwaggerGen(options =>
            {
                var scopes = JsonConvert.DeserializeObject<Dictionary<string, string>>(configuration["oppo-mo-thirdparty-service-scopes"]);
                options.SwaggerDoc("v1", new OpenApiInfo { Title = $"{configuration["oppo-mo-thirdparty-service-app-name"]} API", Version = "v1" });
                options.DocumentFilter<SwaggerEnumDocumentFilter>();
                options.DocumentFilter<SwaggerIgnoreFilter>();
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Core.xml");
                options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Thirdparty.HttpApi.xml");
                options.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Thirdparty.Application.Contracts.xml");
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{configuration["oppo-mo-thirdparty-service-auth-host"]}/connect/authorize", UriKind.Absolute),
                            TokenUrl = new Uri($"{configuration["oppo-mo-thirdparty-service-auth-host"]}/connect/token"),
                            Scopes = scopes
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }},
                        scopes.Keys.ToArray()
                    }
                });
            });

            Configure<AbpLocalizationOptions>(options => options.Languages.Add(new LanguageInfo("en", "en", "English")));
            context.Services.AddStackExchangeRedisCache(options => options.Configuration = configuration["oppo-mo-thirdparty-service-data-cache-redis-conncetion-string"]);
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = configuration["oppo-mo-thirdparty-service-app-name"];
            });

            var redis = ConnectionMultiplexer.Connect(configuration["oppo-mo-thirdparty-service-data-protection-redis-connection-string"]);
            context.Services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "oppo-mo-data-protection-thirdparty-service");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var configuration = context.GetConfiguration();
            IdentityModelEventSource.ShowPII = true;
            var app = context.GetApplicationBuilder();

            app.UseExceptionless();
            app.UseExceptionless(configuration);
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

            //app.UseAbpRequestLocalization(); //TODO: localization?
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{configuration["oppo-mo-thirdparty-service-app-name"]} API");
                //options.OAuth2RedirectUrl($"{configuration["AppSelfUrl"]}/swagger/oauth2-redirect.html");
                options.OAuthAppName(configuration["oppo-mo-thirdparty-service-app-name"]);
                options.OAuthClientId(configuration["oppo-mo-thirdparty-service-client-id"]);
                options.OAuthClientSecret(configuration["oppo-mo-thirdparty-service-client-secret"]);
            });
            app.UseAuditing();
            app.UseMvcWithDefaultRouteAndArea();
        }

    }
}
