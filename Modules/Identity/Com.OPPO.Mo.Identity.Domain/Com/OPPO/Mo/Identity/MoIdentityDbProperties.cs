using Volo.Abp.Data;

namespace Com.OPPO.Mo.Identity
{
    public static class MoIdentityDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "MoIdentity";
    }
}
