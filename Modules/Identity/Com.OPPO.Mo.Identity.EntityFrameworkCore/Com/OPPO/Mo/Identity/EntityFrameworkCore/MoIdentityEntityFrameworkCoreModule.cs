using Com.OPPO.Mo.Users.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Identity.EntityFrameworkCore
{
    [DependsOn(
        typeof(MoIdentityDomainModule), 
        typeof(MoUsersEntityFrameworkCoreModule))]
    public class MoIdentityEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdentityDbContext>(options =>
            {
                options.AddRepository<IdentityUser, EfCoreIdentityUserRepository>();
                options.AddRepository<IdentityRole, EfCoreIdentityRoleRepository>();
                options.AddRepository<IdentityClaimType, EfCoreIdentityClaimTypeRepository>();
            });
        }
    }
}
