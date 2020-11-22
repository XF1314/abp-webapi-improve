using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;

namespace Com.OPPO.Mo.MasterData
{
     public static class MoMasterDataDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string MasterConnectionStringName = "MoMaster";

        public const string SlaveConnectionStringName = "MoSlave";

        public const string ProcessConnectionStringName = "Process";
    }
}
