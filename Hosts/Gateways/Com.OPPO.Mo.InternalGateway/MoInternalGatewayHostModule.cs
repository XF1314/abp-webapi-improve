using Com.OPPO.Mo.Blogging;
using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
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
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.TenantManagement;
using Com.OPPO.Mo.PermissionManagement.Identity;
using Com.OPPO.Mo.PermissionManagement.IdentityServer;
using Com.OPPO.Mo.PermissionManagement;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Com.OPPO.Mo.TenantManagement.MongoDB;
using Com.OPPO.Mo.FeatureManagement.MongoDB;
using Com.OPPO.Mo.FeatureManagement;
using Com.OPPO.Mo.Inmail;
using Com.OPPO.Mo.Identity.MongoDB;

namespace Com.OPPO.Mo.InternalGateway
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(MoIdentityHttpApiModule),
    typeof(MoIdentityMongoDbModule),
    //typeof(MoIdentityHttpApiClientModule),
    typeof(MoBloggingHttpApiModule),
    //typeof(MoBloggingHttpApiClientModule),
    typeof(MoInmailHttpApiModule),
    //typeof(MoInmailHttpApiClientModule),
    typeof(MoPermissionManagementDomainIdentityModule),
    typeof(MoPermissionManagementDomainIdentityServerModule),
    typeof(MoPermissionManagementMongoDbModule),
    typeof(MoPermissionManagementApplicationModule),
    typeof(MoPermissionManagementHttpApiModule),
    typeof(MoFeatureManagementMongoDbModule),
    typeof(MoFeatureManagementApplicationModule),
    typeof(MoFeatureManagementHttpApiModule),
    typeof(MoSettingManagementMongoDbModule),
    typeof(MoTenantManagementMongoDbModule),
    typeof(MoTenantManagementApplicationModule),
    typeof(MoTenantManagementHttpApiModule),
    typeof(AbpAspNetCoreMultiTenancyModule))]
    public class MoInternalGatewayHostModule : AbpModule
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

            context.Services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.ApiName = configuration["AuthServer:ApiName"];
                    options.RequireHttpsMetadata = false;
                });

            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Mo Internal Gateway API", Version = "v1", Contact = new OpenApiContact { Name = "郑龙", Email = "1003885920@qq.com" } });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                //options.DocumentFilter<HiddenApiFilter>(); // 在接口类、方法标记属性 [HiddenApi]，可以阻止【Swagger文档】生成
                //options.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request", false); // adds any string you like to the request headers - in this case, a correlation id
                //options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //options.OperationFilter<AddResponseHeadersFilter>();
                //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                //    In = ParameterLocation.Header,
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey
                //});

                // 接入identityserver4
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{configuration["AuthServer:Authority"]}/connect/authorize", UriKind.Absolute),
                            TokenUrl = new Uri($"{configuration["AuthServer:Authority"]}/connect/token"),
                            // 这里配置是 scope 作用域，
                            // 只需要填写 api资源 的id即可，
                            // 不需要把 身份资源 的内容写上，比如openid 
                            Scopes = new Dictionary<string, string> {
                                { "MoInternalGateway","012"},
                                { "MoIdentityService", "123" },
                                { "MoWorkflowService", "234" },
                                { "MoExternalService","345"},
                                { "MoBloggingService","456" },
                                { "MoInmailService" ,"567"},
                                { "offline_access", "678" }
                            }
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
                        new[] { "MoIdentityService", "MoWorkflowService", "MoExternalService" , "MoBloggingService", "MoInmailService", "offline_access" }
                    }
                });
            });

            context.Services.AddOcelot(context.Services.GetConfiguration());
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });

            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "Mo-DataProtection-Keys-InternalGateway");
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
            if (MoConsts.IsMultiTenancyEnabled)
            {
                app.UseMultiTenancy();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mo Internal Gateway API");
                options.OAuth2RedirectUrl($"{configuration["AppSelfUrl"]}/swagger/oauth2-redirect.html");
                options.OAuthAppName(configuration["AppName"]);
                options.OAuthClientId(configuration["IdentityClients:InternalGateway:ClientId"]);
                options.OAuthClientSecret(configuration["IdentityClients:InternalGateway:ClientSecret"]);
                options.OAuthUsePkce();
            });

            app.MapWhen(
                ctx => ctx.Request.Path.ToString().Equals("/") ||
                       ctx.Request.Path.ToString().StartsWith("/Abp/") ||
                       ctx.Request.Path.ToString().StartsWith("/api/abp/") ||
                       ctx.Request.Path.ToString().StartsWith("/api/mo/features") ||
                       ctx.Request.Path.ToString().StartsWith("/api/mo/permissions") ||
                       ctx.Request.Path.ToString().StartsWith("/api/multi-tenancy/tenants")||
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
