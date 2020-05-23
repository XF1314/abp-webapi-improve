using Volo.Abp.Data;

namespace Com.OPPO.Mo.AuditLogging
{
    public static class MoAuditLoggingDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "MoAuditLogging";
    }
}
