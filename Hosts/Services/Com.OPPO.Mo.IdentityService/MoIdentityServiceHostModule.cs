using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.Auditing;
using Volo.Abp.EventBus.RabbitMq;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using  Com.OPPO.Mo.TenantManagement.MongoDB;
using Microsoft.IdentityModel.Logging;
using Volo.Abp.MongoDB;
using Volo.Abp.Data;
using System;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.Identity.MongoDB;

namespace Com.OPPO.Mo.IdentityService
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(MoAuditLoggingMongoDbModule),
    typeof(MoSettingManagementMongoDbModule),
    typeof(MoPermissionManagementMongoDbModule),
    typeof(MoIdentityHttpApiModule),
    typeof(MoIdentityMongoDbModule),
    typeof(MoIdentityApplicationModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(MoTenantManagementMongoDbModule))]
    public class MoIdentityServiceHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AbpCommonDbProperties.DbTablePrefix = MoConsts.ProjectCode;
            var configuration = context.Services.GetConfiguration();
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MoConsts.IsMultiTenancyEnabled;
            });
            Configure<AbpMongoModelBuilderConfigurationOptions>(options =>
            {
                options.CollectionPrefix = MoConsts.ProjectCode;
            });

            context.Services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.ApiName = configuration["AuthServer:ApiName"];
                    options.RequireHttpsMetadata = false;
                });
            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Mo Identity Service API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                // 接入identityserver4
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        // 因为是 api 项目，那肯定是前后端分离的，所以用的是Implicit模式
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            // 这里配置 identityServer 项目的域名
                            AuthorizationUrl = new Uri( $"{configuration["AuthServer:Authority"]}/connect/authorize", UriKind.Absolute),
                            TokenUrl = new Uri($"{configuration["AuthServer:Authority"]}/connect/token"),
                            // 这里配置是 scope 作用域，
                            // 只需要填写 api资源 的id即可，
                            // 不需要把 身份资源 的内容写上，比如openid 
                            Scopes = new Dictionary<string, string> { { "MoIdentityService", "123" }, { "offline_access", "234" }, { "MoInternalGateway", "345" } }
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
                        new[] { "MoIdentityService", "offline_access" , "MoInternalGateway" }
                    }
                });
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

            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "Mo-DataProtection-Keys-Identity");
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
            if (MoConsts.IsMultiTenancyEnabled)
            {
                app.UseMultiTenancy();
            }
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
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mo Identity Service API");
                options.OAuth2RedirectUrl($"{configuration["AppSelfUrl"]}/swagger/oauth2-redirect.html");
                options.OAuthAppName(configuration["AppName"]);
                options.OAuthClientId(configuration["IdentityClients:IdentityServiceClient:ClientId"]);
                options.OAuthClientSecret(configuration["IdentityClients:IdentityServiceClient:ClientSecret"]);
                options.OAuthUsePkce();                
            });
            app.UseAuditing();
            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
