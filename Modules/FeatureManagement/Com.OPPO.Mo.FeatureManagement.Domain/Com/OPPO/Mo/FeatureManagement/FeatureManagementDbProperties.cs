﻿using Volo.Abp.Data;

namespace Com.OPPO.Mo.FeatureManagement
{
    public static class FeatureManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpFeatureManagement";
    }
}
