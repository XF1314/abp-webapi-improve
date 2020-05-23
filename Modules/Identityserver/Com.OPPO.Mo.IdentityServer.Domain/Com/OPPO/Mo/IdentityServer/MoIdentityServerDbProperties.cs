namespace Com.OPPO.Mo.IdentityServer
{
    public static class MoIdentityServerDbProperties
    {
        public static string DbTablePrefix { get; set; } = "IdentityServer";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "MoIdentityServer";
    }
}
