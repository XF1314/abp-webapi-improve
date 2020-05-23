using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Identity.AspNetCore
{
    [DependsOn(
    typeof(MoIdentityDomainModule))]
    public class MoIdentityAspNetCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services
                .GetObject<IdentityBuilder>()
                .AddDefaultTokenProviders()
                .AddSignInManager();

            //(TODO: Extract an extension method like IdentityBuilder.AddAbpSecurityStampValidator())
            context.Services.AddScoped<MoSecurityStampValidator>();
            context.Services.AddScoped(typeof(SecurityStampValidator<IdentityUser>), provider => provider.GetService(typeof(MoSecurityStampValidator)));
            context.Services.AddScoped(typeof(ISecurityStampValidator), provider => provider.GetService(typeof(MoSecurityStampValidator)));

            var options = context.Services.ExecutePreConfiguredActions(new MoIdentityAspNetCoreOptions());

            if (options.ConfigureAuthentication)
            {
                context.Services
                    .AddAuthentication(o =>
                    {
                        o.DefaultScheme = IdentityConstants.ApplicationScheme;
                        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                    })
                    .AddIdentityCookies();
            }
        }
    }
}
