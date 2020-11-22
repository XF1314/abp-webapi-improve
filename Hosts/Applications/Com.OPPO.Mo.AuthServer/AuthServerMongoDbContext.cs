using Com.OPPO.Mo.Identity.MongoDB;
using Com.OPPO.Mo.IdentityServer.MongoDB;
using Volo.Abp.MongoDB;
using Com.OPPO.Mo.PermissionManagement.MongoDB;
using Com.OPPO.Mo.SettingManagement.MongoDB;
using Com.OPPO.Mo.AuditLogging.MongoDB;
using Com.OPPO.Mo.FeatureManagement.MongoDB;

namespace Com.OPPO.Mo.AuthServer
{
    public class AuthServerMongoDbContext : AbpMongoDbContext
    {
        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureIdentity();
            modelBuilder.ConfigureIdentityServer();
            modelBuilder.ConfigureAuditLogging();
            modelBuilder.ConfigurePermissionManagement();
            modelBuilder.ConfigureSettingManagement();
            modelBuilder.ConfigureFeatureManagement();
        }
    }
}
