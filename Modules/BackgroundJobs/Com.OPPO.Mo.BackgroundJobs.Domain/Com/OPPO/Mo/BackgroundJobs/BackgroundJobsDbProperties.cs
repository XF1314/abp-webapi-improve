﻿using Volo.Abp.Data;

namespace Com.OPPO.Mo.BackgroundJobs
{
    public static class BackgroundJobsDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpBackgroundJobs";
    }
}
