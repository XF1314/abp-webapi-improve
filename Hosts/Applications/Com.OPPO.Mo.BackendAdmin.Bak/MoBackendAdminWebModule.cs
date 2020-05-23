using Com.OPPO.Mo.Account;
using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.BackgroundJobs.MongoDB;
using Com.OPPO.Mo.Blogging;
using Com.OPPO.Mo.Blogging.Web;
using Com.OPPO.Mo.FeatureManagement;
using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.Identity.Web;
using Com.OPPO.Mo.PermissionManagement;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.PermissionManagement.Web;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.SettingManagement.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OAuth;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;

namespace Com.OPPO.Mo.BackendAdmin
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMvcClientModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(AbpAspNetCoreAuthenticationOAuthModule),

    typeof(MoBackgroundJobsMongoDbModule),
    typeof(MoAccountApplicationModule),
    typeof(MoAuditLoggingMongoDbModule),

    typeof(MoIdentityHttpApiClientModule),
    typeof(MoIdentityWebModule),

    typeof(MoBloggingHttpApiClientModule),
    typeof(MoBloggingWebModule),

    typeof(MoFeatureManagementHttpApiClientModule),
    typeof(MoFeatureManagementWebModule),

    typeof(MoPermissionManagementMongoDbModule),
    typeof(MoPermissionManagementHttpApiClientModule),
    typeof(MoPermissionManagementWebModule),

    typeof(MoSettingManagementMongoDbModule),
    typeof(MoSettingManagementWebModule))]
    public class MoBackendAdminWebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AbpCommonDbProperties.DbTablePrefix = MoConsts.ProjectCode;
            var configuration = context.Services.GetConfiguration();
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["AppSelfUrl"];
            });
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
            });
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MoConsts.IsMultiTenancyEnabled;
            });
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BackendAdminAppMenuContributor(configuration));
            });

            context.Services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.ApiName = configuration["AuthServer:ApiName"];
                options.RequireHttpsMetadata = false;
            });
            //context.Services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //.AddCookie("Cookies", options =>
            //{
            //    options.ExpireTimeSpan = TimeSpan.FromDays(365);
            //})
            //.AddOpenIdConnect("oidc", options =>
            //{
            //    options.Authority = configuration["AuthServer:Authority"];
            //    options.ClientId = configuration["AuthServer:ClientId"];
            //    options.ClientSecret = configuration["AuthServer:ClientSecret"];
            //    options.RequireHttpsMetadata = false;
            //    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
            //    options.SaveTokens = true;
            //    options.GetClaimsFromUserInfoEndpoint = true;
            //    options.Scope.Add("role");
            //    options.Scope.Add("email");
            //    options.Scope.Add("phone");
            //    options.ClaimActions.MapAbpClaimTypes();
            //});

            Configure<AuthenticationOptions>(x =>
            {
                var ss = x.DefaultForbidScheme;

            });

            Configure<AbpMongoModelBuilderConfigurationOptions>(options =>
            {
                options.CollectionPrefix = MoConsts.ProjectCode;
            });

            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Mo Backend Admin Application API", Version = "v1" });
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
                            AuthorizationUrl = new Uri($"{configuration["AuthServer:Authority"]}/connect/authorize", UriKind.Absolute),
                            TokenUrl = new Uri($"{configuration["AuthServer:Authority"]}/connect/token"),
                            Scopes = new Dictionary<string, string> {
                                { "offline_access", "012" },
                                { "MoIdentityService", "123" },
                                { "MoInmailService", "234" },
                                { "MoWorkflowService", "345" },
                                { "MoExternalService", "456" },
                                { "MoBloggingService", "567" },
                                { "MoInternalGateway", "789" }}
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
                        configuration["AuthServer:Scope"].Split(new char[]{' '})
                    }
                });
            });

            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });

            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "Mo-DataProtection-Keys-BackendAdmin");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            IdentityModelEventSource.ShowPII = true;
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseMiddleware<MoAuthorizationMiddleware>();
            if (MoConsts.IsMultiTenancyEnabled)
            {
                app.UseMultiTenancy();
            }
            app.UseAuthorization();
            app.UseAbpRequestLocalization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var configuration = context.GetConfiguration();
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mo Backend Admin Application API");
                options.OAuth2RedirectUrl($"{configuration["AppSelfUrl"]}/swagger/oauth2-redirect.html");
                options.OAuthAppName(configuration["AppName"]);
                options.OAuthClientId(configuration["AuthServer:ClientId"]);
                options.OAuthClientSecret(configuration["AuthServer:ClientSecret"]);
                options.OAuthUsePkce();
            });
            app.Use(async (ctx, next) =>
            {
                var currentPrincipalAccessor = ctx.RequestServices.GetRequiredService<ICurrentPrincipalAccessor>();
                var kk = currentPrincipalAccessor.Principal;
                var ss = ctx.RequestServices.GetRequiredService<IHttpContextAccessor>();
                var sk = ss.HttpContext;
                await next();
            });
            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
