using Volo.Abp.Data;

namespace Com.OPPO.Mo.TenantManagement
{
    public static class MoTenantManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "MoTenantManagement";
    }
}
