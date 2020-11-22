using System;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OAuth;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI.Navigation;
using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.Identity.Web;
using Com.OPPO.Mo.PermissionManagement;
using Com.OPPO.Mo.FeatureManagement;
using Volo.Abp.Data;
using Volo.Abp.UI.Navigation.Urls;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.SettingManagement.Web;
using Com.OPPO.Mo.PermissionManagement.Web;
using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.BackgroundJobs.MongoDB;
using Volo.Abp.MongoDB;
using Volo.Abp.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Com.OPPO.Mo.BackendAdmin
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMvcClientModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(AbpAspNetCoreAuthenticationOAuthModule),

    typeof(MoCoreModule),
    typeof(MoBackgroundJobsMongoDbModule),
    typeof(MoAuditLoggingMongoDbModule),

    typeof(MoIdentityHttpApiClientModule),
    typeof(MoIdentityWebModule),

    typeof(MoPermissionManagementHttpApiClientModule),
    typeof(MoPermissionManagementWebModule),

    typeof(MoFeatureManagementHttpApiClientModule),
    typeof(MoFeatureManagementWebModule),

    typeof(MoSettingManagementMongoDbModule),
    typeof(MoSettingManagementWebModule))]
    public class MoBackendAdminWebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AbpCommonDbProperties.DbTablePrefix = MoConsts.ProjectCode;
            var configuration = context.Services.GetConfiguration();
            Configure<AppUrlOptions>(options => options.Applications["MVC"].RootUrl = configuration["AppSelfUrl"]);
            Configure<AbpLocalizationOptions>(options => options.Languages.Add(new LanguageInfo("en", "en", "English")));
            Configure<AbpMultiTenancyOptions>(options => options.IsEnabled = MoConsts.IsMultiTenancyEnabled);
            Configure<AbpNavigationOptions>(options => options.MenuContributors.Add(new BackendAdminAppMenuContributor(configuration)));

            context.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies", options => options.ExpireTimeSpan = TimeSpan.FromDays(365))
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.ClientId = configuration["AuthServer:ClientId"];
                    options.ClientSecret = configuration["AuthServer:ClientSecret"];
                    options.SaveTokens = true;
                    options.RequireHttpsMetadata = false;
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.Scope.Add("role");
                    options.Scope.Add("email");
                    options.Scope.Add("phone");
                    options.Scope.Add("MoInternalGateway");
                    options.Scope.Add("MoThirdpartyService");
                    options.Scope.Add("MoBpmService");
                    options.Scope.Add("offline_access");
                    options.ClaimActions.MapAbpClaimTypes();
                });

            Configure<AbpMongoModelBuilderConfigurationOptions>(options => options.CollectionPrefix = MoConsts.ProjectCode);
            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend Admin Application API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });

            context.Services.AddStackExchangeRedisCache(options => options.Configuration = configuration["Redis:Configuration"]);
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "Mo-DataProtection-Keys-BackendAdmin");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            if (MoConsts.IsMultiTenancyEnabled)
                app.UseMultiTenancy();
            app.UseAuthorization();
            app.UseAbpRequestLocalization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend Admin Application API");
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
