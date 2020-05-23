using Volo.Abp.Data;

namespace Com.OPPO.Mo.SettingManagement
{
    public static class MoSettingManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "MoSettingManagement";
    }
}
