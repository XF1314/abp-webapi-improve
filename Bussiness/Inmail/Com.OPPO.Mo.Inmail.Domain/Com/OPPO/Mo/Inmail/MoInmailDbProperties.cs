using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;

namespace Com.OPPO.Mo.Inmail
{
     public static class MoInmailDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "MoInmail";

        public const string ReadonlyConnectionStringName = "MoInmailReadonly";
    }
}
