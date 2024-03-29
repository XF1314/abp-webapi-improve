﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.BackgroundJobs.EntityFrameworkCore
{
    [ConnectionStringName(BackgroundJobsDbProperties.ConnectionStringName)]
    public interface IBackgroundJobsDbContext : IEfCoreDbContext
    {
        DbSet<BackgroundJobRecord> BackgroundJobs { get; }
    }
}