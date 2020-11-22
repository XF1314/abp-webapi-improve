using Com.OPPO.Mo.Bpm;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Com.OPPO.Mo.FeatureManagement;
using Com.OPPO.Mo.FeatureManagement.MongoDB;
using Com.OPPO.Mo.Identity.MongoDB;
using Com.OPPO.Mo.InternalGateway.Filters;
using Com.OPPO.Mo.PermissionManagement;
using Com.OPPO.Mo.PermissionManagement.Identity;
using Com.OPPO.Mo.PermissionManagement.IdentityServer;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.Settings.Apollo;
using Com.OPPO.Mo.Thirdparty;
using Exceptionless;
using Exceptionless.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;

namespace Com.OPPO.Mo.InternalGateway
{
    [DependsOn(
    typeof(MoSettinsApolloModule),
    typeof(AbpAutofacModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(MoExceptionlessModule),
    typeof(MoThirdpartyHttpApiModule),
    typeof(MoBpmHttpApiModule),
    typeof(MoIdentityMongoDbModule),
    //typeof(MoMasterDataHttpApiModule),
    typeof(MoPermissionManagementDomainIdentityModule),
    typeof(MoPermissionManagementDomainIdentityServerModule),
    typeof(MoPermissionManagementMongoDbModule),
    typeof(MoPermissionManagementApplicationModule),
    typeof(MoPermissionManagementHttpApiModule),
    typeof(MoFeatureManagementMongoDbModule),
    typeof(MoFeatureManagementApplicationModule),
    typeof(MoFeatureManagementHttpApiModule),
    typeof(MoSettingManagementMongoDbModule),
    typeof(AbpAspNetCoreMultiTenancyModule))]
    public class MoInternalGatewayHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AbpCommonDbProperties.DbTablePrefix = MoBpmConsts.ProjectCode;
            var configuration = context.Services.GetConfiguration();
            ExceptionlessClient.Default.Configuration.Enabled = bool.Parse(configuration["oppo-mo-internal-gateway-log-exceptionless-enabled"]);
            ExceptionlessClient.Default.Configuration.ServerUrl = configuration["oppo-mo-internal-gateway-log-exceptionless-server-host"];
            ExceptionlessClient.Default.Configuration.ApiKey = configuration["oppo-mo-internal-gateway-log-exceptionless-api-key"];
            ExceptionlessClient.Default.Configuration.SetDefaultMinLogLevel(minLogLevel: LogLevel.Warn);
            if (!string.IsNullOrWhiteSpace(configuration["oppo-mo-internal-gateway-log-exceptionless-folder-storage"]))
                ExceptionlessClient.Default.Configuration.UseFolderStorage(configuration["oppo-mo-internal-gateway-log-exceptionless-folder-storage"]);

            Configure<AbpMultiTenancyOptions>(options => options.IsEnabled = MoBpmConsts.IsMultiTenancyEnabled);
            Configure<AbpMongoModelBuilderConfigurationOptions>(options => options.CollectionPrefix = MoBpmConsts.ProjectCode);
            context.Services.AddAuthentication(configuration["oppo-mo-internal-gateway-auth-scheme"])
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["oppo-mo-internal-gateway-auth-host"];
                    options.ApiName = configuration["oppo-mo-internal-gateway-app-id"];
                    options.RequireHttpsMetadata = false;
                });

            context.Services.AddSwaggerGen(options =>
            {
                var scopes = JsonConvert.DeserializeObject<Dictionary<string, string>>(configuration["oppo-mo-internal-gateway-scopes"]);
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{configuration["oppo-mo-internal-gateway-app-name"]} API",
                    Version = "v1",
                    Contact = new OpenApiContact { Name = "郑龙", Email = "1003885920@qq.com" }
                });
                options.DocumentFilter<SwaggerIgnoreFilter>();
                options.DocumentFilter<SwaggerEnumDocumentFilter>();
                options.DocInclusionPredicate((docName, description) => true);
                options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Core.xml");
                options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Thirdparty.HttpApi.xml");
                options.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Thirdparty.Application.Contracts.xml");
                //options.IncludeXmlComments($"{ AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Masterdata.HttpApi.xml");
                //options.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}/Com.OPPO.Mo.Masterdata.Application.Contracts.xml");
                options.CustomSchemaIds(type => type.FullName);
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{configuration["oppo-mo-internal-gateway-auth-host"]}/connect/authorize", UriKind.Absolute),
                            TokenUrl = new Uri($"{configuration["oppo-mo-internal-gateway-auth-host"]}/connect/token"),
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

            context.Services.AddOcelot(context.Services.GetConfiguration());
            context.Services.AddStackExchangeRedisCache(options => options.Configuration = configuration["oppo-mo-internal-gateway-data-cache-redis-connection-string"]);

            var redis = ConnectionMultiplexer.Connect(configuration["oppo-mo-internal-gateway-data-protection-redis-connection-string"]);
            context.Services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "oppo-mo-data-protection-internal-gateway");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var configuration = context.GetConfiguration();
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
            if (MoBpmConsts.IsMultiTenancyEnabled)
                app.UseMultiTenancy();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", configuration["oppo-mo-internal-gateway-app-name"]);
                //options.OAuth2RedirectUrl($"{configuration["AppSelfUrl"]}/swagger/oauth2-redirect.html");
                options.OAuthAppName(configuration["oppo-mo-internal-gateway-app-name"]);
                options.OAuthClientId(configuration["oppo-mo-internal-gateway-client-id"]);
                options.OAuthClientSecret(configuration["oppo-mo-internal-gateway-client-secret"]);
                options.OAuthUsePkce();
            });

            app.MapWhen(
                ctx => ctx.Request.Path.ToString().Equals("/") ||
                       ctx.Request.Path.ToString().StartsWith("/Abp/") ||
                       ctx.Request.Path.ToString().StartsWith("/api/abp/") ||
                       ctx.Request.Path.ToString().StartsWith("/api/mo/features") ||
                       ctx.Request.Path.ToString().StartsWith("/api/mo/permissions") ||
                       ctx.Request.Path.ToString().StartsWith("/api/internal-gateway/", StringComparison.OrdinalIgnoreCase),
                app2 =>
                {
                    app2.UseRouting();
                    app2.UseMvcWithDefaultRouteAndArea();
                }
            );

            app.UseOcelot().Wait();
        }
    }
}
