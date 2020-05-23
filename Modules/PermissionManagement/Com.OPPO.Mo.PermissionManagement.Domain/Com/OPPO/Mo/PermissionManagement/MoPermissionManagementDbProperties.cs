using Volo.Abp.Data;

namespace Com.OPPO.Mo.PermissionManagement
{
    public static class MoPermissionManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "MoPermissionManagement";
    }
}
