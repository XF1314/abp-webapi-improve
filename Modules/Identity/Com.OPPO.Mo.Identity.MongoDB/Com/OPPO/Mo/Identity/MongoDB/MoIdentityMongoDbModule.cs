using Com.OPPO.Mo.Users.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Identity.MongoDB
{
    [DependsOn(
    typeof(MoIdentityDomainModule),
    typeof(MoUsersMongoDbModule))]
    public class MoIdentityMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<MoIdentityMongoDbContext>(options =>
            {
                options.AddRepository<IdentityUser, MongoIdentityUserRepository>();
                options.AddRepository<IdentityRole, MongoIdentityRoleRepository>();
                options.AddRepository<IdentityClaimType, MongoIdentityRoleRepository>();
            });
        }
    }
}
