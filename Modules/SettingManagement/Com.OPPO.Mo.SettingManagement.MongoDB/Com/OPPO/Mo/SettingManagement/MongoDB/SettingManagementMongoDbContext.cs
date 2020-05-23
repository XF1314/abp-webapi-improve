using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.SettingManagement.MongoDB
{
    [ConnectionStringName(MoSettingManagementDbProperties.ConnectionStringName)]
    public class SettingManagementMongoDbContext : AbpMongoDbContext, ISettingManagementMongoDbContext
    {
        public IMongoCollection<Setting> Settings => Collection<Setting>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureSettingManagement();
        }
    }
}